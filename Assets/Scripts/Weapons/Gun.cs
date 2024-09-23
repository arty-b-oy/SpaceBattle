using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gun : Weapons
{
    private const float _angleBetweenProjectiles = 15;

    public override void Shoot(int levelPlayer)
    {
        float angle = -(levelPlayer / 2) * _angleBetweenProjectiles;
        angle += (1- levelPlayer % 2)* _angleBetweenProjectiles/2f;
        for (int i = 0; i < levelPlayer; i++)
        {
            var value = Instantiate(_prefabAmmunition);
            value.transform.position = transform.position;
            value.SetActive(true);
            float _yMovePosition = 40 * Mathf.Cos(angle * Mathf.PI / 180f);
            float _xMovePosition = 40 * Mathf.Sin(angle * Mathf.PI / 180f);
            value.GetComponent<Projectile>().SetMove(value.transform.position + new Vector3(_xMovePosition, _yMovePosition, 0), _speed);

            angle += _angleBetweenProjectiles;
        }
    }
}
