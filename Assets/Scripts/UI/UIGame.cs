using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour {
    [SerializeField] private PressedButton _leftMovementBtn;
    [SerializeField] private PressedButton _rightMovementBtn;

    private void Start() {
        _leftMovementBtn.OnPointerPressDelegate += GameManager.instance.playerController.MoveLeft;
        _rightMovementBtn.OnPointerPressDelegate += GameManager.instance.playerController.MoveRight;
    }

    private void Update() {
    }
}
