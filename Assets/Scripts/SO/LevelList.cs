using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "Configs/LevelList", order = 0)]
public class LevelList : ScriptableObject
{
    public GameObject[] Levels;
}
