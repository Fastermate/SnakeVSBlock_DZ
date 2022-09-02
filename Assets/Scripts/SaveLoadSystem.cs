using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    private const string LevelIndexKey = "LevelIndex";

    public void SaveLevel(int levelIndex)
    {
        PlayerPrefs.SetInt(LevelIndexKey, levelIndex);
    }

    public int GetLevelIndex()
    {
        return PlayerPrefs.GetInt(LevelIndexKey, 0);
    }
}
