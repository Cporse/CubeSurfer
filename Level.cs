using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "New Level")]
public class Level : ScriptableObject
{
    [SerializeField] private GameObject levelPrefab;

    public GameObject LevelPrefab { get => levelPrefab; set => levelPrefab = value; }
}