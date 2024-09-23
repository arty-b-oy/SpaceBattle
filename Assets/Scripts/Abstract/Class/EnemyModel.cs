using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    public float Lives { get => _lives; 
                         set {
                                if(value<0)
                                    _lives = 0;
                                else
                                    _lives = value;
                             }   
                       }
    public float Damage { get => _damage; }
    public float Speed { get => _speed; }

    private float _lives = 10;
    private float _damage = 1;
    private float _speed = 1;
    public EnemyModel()
    {

    }
    public EnemyModel(float lives, float damage, float speed) 
    {
        _lives = lives > 0 ? lives: 10;
        _damage = damage > 0 ? damage : 1;
        _speed = speed > 0 ? speed : 1;
    }
}
