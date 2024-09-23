using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Rocket : Weapons
{
    private new const float _speed = 0.2f;

    public override void Shoot(int levelPlayer)
    {
        var value = Instantiate(_prefabAmmunition);
        value.transform.position = transform.position;
        value.transform.localScale = Vector3.one * (1 + levelPlayer/20f);
        value.SetActive(true);
        value.GetComponent<Projectile>().SetMove(value.transform.position + new Vector3(0,40,0), _speed);
    }
}
