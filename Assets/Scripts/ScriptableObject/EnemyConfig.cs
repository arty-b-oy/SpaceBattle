using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public EnemyData[] Enemys;
}

[Serializable]
public class EnemyData
{
    public EnemyController EnemyController;
    public float Lives;
    public float Damage;
    public float Speed;
}
