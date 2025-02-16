using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnapToItem : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel, sampleListItem;

    public HorizontalLayoutGroup hlg;

    public TMP_Text NameLabel;

    public string[] names;

    private bool isSnapped = false;

    public float snapForce, snapSpeed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentItem = Mathf.RoundToInt((0-contentPanel.localPosition.y/(sampleListItem.rect.height + hlg.spacing)));

        if(scrollRect.velocity.magnitude < 200 && !isSnapped){
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(contentPanel.localPosition.x, Mathf.MoveTowards(contentPanel.localPosition.y, 0-currentItem * (sampleListItem.rect.height + hlg.spacing), snapSpeed), contentPanel.localPosition.z);
            if(contentPanel.localPosition.x == 0-currentItem * (sampleListItem.rect.height + hlg.spacing)){
                isSnapped = true;
            }
        }
        if(scrollRect.velocity.magnitude > 200){
            isSnapped = false;
            snapSpeed = 0;
        }
    }
}
