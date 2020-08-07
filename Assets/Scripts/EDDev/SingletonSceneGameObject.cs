using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSceneGameObject<Instance> : MonoBehaviour where Instance : SingletonSceneGameObject<Instance> {
    public static Instance instance;

    protected virtual void Awake() {
        if (instance == null) {
            instance = this as Instance;
        } else {
            Destroy(gameObject);
        }
    }
}
