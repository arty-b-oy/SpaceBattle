using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
public class PlayerController : MonoBehaviour, IShoot, IMove
{
    [Inject] private ArsenalConfig _arsenalConfig;
    [SerializeField] private PlayerView _playerView;
    private PlayerModel _playerModel;
    private InputSystem _input;
    private Coroutine _moveCoroutine;
    private Coroutine _shootCoroutine;
    public Action PlayerArrived;
    public void Initialized()
    {
        _playerModel = new PlayerModel();
        _playerView.Initialized();
        var ammunition = Instantiate(_arsenalConfig.Weapons[_playerModel.IdAmmunition].gameObject);
        _playerModel.SetAmmunition(ammunition.transform);
        _playerView.SetWeapons(_playerModel.AmmunitionTransform);

        _input = new InputSystem();
        _input.Player.Shoot.performed += ShootInput;
    }
    private IEnumerator Move()
    {
        while (true)
        {
            _playerView.AddMove(_input.Player.Move.ReadValue<Vector2>(),
                                _playerModel.SpeedMove,
                                _playerModel.SpeedRotation);
            yield return null;
        }
    }
    private void ShootInput(InputAction.CallbackContext obj)
    {
        if (_shootCoroutine == null)
            _shootCoroutine = StartCoroutine(Shoot());
        else
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
            
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            _playerModel.Ammunition.Shoot(_playerModel.LevelPlayer);
            _playerView.Shoot();
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void StartGame()
    {
        StartCoroutine(Appearance());
    }
    public IEnumerator Appearance()
    {
        yield return _playerView.Appearance(_playerModel.SpeedMove,
                                            _playerModel.SpeedRotation);
        PlayerArrived?.Invoke();
        EnableInputSystem();
        EnableMove();
    }

    private void OnApplicationQuit() => StopAllCoroutines();
    public void EnableInputSystem() => _input.Enable();
    public void DisableInputSystem() => _input.Disable();
    public void EnableMove() 
    {
        if (_moveCoroutine != null)
            DisableMove();
        _moveCoroutine = StartCoroutine(Move());
    } 
    public void DisableMove()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
    }
}
