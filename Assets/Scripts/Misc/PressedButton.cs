using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public Action OnPointerPressDelegate;

    private bool _isPressed = false;

    public void Update() {
        if (_isPressed) {
            OnPointerPressDelegate?.Invoke();
        }
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        _isPressed = false;
    }
}
