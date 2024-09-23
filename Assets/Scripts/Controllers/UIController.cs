using System;
using UnityEngine;
using Zenject;
public class UIController : MonoBehaviour
{
    [Inject] private GamePlayConfig _gamePlayConfig;
    [SerializeField] private Transform _canvas;
    [SerializeField] private MainUI _mainUI;
    public delegate void StartGame(int Level);
    public StartGame StartGameLevel;
    public void Initialized()
    {
        _mainUI.Initialized();
        PlayerData playerData = DataReader.ReadData<PlayerData>();
        _mainUI.SetData(_gamePlayConfig.NumberLevels, playerData.GameProgress);
        _mainUI.StartSelectGame += StartLevel;
    }
    private void StartLevel(int level) => StartGameLevel?.Invoke(level);

    private void OnDisable()
    {
        _mainUI.StartSelectGame -= StartLevel;
    }
}
 