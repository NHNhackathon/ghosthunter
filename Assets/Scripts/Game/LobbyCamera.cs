using GhostHunter.Core;
using UnityEngine;

namespace GhostHunter.Game
{
    /// <summary>
    /// 로비·결과 화면을 비추는 씬 카메라 (기술 문서 4-1).
    ///
    /// 게임이 시작되면 각자 플레이어의 1인칭 카메라로 넘어가므로 이 카메라는 꺼진다.
    /// 둘 다 켜져 있으면 화면이 겹쳐 보이기 때문에 <b>정확히 하나만</b> 켜져 있어야 한다.
    ///
    /// <b>결과 화면에서는 저택을 비추지 않고 검게 덮는다.</b> 아래 <see cref="ApplyBlackout"/> 참고.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class LobbyCamera : MonoBehaviour
    {
        private Camera cam;
        private AudioListener listener;

        // 결과 화면에서 잠시 덮어쓰기 전의 원래 설정. 대기방으로 돌아갈 때 되돌린다.
        private CameraClearFlags baseClearFlags;
        private Color baseBackground;
        private int baseCullingMask;
        private bool blackedOut;

        private void Awake()
        {
            cam = GetComponent<Camera>();
            listener = GetComponent<AudioListener>();

            baseClearFlags = cam.clearFlags;
            baseBackground = cam.backgroundColor;
            baseCullingMask = cam.cullingMask;
        }

        private void LateUpdate()
        {
            // 플레이어 카메라가 켜지는 것보다 늦게 판단해야 한 프레임 깜빡임이 없다.
            //
            // <b>기준은 단계가 아니라 "내 몸이 있는가"다.</b> 대기방도 1인칭으로 걸어다니는
            // 공간이 됐으므로, 접속해서 캐릭터가 생기는 순간 이 카메라는 물러나야 한다.
            // 단계로 판단하면 대기방에 서 있는데 화면은 씬 카메라인 상태가 된다.
            //
            // 결과 화면은 예외다. 커서로 버튼을 눌러야 하므로 이 카메라가 다시 나선다.
            bool hasBody = Player.NetworkPlayer.GetLocal() != null;
            bool lobbyView = !hasBody || !GameManager.IsFirstPersonActive;

            if (cam.enabled != lobbyView)
            {
                cam.enabled = lobbyView;
            }

            // 오디오 리스너가 씬에 2개면 Unity가 경고를 뱉는다.
            if (listener != null && listener.enabled != lobbyView)
            {
                listener.enabled = lobbyView;
            }

            ApplyBlackout(GameManager.CurrentPhase == GamePhase.Result);
        }

        /// <summary>
        /// 결과 화면에서 저택을 지우고 <b>검은 배경</b>만 남긴다.
        ///
        /// 환경광을 내리는 방식으로는 검게 만들 수 없다 — 촛대·램프 같은
        /// <b>실제 조명은 그대로 남아</b> 주변을 비추기 때문이다. 카메라가 아무것도
        /// 그리지 않게(<c>cullingMask = 0</c>) 하고 검게 지우는 편이 확실하다.
        ///
        /// 결과 UI는 Screen Space - Overlay 캔버스라 카메라와 무관하게 그려지므로
        /// 여기서 다 지워도 승패·약점 표시는 그대로 보인다.
        /// </summary>
        private void ApplyBlackout(bool on)
        {
            if (blackedOut == on)
            {
                return;
            }

            blackedOut = on;

            cam.clearFlags = on ? CameraClearFlags.SolidColor : baseClearFlags;
            cam.backgroundColor = on ? Color.black : baseBackground;
            cam.cullingMask = on ? 0 : baseCullingMask;
        }
    }
}
