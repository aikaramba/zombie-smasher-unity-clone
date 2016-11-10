using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIBomb : MonoBehaviour, IPointerDownHandler {
    void Start () {
	}
    public void OnPointerDown(PointerEventData eventData) {
        if(GameController.AreBombsAvailable())
            GameController.DetonateBomb();
    }
}
