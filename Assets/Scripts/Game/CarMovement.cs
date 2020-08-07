using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    [SerializeField] private LayerMask _whatIsRoad;

    private string _opTag;
    
    private bool _isTurning = false;
    
    // optimization
    private RaycastHit _oRaycastHit;

    private void OnEnable() {
        _isTurning = false;
        CheckAndSetDirectionByGround(true); // after obj pool should set rotation
    }
    
    private void Update() {
        MoveForward();
    }

    public void SetTagForObjectsPool(string opTag) {
        _opTag = opTag;
    }

    private void CheckAndSetDirectionByGround(bool instant=false) {
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out _oRaycastHit, 1f, _whatIsRoad)) {
            if (!_isTurning) {
               if (instant) {
                   transform.localEulerAngles = _oRaycastHit.collider.transform.parent.transform.localEulerAngles +
                                                Vector3.up * -90;
               } else {
                   StartCoroutine(StartTurn(_oRaycastHit.collider.transform.parent.transform.localEulerAngles +
                                            Vector3.up * -90));
               }
           }
        }
    }

    private void MoveForward() {
        transform.position =
            transform.position +
            transform.forward * Time.deltaTime * GameManager.instance.carsSpeed; // -transform.right = forward
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Constants.Tags.CHANGE_DIRECTION_TRIGGER)) {
            CheckAndSetDirectionByGround();
        } else if (other.CompareTag(Constants.Tags.DEATH_ZONE)) {
            GameManager.instance.objectsPool.Add(_opTag, gameObject);
        }
    }

    private IEnumerator StartTurn(Vector3 endAngles) {
        _isTurning = true;
        Debug.Log($"{transform.localEulerAngles.y} : {endAngles.y} : {Mathf.DeltaAngle(transform.localEulerAngles.y, endAngles.y)}");
        while (Mathf.Abs(Mathf.DeltaAngle(transform.localEulerAngles.y, endAngles.y)) > 0.1f) {
            Vector3 angles = transform.localEulerAngles;
            angles.y = Mathf.LerpAngle(angles.y, endAngles.y, 0.125f);
            transform.localEulerAngles = angles;

            yield return null;
        }

        _isTurning = false;
    }
}
