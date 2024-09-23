using UnityEngine;
using Zenject;

public class ControllersInstall : MonoInstaller
{
    [SerializeField] private AudioController _audioController;
    [SerializeField] private GamePlayController _gamePlayController;
    [SerializeField] private GameEffectsController _gameEffectsController;
    [SerializeField] private UIController _uIController;
    [SerializeField] private PlayerController _playerController;
    public override void InstallBindings()
    {
        Container.Bind<AudioController>().FromInstance(_audioController).AsSingle().NonLazy();
        Container.Bind<GamePlayController>().FromInstance(_gamePlayController).AsSingle().NonLazy();
        Container.Bind<GameEffectsController>().FromInstance(_gameEffectsController).AsSingle().NonLazy();
        Container.Bind<UIController>().FromInstance(_uIController).AsSingle().NonLazy();

        var playerController = Container.InstantiatePrefabForComponent<PlayerController>(_playerController);
        Container.Bind<PlayerController>().FromInstance(playerController).AsSingle().NonLazy();
    }
}
