using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Laser : Weapons
{
    private new const float _speed = 0.25f;
    private const float _stepXPosition = 0.6f;
    private const float _stepYPosition = 0.5f;
    private int _countForPosition = 0;


    public override void Shoot(int levelPlayer)
    {
        _countForPosition = 0;
        List<float> scaleAmmunition = new List<float>();
        for (int i = 0; i < levelPlayer; i++)
        {
            if (i % 2 == 0)
                scaleAmmunition.Add(1);
            else
                scaleAmmunition[i / 2] = 2;
        }
        Vector3 startPositions = new Vector3(0, 0, 0);
        if (scaleAmmunition[scaleAmmunition.Count - 1] == 1 && scaleAmmunition.Count > 1)
            scaleAmmunition[scaleAmmunition.Count - 2] = 1;

        if (scaleAmmunition.Count%2 == 0)
            NextPlace(ref startPositions);

        InstantiateAmmunition(scaleAmmunition, startPositions);
    }
    private void InstantiateAmmunition(List<float> scaleAmmunition, Vector3 startPositions)
    {
        for (int i = 0; i < scaleAmmunition.Count; i++)
        {
            var value = Instantiate(_prefabAmmunition);
            value.transform.localScale = Vector3.one * scaleAmmunition[i];
            value.transform.position = transform.position + startPositions;
            value.SetActive(true);
            value.GetComponent<Projectile>().SetMove(value.transform.position + new Vector3(0, 40, 0), _speed);
            NextPlace(ref startPositions);
        }
    }

    private void NextPlace(ref Vector3 position)
    {
        if (_countForPosition % 2 == 0)
        {
            position = new Vector3(-position.x, position.y, 0);
            position -= new Vector3(_stepXPosition, _stepYPosition, 0);
        }
        else
        {
            position = new Vector3(-position.x, position.y, 0);
        }
        _countForPosition++;
    }
}