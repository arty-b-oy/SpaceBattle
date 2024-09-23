using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelButtonUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI textMesh;
    private int _level;
    public delegate void LevelClick(int level);
    public LevelClick levelClick;
    private bool _isActiveLevel;
    public void SetData(int level, bool isActive = true)
    {
        _level = level;
        _isActiveLevel = isActive;
        button.onClick.AddListener(() => levelClick?.Invoke(_level));
        button.enabled = isActive;
        textMesh.text = level.ToString();
        if (!isActive)
        {
            textMesh.color = Color.black;
            image.color = Color.black;
        }
    }
    public void EnableButton() 
    {
        if(_isActiveLevel)
            button.enabled = true;
    } 
    public void DisableButton()
    {
        if(_isActiveLevel)
            button.enabled = false;
    }

}
