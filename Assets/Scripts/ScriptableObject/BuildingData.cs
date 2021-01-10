using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BuildingData")]
public class BuildingData : ScriptableObject
{
    public BuildingType buildingType = BuildingType.None;
    public Vector2Int size;
    public List<BuildingBlockData> buildingBlockDataList = new List<BuildingBlockData>();
}

[System.Serializable]
public class BuildingBlockData
{
    public Sprite buildingImage;
    public Vector2Int pos;
}
