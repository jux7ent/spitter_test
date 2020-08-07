using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    private string _opTag;
    private Vector3 _additionVector = Vector3.up * -90; // our world inverted on this vector
    private bool _isTurning = false;

    private bool _engineOn = true;
    
    [SerializeField] private Rigidbody _rigidbody;
    
    // optimization
    private RaycastHit _oRaycastHit;

    private void OnEnable() {
        _engineOn = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        
        _isTurning = false;
     //   CheckAndSetDirectionByGround(true); // after obj pool should set rotation
       // transform.position = GameManager.instance.level.GetSpawnerPositionInRange(transform.position, 2f);
       StartCoroutine(Misc.WaitAndDo(0.01f, () => CheckAndSetDirectionByGround(true)));
    }
    
    private void Update() {
        if (_engineOn) {
            MoveForward();
        }
    }

    public void SetTagForObjectsPool(string opTag) {
        _opTag = opTag;
    }

    public void Slip() { // some slipping realisation
        StartCoroutine(StartTurn(Vector3.up * 230f + _additionVector, 0.05f));
        StartCoroutine(Misc.WaitWhile(() => _isTurning, () => {
            _engineOn = false;
            StartCoroutine(Misc.WaitAndDo(2f, () => GameManager.instance.objectsPool.Add(_opTag, gameObject)));
        }));
    }

    private void CheckAndSetDirectionByGround(bool instant=false) {
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out _oRaycastHit, 1f, GameManager.instance.whatIsRoad)) {
            if (!_isTurning) {
               if (instant) {
                   transform.localEulerAngles = 
                       _oRaycastHit.collider.transform.parent.transform.localEulerAngles + _additionVector;
               } else {
                   StartCoroutine(StartTurn(_oRaycastHit.collider.transform.parent.transform.localEulerAngles +
                                            _additionVector));
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

    private IEnumerator StartTurn(Vector3 endAngles, float lerpCoeff=0.125f) {
        _isTurning = true;
        while (Mathf.Abs(Mathf.DeltaAngle(transform.localEulerAngles.y, endAngles.y)) > 0.1f) {
            Vector3 angles = transform.localEulerAngles;
            angles.y = Mathf.LerpAngle(angles.y, endAngles.y, lerpCoeff);
            transform.localEulerAngles = angles;

            yield return null;
        }

        _isTurning = false;
    }
}
