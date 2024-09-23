using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelectionUI : PopUpUI
{
    [SerializeField] private LevelButtonUI _levelButtonPrefab;
    [SerializeField] private Transform _placeLevelUi;
    private List<LevelButtonUI> _levelbuttons = new List<LevelButtonUI>();
    public delegate void StartLevel(int level);
    public StartLevel StartSelctLevel;
    public void SetData(int numberLevels, int gameProgres)
    {
        int counter = 1;
        while (counter<=numberLevels)
        {
            LevelButtonUI levelButton = Instantiate(_levelButtonPrefab, _placeLevelUi);
            _levelbuttons.Add(levelButton);
            levelButton.SetData(counter, counter <= gameProgres);
            levelButton.levelClick += SelectLevel;
            counter++;
        }
    }
    public void SelectLevel(int numberLevel)
    {
        Disappearance();
        StartSelctLevel?.Invoke(numberLevel);
    }
    private void OnDisable()
    {
        foreach (var item in _levelbuttons)
            item.levelClick -= SelectLevel;
    }
    protected override void EnableButton()
    {
        foreach (var item in _levelbuttons)
            item.EnableButton();
    }
    protected override void DisableButton()
    {
        foreach (var item in _levelbuttons)
            item.DisableButton();
    }
}
