using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blot : MonoBehaviour {
    [SerializeField] private float _ttlSec = 3f;

    private void OnEnable() {
        StartCoroutine(Misc.WaitAndDo(_ttlSec, () => {
            GameManager.instance.objectsPool.Add(Constants.ObjectPoolTags.BLOT, gameObject);
        }));
    }
}
