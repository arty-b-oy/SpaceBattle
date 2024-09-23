using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected EnemyModel _enemyModel;
    [SerializeField] protected EnemyView _enemyView;
    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
    public virtual void Initialized(float lives, float damage, float speed) 
    {
        _enemyModel = new EnemyModel(lives, damage, speed);
        _enemyView.Initialized();
    }
    public virtual void Appearance(Vector3 startPosition, Vector3 finishPosition, float delay)
    {
        StartCoroutine(_enemyView.Appearance(startPosition, finishPosition, _enemyModel.Speed, delay));
    }
    public virtual void Hit(float damage) 
    {
        _enemyModel.Lives -= damage;
        if (_enemyModel.Lives <= 0)
        {
            StartCoroutine(Death());
        }
        else
            _enemyView.Hit();
    }
    protected virtual IEnumerator Death() 
    {
        yield return _enemyView.Death();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _enemyModel.Lives = 0;
            StartCoroutine(Death());
        }
    }
}
