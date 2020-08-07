using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _minZPos = -1f;
    [SerializeField] private float _maxZPos = 1f;

    public void MoveLeft() {
        MoveDirection(-1);
    }

    public void MoveRight() {
        MoveDirection(1);    
    }
    
    private void MoveDirection(float zDirection) {
        Vector3 position = transform.position;

        float endZ = position.z + zDirection * Time.deltaTime * _movementSpeed;
        position.z = Mathf.Clamp(endZ, _minZPos, _maxZPos);
        
        transform.position = position;
    }
}
