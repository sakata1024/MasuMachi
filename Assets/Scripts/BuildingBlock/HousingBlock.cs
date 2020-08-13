using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 住宅街オブジェクト
/// 簡単に置ける。人が増えるほど満足度が下がりやすい
/// </summary>
public class HousingBlock : BuildingBlockObject
{
    protected override void Start()
    {
        buildingBlock = new Housing();
        blockList.Add(new Vector2Int(0, 0));
        scale = 1f;
        base.Start();
    }
    
}

public class Housing : BuildingBlock
{
    public Housing()
    {
        populationTerm = 100;
        moneyTerm = 20000;
    }
}
