using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform parentRect;

    private Vector2 basePos;
    private Vector2 startPos;
    private Vector2 moveOffset;

    void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling(); // 위에 그려지도록 설정

        basePos = parentRect.anchoredPosition; // 기존 UI의 위치
        startPos = eventData.position; // 시작점
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos; // 드래그한 상태의 Dir
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}