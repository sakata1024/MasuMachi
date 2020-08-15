using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/AllLevelData")]
public class AllLevelData : ScriptableObject
{
    public List<LevelData> _allLevelData = new List<LevelData>();

    public LevelData GetLevelData(Level level)
    {
        return _allLevelData.Where(l => l.level == level).FirstOrDefault();
    }
}
