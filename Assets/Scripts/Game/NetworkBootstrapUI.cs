using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GhostHunter.Game
{
    /// <summary>
    /// 접속이 끊겼을 때를 감시해 연결 끊김 화면(UGUI)을 띄운다.
    ///
    /// <b>이제 화면을 직접 그리지 않는다.</b> 대기방·결과·게임 중 HUD는 전부 UGUI가
    /// 맡는다 — 대기방은 <see cref="UI.WaitingRoomHudUI"/>, 결과는
    /// <see cref="UI.ResultHudUI"/>, 게임 중은 <see cref="UI.GameHudController"/>가
    /// 관리하는 Common/Ghost/Exorcist HUD다. 예전에 이 클래스가 그리던 IMGUI 결과
    /// 패널은 UGUI 결과 화면과 <b>겹쳐 보여</b> 걷어냈다.
    ///
    /// 접속·방 만들기·참가는 MainMenuScene의 <see cref="UI.LobbyJoinUI"/>가 전담하고,
    /// 방을 만들면 곧바로 GameScene으로 넘어간다(<see cref="PreGameLobby.ServerStartGame"/>) —
    /// GameScene은 <b>항상 접속 후에만</b> 로드된다.
    /// </summary>
    public class NetworkBootstrapUI : MonoBehaviour
    {
        [Header("연결 끊김 UGUI (StopHud/DisconnectedPanel)")]
        [SerializeField] private GameObject disconnectedPanel;
        [SerializeField] private TextMeshProUGUI disconnectedMessageText;
        [SerializeField] private Button mainMenuButton;

        private string statusMessage;
        private bool subscribed;

        /// <summary>다음 프레임에 Shutdown을 실행해야 하는가. 아래 RequestShutdown 주석 참고.</summary>
        private bool shutdownRequested;
        private string pendingMessage;

        private void Awake()
        {
            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenuScene"));
            }

            if (disconnectedPanel != null) disconnectedPanel.SetActive(false);
        }

        /// <summary>
        /// 접속이 끊기는 것을 <b>직접 감시한다.</b>
        ///
        /// 로비(MainMenuScene)를 거쳐야만 GameScene에 도착하므로 여기서는 항상 접속된
        /// 상태로 시작한다. 그런데도 도중에 끊기면(호스트 종료 등) 캐릭터가 사라지고
        /// 아무 화면도 못 그리는 상태가 되므로, 끊김 콜백으로 붙잡아 메인 메뉴로
        /// 돌아갈 길을 만들어준다.
        /// </summary>
        private void Update()
        {
            var nm = NetworkManager.Singleton;
            if (nm == null)
            {
                return;
            }

            if (!subscribed)
            {
                nm.OnClientDisconnectCallback += OnClientDisconnect;
                subscribed = true;
            }

            TickShutdown(nm);
            ApplyDisconnectedPanel(nm);
        }

        /// <summary>미접속 상태(호스트 종료 등으로 끊긴 경우 포함)면 UGUI 연결 끊김 화면을 켠다.</summary>
        private void ApplyDisconnectedPanel(NetworkManager nm)
        {
            bool connected = nm.IsServer || nm.IsConnectedClient;

            if (disconnectedPanel != null)
            {
                disconnectedPanel.SetActive(!connected);
            }

            if (!connected && disconnectedMessageText != null)
            {
                disconnectedMessageText.text = string.IsNullOrEmpty(statusMessage)
                    ? "연결이 끊겼습니다"
                    : statusMessage;
            }
        }

        private void OnDestroy()
        {
            var nm = NetworkManager.Singleton;
            if (nm == null)
            {
                return;
            }

            if (subscribed)
            {
                nm.OnClientDisconnectCallback -= OnClientDisconnect;
                subscribed = false;
            }

            // 여기서 Shutdown을 부르지 말 것.
            //
            // Play 모드를 나갈 때 NGO는 스스로 정리 절차를 밟는다. 그런데 컴포넌트
            // 파괴 순서는 보장되지 않아서, 그 정리 도중에 끼어들어 Shutdown을 또 부르면
            // 전송 계층이 어중간한 상태에서 끊겨 <b>UDP 소켓이 반환되지 않는다.</b>
            // 실제로 그렇게 만들었다가 Play를 다시 켜도 포트가 안 풀리는 회귀를 냈다.
        }

        private void OnClientDisconnect(ulong clientId)
        {
            var nm = NetworkManager.Singleton;
            if (nm == null || nm.IsServer)
            {
                return;
            }

            if (!nm.IsConnectedClient)
            {
                RequestShutdown("접속이 끊겼습니다. 방이 없거나 호스트가 종료했습니다.");
            }
        }

        /// <summary>
        /// Shutdown을 <b>다음 프레임으로 미룬다.</b>
        ///
        /// 끊김 콜백 안에서 곧바로 <c>Shutdown()</c>을 부르면 전송 계층이 자기 정리를
        /// 하는 도중에 발밑이 무너진다. 그러면 <b>UDP 소켓이 반환되지 않고 프로세스에 남아</b>,
        /// 화면상 미접속인데도 포트가 계속 물려 다음 호스트 시작이 실패한다.
        /// 에디터를 껐다 켜야만 풀리는 상태가 되므로 반드시 프레임을 넘겨서 정리한다.
        /// </summary>
        private void RequestShutdown(string message)
        {
            shutdownRequested = true;
            pendingMessage = message;
        }

        /// <summary>예약된 Shutdown을 안전한 시점에 실행한다.</summary>
        private void TickShutdown(NetworkManager nm)
        {
            if (!shutdownRequested || nm.ShutdownInProgress)
            {
                return;
            }

            shutdownRequested = false;

            if (nm.IsClient || nm.IsServer)
            {
                nm.Shutdown();
            }

            statusMessage = pendingMessage;
            pendingMessage = null;
        }

    }
}
