using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

abstract public class PopUpUI : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Vector3 _positionForAppearance = Vector3.zero;
    [SerializeField] private  Vector3 _positionForDisappearance = new Vector3(0, 1000, 0);
    [SerializeField] private bool isActivInStart = false;
    [SerializeField] private Transform _bodyTransform;
    public virtual void Initialized()
    {
        if (_bodyTransform == null)
            _bodyTransform = transform;
        if (isActivInStart)
        {
            _bodyTransform.localPosition = _positionForAppearance;
            EnableButton();
        }
        else
        {
            _bodyTransform.localPosition = _positionForDisappearance;
            DisableButton();
        }
    }
    public virtual void Appearance(Action funcAfterAnimation = default(Action), float time = 0.5f)
    {
        _bodyTransform.DOLocalMove(_positionForAppearance, time).SetEase(Ease.Linear)
                                                               .OnComplete(()=> 
                                                               {
                                                                   funcAfterAnimation?.Invoke();
                                                                   EnableButton();
                                                               });
    }
    public virtual void Disappearance(Action funcAfterAnimation = default(Action), float time = 0.5f)
    {
        DisableButton();
        _bodyTransform.DOLocalMove(_positionForDisappearance, time).SetEase(Ease.Linear)
                                                                  .OnComplete(() => funcAfterAnimation?.Invoke());
    }
    protected virtual void EnableButton()
    {
        foreach (var item in buttons)
            item.enabled = true;
    }
    protected virtual void DisableButton()
    {
        foreach (var item in buttons)
            item.enabled = false;
    }
}