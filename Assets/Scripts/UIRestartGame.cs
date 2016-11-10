using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIRestartGame : MonoBehaviour, IPointerDownHandler {
    void Start () {
	}
    public void OnPointerDown(PointerEventData eventData) {
        GameController.RestartGame();
    }
}
