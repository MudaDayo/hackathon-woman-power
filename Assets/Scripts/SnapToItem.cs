using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SnapToItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel, sampleListItem;

    public VerticalLayoutGroup vlg;

    public float minSpeed;

    private bool isSnapped = false;
    private bool isDragging = false;

    public float snapForce, snapSpeed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollRect.velocity.magnitude < minSpeed && !isSnapped && !isDragging)
        {
            SnapToClosestItem();
        }
        if (scrollRect.velocity.magnitude > minSpeed)
        {
            isSnapped = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isSnapped = false;
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        SnapToClosestItem();
    }

    private void SnapToClosestItem()
    {
        int currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.y / (sampleListItem.rect.height + vlg.spacing)));
        scrollRect.velocity = Vector2.zero;
        contentPanel.localPosition = new Vector3(contentPanel.localPosition.x, Mathf.MoveTowards(contentPanel.localPosition.y, 0 - currentItem * (sampleListItem.rect.height + vlg.spacing), snapSpeed * Time.deltaTime), contentPanel.localPosition.z);
        if (Mathf.Approximately(contentPanel.localPosition.y, 0 - currentItem * (sampleListItem.rect.height + vlg.spacing)))
        {
            isSnapped = true;
        }
    }
}
