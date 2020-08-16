using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 学校オブジェクト
/// 満足度が向上する。人口とお金がないと建てれない
/// </summary>
public class SchoolBlock : BuildingBlockObject
{
    protected override void Start()
    {
        buildingBlock = new School();
        blockList.Add(new Vector2Int(0, 0));
        blockList.Add(new Vector2Int(1, 0));
        blockList.Add(new Vector2Int(0, 1));
        scale = 0.5f;
        base.Start();
    }

}

public class School : BuildingBlock
{
    public School()
    {
        populationTerm = 10000;
        moneyTerm = 2000000;
    }

    public override void OnSetAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -1000000,changeHappy: 0.1f, changePopulationRate: 1.2f, changeHappyRate: 1.4f);
    }

    public override void OnUpdateAction()
    {
        
    }

    public override void OnDestroyAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -1000000, changeHappy: -0.3f, changePopulationRate: 0.8f, changeHappyRate: 1/1.4f);
    }
}
