﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonGameObject<GameManager> {
    [Header("Set in inspector")] public PlayerController playerController;

    public float carsSpeed = 1f; // all cars have similar speed
}