using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int LevelPlayer = 1;
    public int IdAmmunition = 0;
    public int GameProgress = 1;
    [NonSerialized] public float SpeedMove = 60f;
    [NonSerialized] public float SpeedRotation = 60f;
    [NonSerialized] public Weapons Ammunition;
    [NonSerialized] public Transform AmmunitionTransform;
}