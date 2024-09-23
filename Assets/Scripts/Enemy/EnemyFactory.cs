using System.Collections;
using UnityEngine;
using Zenject;
public class EnemyFactory : MonoBehaviour
{
    [Inject] private EnemyConfig _enemyConfig;
    private const float WidthArena = 30;
    private const float HeigthArena = 17;
    private const float StepX = WidthArena / 11;
    private const float StepY = WidthArena / 2/8;
    private const int NumberEnemiesLine = 12;
    private const int NumberEnemiesColumn = 6;
    
    public void CreateEnemys(LevelData LevelData)
    {
        int counteEnemys = 0;
        EnemyController[,] enemys = new EnemyController[NumberEnemiesLine, NumberEnemiesColumn];
        for (int i = 0; i < enemys.GetLength(0); i++)
        {
            for (int j = 0; j < enemys.GetLength(1); j++)
            {
                int IdEnemy = LevelData.Enemys[counteEnemys];
                if(IdEnemy != -1)
                {
                    var enemy = Instantiate(_enemyConfig.Enemys[IdEnemy].EnemyController);
                    enemy.Initialized(_enemyConfig.Enemys[IdEnemy].Lives,
                                      _enemyConfig.Enemys[IdEnemy].Damage,
                                      _enemyConfig.Enemys[IdEnemy].Speed);
                    enemys[i, j] = enemy;
                }
                counteEnemys++;
            }
        }
        
        switch (LevelData.IDAppearance)
        {
            case 0:
                AnimateFirstWay(enemys);
                break;
            default:
                AnimateFirstWay(enemys);
                break;
        }
    }

    public void AnimateFirstWay(EnemyController[,] enemys)
    {

        Vector3 stepX = new Vector3(StepX, 0, 0);
        Vector3 stepY = new Vector3(0, -StepY, 0);

        Vector3 startPosition = new Vector3(-WidthArena / 2, HeigthArena / 2 + 5, 0);
        float delay;
        float stepDelay = 0.6f;
        for (int i = 0; i < enemys.GetLength(0); i++)
        {
            delay = stepDelay* enemys.GetLength(1);
            Vector3 finishPosition = new Vector3(-WidthArena / 2, HeigthArena / 2, 0)+ stepX * i;
            for (int j = 0; j < enemys.GetLength(1); j++)
            {
                if (enemys[i, j] != null)
                    enemys[i, j].Appearance(startPosition, finishPosition, delay);
                finishPosition += stepY;
                delay -= stepDelay;

            }
            startPosition += stepX;
        }
    }

}
