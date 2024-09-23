using System.Collections;
using UnityEngine;
using Zenject;
public class GamePlayController : MonoBehaviour
{
    [Inject] private UIController _uIController;
    [Inject] private PlayerController _playerController;
    [SerializeField] private EnemyFactory _enemyFactory;
    public void Initialized()
    {
        _uIController.StartGameLevel += StartLevel;
    }

    public void StartLevel(int Level)
    {
        StartCoroutine(LoadLevel(Level));
    }
    public IEnumerator LoadLevel(int Level)
    {
        LevelData LevelData = DataReader.ReadData<LevelData>(typeof(LevelData).Name + Level.ToString(), "LevelData/");
        print(JsonUtility.ToJson(LevelData));
        yield return StartCoroutine(_playerController.Appearance());
        _enemyFactory.CreateEnemys(LevelData);
    }
    private void OnDisable()
    {
        _uIController.StartGameLevel -= StartLevel;
    }
}
