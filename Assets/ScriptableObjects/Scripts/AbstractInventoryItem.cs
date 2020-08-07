using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInventoryItem : ScriptableObject {
    public bool isLiquid = false;
    public int capacity = 1;
    [NonSerialized] public int amount = 0;

    public abstract void UseItemOnPosition(Vector3 position);
}
