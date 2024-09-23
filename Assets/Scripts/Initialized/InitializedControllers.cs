using UnityEngine;
using Zenject;
public class InitializedControllers : MonoBehaviour
{
    [Inject] private AudioController _audioController;
    [Inject] private GamePlayController _gamePlayController;
    [Inject] private GameEffectsController _gameEffectsController;
    [Inject] private UIController _uIController;
    [Inject] private PlayerController _playerController;
    void Start()
    {
        _audioController.Initialized();
        _gamePlayController.Initialized();
        _gameEffectsController.Initialized();
        _uIController.Initialized();
        _playerController.Initialized();
    }
}
