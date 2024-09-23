using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotView : EnemyView
{
    [SerializeField] private GameObject explozeonEffect;
    private Sequence hitAnimation;
    public override IEnumerator Death()
    {
        base.Death();
        var deathEffect = Instantiate(explozeonEffect);
        deathEffect.transform.position = transform.position;
        Destroy(gameObject);
        yield return null;
    }
    public override void Hit()
    {
        hitAnimation?.Kill();
        hitAnimation = DOTween.Sequence().Append(bodyTransform.DOLocalMoveY(0.2f, 0.1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
    }
    public override void IdleState()
    {
        base.IdleState();
        idleAnimation = DOTween.Sequence().Append(bodyTransform.DOScale(0.95f, 2f).SetLoops(-1, LoopType.Yoyo));
    }
}
