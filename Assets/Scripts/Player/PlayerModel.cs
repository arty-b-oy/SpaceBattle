using UnityEngine;
using System;

public class PlayerModel 
{
    public int LevelPlayer {get => _playerData.LevelPlayer; }
    public float SpeedMove { get => _playerData.SpeedMove; }
    public float SpeedRotation { get => _playerData.SpeedRotation; }
    public int IdAmmunition { get => _playerData.IdAmmunition; }
    public Weapons Ammunition { get => _playerData.Ammunition; }
    public Transform AmmunitionTransform { get => _playerData.AmmunitionTransform; }
    private PlayerData _playerData;
    public PlayerModel()
    {
        _playerData = DataReader.ReadData<PlayerData>();
    }
    public void SetAmmunition(Transform ammunitionTransform)
    {
        if (_playerData.Ammunition != null)
            _playerData.Ammunition.DestroyAmmunition();
        _playerData.AmmunitionTransform = ammunitionTransform;
        _playerData.Ammunition = ammunitionTransform.GetComponent<Weapons>();
    }
}


