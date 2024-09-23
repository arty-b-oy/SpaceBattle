using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class EnemyView : MonoBehaviour
{
    [SerializeField] protected Collider colliders;
    [SerializeField] protected Transform bodyTransform;
    private Sequence initializedAnimation;
    protected Sequence idleAnimation;
    public virtual void Initialized()
    {
    }
    public virtual IEnumerator Appearance(Vector3 startPosition, Vector3 finishPosition, float speed, float delay) 
    {
        transform.position = startPosition;
        yield return new WaitForSeconds(delay);
        IdleState();
        float distanse = Vector3.Distance(transform.position, finishPosition);
        initializedAnimation = DOTween.Sequence().Append(transform.DOMove(finishPosition, distanse / speed).SetEase(Ease.Linear));
    }
    public virtual void IdleState()
    {

    }
    public virtual void Hit() 
    {

    }
    public virtual IEnumerator Death() 
    {
        initializedAnimation?.Kill();
        idleAnimation?.Kill();
        yield return null;
    }
}
