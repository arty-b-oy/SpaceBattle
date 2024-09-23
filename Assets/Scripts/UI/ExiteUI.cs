using System;
using UnityEngine;

public class ExiteUI : PopUpUI
{
    public Action Return;
    public void ExiteGame() => Application.Quit();
    public void ReturnMain()
    {
        this.Disappearance();
        Return?.Invoke();
    }
}
