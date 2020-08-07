using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ThrowItem : MonoBehaviour {
    public enum ItemType {
        SPIT, KUTCHUP, MAYONNAISE, FRIDGE
    }
    
    [SerializeField] private SlipInventoryItem kutchupItem;
    [SerializeField] private SlipInventoryItem mayonnaiseItem;
    [SerializeField] private SlipInventoryItem spitItem;
    
    [SerializeField] private float _throwRange = 10f;
    [SerializeField] private GameObject _blotPrefab;

    // optimization
    private RaycastHit _oRaycastHit;
    
    public void MakeThrow(ItemType type) {
        GameObject blotObj = GameManager.instance.objectsPool.Get(Constants.ObjectPoolTags.BLOT);
        if (blotObj == null) {
            blotObj = Instantiate(_blotPrefab);
        }

        Vector3 posOnRoad = GetPositionOnRoad(transform.position + transform.forward * _throwRange);

        blotObj.transform.position = posOnRoad;
        GetInventoryItem(type).UseItemOnPosition(posOnRoad);
    }

    private Vector3 GetPositionOnRoad(Vector3 position) {
        Debug.DrawRay(position, Vector3.down * 100, Color.blue, 3f);
        if (Physics.Raycast(position, Vector3.down, out _oRaycastHit, 100f, GameManager.instance.whatIsRoad)) {
            return _oRaycastHit.point;
        }

        return Vector3.zero;
    }

    private AbstractInventoryItem GetInventoryItem(ItemType type) {
        switch (type) {
            case ItemType.SPIT: {
                return spitItem;
            }
            case ItemType.KUTCHUP: {
                return kutchupItem;
            }
            case ItemType.MAYONNAISE: {
                return mayonnaiseItem;
            }
            case ItemType.FRIDGE: {
                return spitItem;
            }
        }

        return spitItem;
    }
}
