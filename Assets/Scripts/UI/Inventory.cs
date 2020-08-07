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
            if (GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.SPIT) == 0) {
                spitBtn.gameObject.SetActive(false);
            }
        });
        
        kutchupBtn.onClick.AddListener(() => {
            if (GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.KUTCHUP) == 0) {
                kutchupBtn.gameObject.SetActive(false);
            }
        });
        
        mayonnaiseBtn.onClick.AddListener(() => {
            if (GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.MAYONNAISE) == 0) {
                mayonnaiseBtn.gameObject.SetActive(false);
            }
        });
        
        fridgeBtn.onClick.AddListener(() => {
            if (GameManager.instance.throwItem.MakeThrow(ThrowItem.ItemType.FRIDGE) == 0) {
                fridgeBtn.gameObject.SetActive(false);
            }
        });
    }
}
