using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    [SerializeField] private Button spitBtn;
    [SerializeField] private Button mayonnaiseBtn;
    [SerializeField] private Button kutchupBtn;
    [SerializeField] private Button fridgeBtn;

    private void Start() {
        spitBtn.onClick.AddListener(() => {
            GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.SPIT);
        });
        
        kutchupBtn.onClick.AddListener(() => {
            GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.KUTCHUP);
        });
        
        mayonnaiseBtn.onClick.AddListener(() => {
            GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.MAYONNAISE);
        });
        
        fridgeBtn.onClick.AddListener(() => {
            GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.FRIDGE);
        });
    }
}
