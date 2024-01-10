using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class MenuAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;
    Image image;
    TextMeshProUGUI text;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        rectTransform.localScale = new Vector3(1f, 1f);
        image.color = Color.white;
        text.fontSize = 40;
        text.color = Color.black;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = new Vector3(1.05f, 1.05f);
        image.color = Color.red;
        text.fontSize = 50;
        text.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = new Vector3(1f, 1f);
        image.color = Color.white;
        text.fontSize = 40;
        text.color = Color.black;
    }
}
