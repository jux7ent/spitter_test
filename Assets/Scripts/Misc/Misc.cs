using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc : MonoBehaviour {
    public static IEnumerator LoopWithDelay(float iterationDelay, System.Action action) {
        while (true) {
            action();
            yield return new WaitForSeconds(iterationDelay);
        }
    }

    public static IEnumerator LoopWhile(System.Func<bool> waitCondition, System.Action action, float checkDelay = 0) {
        while (waitCondition()) {
            action();
            yield return new WaitForSeconds(checkDelay);
        }
    }

    public static IEnumerator WaitAndDo(float delay, System.Action action) {
        yield return new WaitForSeconds(delay);
        action();
    }

    public static IEnumerator WaitWhile(System.Func<bool> waitCondition, System.Action action, float checkDelay=0) {
        while (waitCondition()) {
            yield return new WaitForSeconds(checkDelay);
        }

        action();
    }
    
    public static float GetAngle(Vector2 v1, Vector2 v2) {
        var sign = Mathf.Sign(v1.x * v2.y - v1.y * v2.x);
        return 360f - Vector2.Angle(v1, v2) * sign;
    }

    public static bool CheckLayerMasks(int objectLayer, LayerMask mask) {
        return ((1 << objectLayer) & mask) != 0;
    }

    public static GameObject FindNearestGameObjectWithTag(Vector3 point, string tag, GameObject[] objects=null) {
        if (objects == null) {
            objects = GameObject.FindGameObjectsWithTag(tag);
        }
        float minDist = Mathf.Infinity;

        GameObject result = null;
        
        for (int i = 0; i < objects.Length; ++i) {
            float dist = Vector3.Distance(objects[i].transform.position, point);
            if (dist < minDist) {
                result = objects[i];
                minDist = dist;
            }
        }

        return result;
    }
}
