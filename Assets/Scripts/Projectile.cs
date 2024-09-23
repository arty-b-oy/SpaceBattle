using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    private Sequence moveAnimation;
    public void SetMove(Vector3 position, float speed) =>
        DOTween.Sequence().Append( transform.DOMove(position, 1 / speed).OnComplete(() => Destroy(this.gameObject)));
    private void OnCollisionEnter(Collision collision)
    {
        print("Collision");
        if (collision.transform.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Trigge");
        if (other.transform.tag == "Enemy")
        {
            moveAnimation?.Kill();
            other.GetComponent<EnemyController>().Hit(1);
            Destroy(gameObject);
        }
    }
}
