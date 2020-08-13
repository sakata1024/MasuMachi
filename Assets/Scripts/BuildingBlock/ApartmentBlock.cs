using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マンションオブジェクト
/// 人口の増加率が上がる。満足度はそこそこ下がる
/// </summary>
public class ApartmentBlock : BuildingBlockObject
{

    protected override void Start()
    {
        buildingBlock = new Apartment();
        blockList.Add(new Vector2Int(0, 0));
        blockList.Add(new Vector2Int(1, 0));
        scale = 0.5f;
        base.Start();
    }
    
}

public class Apartment : BuildingBlock
{
    public Apartment()
    {
        populationTerm = 1000;
        moneyTerm = 200000;
    }
}
