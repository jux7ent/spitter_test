using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonGameObject<GameManager> {
    [Header("Set in inspector")] public PlayerController playerController;

    public float carsSpeed = 1f; // all cars have similar speed
    public LayerMask whatIsRoad;
    public ObjectsPool objectsPool = new ObjectsPool();
    public Level level;
    public ThrowItem throwItem;

    private void Start() {
        StartCoroutine(Misc.LoopWithDelay(6f, level.SpawnCar));
    }
}