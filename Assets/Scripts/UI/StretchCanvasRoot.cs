using UnityEngine;

namespace GhostHunter.UI
{
    /// <summary>
    /// UI 전체를 <b>화면에 늘려 붙인다.</b> 캔버스 바로 아래에 이 오브젝트를 두고
    /// 나머지 UI를 전부 그 안에 넣으면, UI가 한 장의 그림처럼 창 크기를 따라간다.
    ///
    /// <b>CanvasScaler로는 이걸 못 한다.</b> 스케일러가 정하는 배율은 가로·세로가 같은
    /// 값 하나뿐이라(Canvas가 그렇게 만든다) 화면 비율이 바뀌면 남는 쪽에 여백이 생기거나
    /// 모자란 쪽이 잘려나간다. 여기서는 가로·세로 배율을 <b>따로</b> 준다 —
    /// 가로로 늘리면 UI도 가로로 늘어나고, 세로로 줄이면 UI도 같이 눌린다.
    ///
    /// 그 대신 <b>비율이 보존되지 않는다.</b> 창을 심하게 찌그러뜨리면 글자와 동그란
    /// 아이콘도 같이 찌그러진다. 게임 화면과 UI가 한 몸으로 움직이는 대신 치르는 값이다.
    ///
    /// 부모 캔버스는 <c>Constant Pixel Size</c>(배율 1)여야 한다. 그래야 캔버스 좌표가
    /// 곧 화면 픽셀이 되어, 여기서 계산한 배율이 정확히 화면을 채운다.
    /// </summary>
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class StretchCanvasRoot : MonoBehaviour
    {
        [Tooltip("UI를 배치한 기준 해상도. 이 크기의 화면이라고 치고 배치한 뒤 실제 창 크기로 늘린다.")]
        [SerializeField] private Vector2 referenceResolution = new(1920f, 1080f);

        private void OnEnable() => Apply();

        // 창 크기는 아무 때나 바뀌고(브라우저 창 조절, 전체화면 토글) 콜백도 없다.
        // 매 프레임 확인하는 편이 확실하고, 값이 같으면 아무것도 하지 않으므로 비용도 없다.
        private void LateUpdate() => Apply();

        private void Apply()
        {
            if (referenceResolution.x <= 0f || referenceResolution.y <= 0f)
            {
                return;
            }

            var rt = (RectTransform)transform;

            // 항상 화면 중앙에 기준 해상도 크기로 둔다. 앵커를 늘려두면(0~1) 부모 크기를
            // 따라가버려서, 배율을 곱하는 순간 두 번 늘어난다.
            rt.anchorMin = new Vector2(0.5f, 0.5f);
            rt.anchorMax = new Vector2(0.5f, 0.5f);
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.anchoredPosition = Vector2.zero;
            rt.sizeDelta = referenceResolution;

            // 부모(캔버스) 크기를 기준으로 잡는다. Screen.width를 쓰면 게임 뷰가 아닌
            // 다른 크기로 그려지는 상황(에디터 미리보기 등)에서 어긋난다.
            float width = Screen.width;
            float height = Screen.height;
            if (rt.parent is RectTransform parent && parent.rect.width > 0f && parent.rect.height > 0f)
            {
                width = parent.rect.width;
                height = parent.rect.height;
            }

            var scale = new Vector3(width / referenceResolution.x, height / referenceResolution.y, 1f);
            if (rt.localScale != scale)
            {
                rt.localScale = scale;
            }
        }
    }
}
