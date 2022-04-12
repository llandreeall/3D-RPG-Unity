using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;
    private Text tooltiptext;
    private RectTransform backgroundRectTrans;
    private void Awake()
    {
        backgroundRectTrans = transform.Find("BG").GetComponent<RectTransform>();
        tooltiptext = transform.Find("Text").GetComponent<Text>();
    }
    public void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltiptext.text = tooltipString;
        float textPad = 4f;
        Vector2 size = new Vector2(tooltiptext.preferredWidth + textPad * 2, tooltiptext.preferredHeight + textPad * 2);
        backgroundRectTrans.sizeDelta = size;

    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }
}
