using UnityEngine;
using Zenject;

public class ConfigInstall : MonoInstaller
{
    [SerializeField] private AudioConfig _audioConfig;
    [SerializeField] private ArsenalConfig _arsenalConfig;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private GamePlayConfig _gamePlayConfig;
    public override void InstallBindings()
    {
        Container.Bind<AudioConfig>().FromInstance(_audioConfig).AsSingle().NonLazy();
        Container.Bind<ArsenalConfig>().FromInstance(_arsenalConfig).AsSingle().NonLazy();
        Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle().NonLazy();
        Container.Bind<GamePlayConfig>().FromInstance(_gamePlayConfig).AsSingle().NonLazy();
    }
}