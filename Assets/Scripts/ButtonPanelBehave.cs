using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPanelBehave : MonoBehaviour, IPointerExitHandler {

    public GameObject canvas;

    public void OnPointerExit(PointerEventData eventData)
    {
        canvas.GetComponent<UIMAnager1>().activeButtonPanel = 0;
        gameObject.SetActive(false);
    }
}
