using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _upEffect;
    [SerializeField] private ParticleSystem _downEffect;
    [SerializeField] private ParticleSystem _leftEffect;
    [SerializeField] private ParticleSystem _rightEffect;
    [SerializeField] private Transform _bodyTransform;
    [SerializeField] private Transform _weaponsPlace;
    private float _xRot = 0;
    private float _yRot = 0;
    private Vector3 _initializedPosition = new Vector3(0, -15, 0);
    private const float startYPosition = -7;
    private const float MaxEvasion = 20f;

    public void Initialized()
    {
        transform.position = _initializedPosition;
    }
    public IEnumerator Appearance(float speed, float speedRotation)
    {
        while (transform.position.y < startYPosition)
        {
            AddMove(Vector2.up, speed, speedRotation);
            yield return null;
        }
    }
    public void Disappearance()
    {

    }
    public void AddMove(Vector2 forsVector, float speed, float speedRotation)
    {
        GetComponent<Rigidbody>().AddForce(forsVector * Time.deltaTime * speed, ForceMode.Impulse);
        RotationFromMotion(forsVector, speedRotation);
    }
    
    private void RotationFromMotion(Vector2 forsVector, float speedRotation)
    {
        GetSpin(ref _xRot, forsVector.x, speedRotation);
        GetSpin(ref _yRot, forsVector.y, speedRotation);
        SpinEffect(new Vector2(_xRot, _yRot));
        transform.DORotate(new Vector3(-_yRot, _xRot, transform.eulerAngles.z), Time.deltaTime);
    }
    private void GetSpin(ref float rot, float forsFloat, float speedRotation)
    {
        rot -= forsFloat * Time.deltaTime * speedRotation;
        if (rot > MaxEvasion)
            rot = MaxEvasion;
        if (rot < -MaxEvasion)
            rot = -MaxEvasion;
        if (forsFloat == 0)
            rot += -rot * Time.deltaTime * speedRotation / MaxEvasion;
    }

    private float effectLimit = 3;
    private void SpinEffect(Vector2 forsVector)
    {
        if (forsVector.y < -effectLimit && !_upEffect.isPlaying)
            _upEffect.Play();
        if (forsVector.y >= -effectLimit)
            _upEffect.Stop();

        if (forsVector.y > effectLimit && !_downEffect.isPlaying)
            _downEffect.Play();
        if (forsVector.y <= effectLimit)
            _downEffect.Stop();


        if (forsVector.x < -effectLimit && !_leftEffect.isPlaying)
            _leftEffect.Play();
        if (forsVector.x >= -effectLimit)
            _leftEffect.Stop();

        if (forsVector.x > effectLimit && !_rightEffect.isPlaying)
            _rightEffect.Play();
        if (forsVector.x <= effectLimit)
            _rightEffect.Stop();
    }

    public void Shoot()
    {
        _bodyTransform.DOLocalMoveX(0.15f, 0.05f).OnComplete(() =>
                                                          {
                                                              _bodyTransform.DOLocalMoveX(0f, 0.1f).SetEase(Ease.Linear);
                                                          }).SetEase(Ease.Linear);
    }
    public void SetWeapons(Transform weapons)
    {
        weapons.parent = _weaponsPlace;
        weapons.localPosition = Vector3.zero;
    }
}
