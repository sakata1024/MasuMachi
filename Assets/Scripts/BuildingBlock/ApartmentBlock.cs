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
        moneyTerm = 100000;
    }

    public override void OnSetAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -100000, changePopulationRate: 1.6f, changeMoneyRate: 2f, changeHappyRate: 0.9f);
    }

    public override void OnUpdateAction()
    {
        
    }

    public override void OnDestroyAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -50000, changePopulationRate: 1/1.6f, changeMoneyRate: 1/2f, changeHappyRate: 0.9f);
    }
}
