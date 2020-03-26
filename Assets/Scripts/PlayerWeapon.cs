using System;
using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    private String name = "Pump";
    private float damage = 40.0f;
    private float range = 10.0f;

    public float getRange()
    {
        return range;
    }
}
