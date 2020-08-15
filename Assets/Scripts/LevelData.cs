using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public enum Level
{
    Beginner,
    Elite,
    Pro
}

[CreateAssetMenu(menuName = "ScriptableObject/LevelData")]
public class LevelData : ScriptableObject
{
    public Level level;
    public int stageSize;
    public float firstPopulation;
    public float firstMoney;
    public float firstHappy;
    public float targetPopulation;
    public float targetMoney;
    public float targetHappy;
}
