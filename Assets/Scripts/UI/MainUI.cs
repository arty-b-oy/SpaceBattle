using System;
using UnityEngine;

public class MainUI : PopUpUI
{
    [SerializeField] private ExiteUI _exiteUI;
    [SerializeField] private LevelSelectionUI _levelSelectionUI;
    public delegate void StartGame(int Level);
    public StartGame StartSelectGame;
    public override void Initialized()
    {
        base.Initialized();
        _exiteUI.Initialized();
        _levelSelectionUI.Initialized();
        _exiteUI.Return += ReturtMain;
        _levelSelectionUI.StartSelctLevel += StartLevel;
    }
    public void SetData(int numberLevels, int gameProgres) => _levelSelectionUI.SetData(numberLevels, gameProgres);
    private void ReturtMain() => Appearance();
    public void StartLevel(int level) => StartSelectGame?.Invoke(level);
    public void SelectLevelButton()
    {
        Disappearance();
        _levelSelectionUI.Appearance();
    }
    public void ExiteButton()
    {
        Disappearance();
        _exiteUI.Appearance();
    }
    private void OnDisable()
    {
        _exiteUI.Return -= ReturtMain;
        _levelSelectionUI.StartSelctLevel -= StartLevel;
    }
}