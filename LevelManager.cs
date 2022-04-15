using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;

    private Level level;
    private GameObject levelGO;

    public int LevelIndex { get => PlayerPrefs.GetInt("LevelIndex", 1); set => PlayerPrefs.SetInt("LevelIndex", value); }
    public GameObject LevelGO { get => levelGO; set => levelGO = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        level = Resources.Load<Level>("Levels/Level" + LevelIndex);
        if (level != null)
        {
            LevelGO = Instantiate(level.LevelPrefab);
        }
        else
        {
            LevelIndex = 1;
            level = Resources.Load<Level>("Levels/Level" + LevelIndex);
            LevelGO = Instantiate(level.LevelPrefab);
        }
    }
}