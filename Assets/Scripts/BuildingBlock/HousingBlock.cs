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
        moneyTerm = 10000;
    }

    public override void OnSetAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -10000, changePopulationRate: 1.2f,changeMoneyRate: 1.5f, changeHappyRate: 0.99f);
    }

    public override void OnUpdateAction()
    {

    }

    public override void OnDestroyAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -5000, changePopulationRate: 1/1.2f, changeMoneyRate: 1/1.5f, changeHappy: -0.05f);
    }
}
