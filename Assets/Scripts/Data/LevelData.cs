using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public int LevelId = 1;
    public int IDAppearance = 0;
    public int[] Enemys = new int[10] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
}
