using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationBlock : BuildingBlockObject
{
    protected override void Start()
    {
        buildingBlock = new Station();
        blockList.Add(new Vector2Int(0, 0));
        blockList.Add(new Vector2Int(1, 0));
        blockList.Add(new Vector2Int(0, 1));
        scale = 0.5f;
        base.Start();
    }
}

public class Station : BuildingBlock
{
    public Station()
    {
        populationTerm = 200000;
        moneyTerm = 1000000;
    }

    public override void OnSetAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -10000000, changePopulationRate: 1.2f, changeMoneyRate: 0.4f,changeHappy: 0.1f, changeHappyRate: 1.7f);
    }

    public override void OnUpdateAction()
    {

    }

    public override void OnDestroyAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -20000000, changeMoneyRate: 0.8f, changeHappy: -0.5f, changeHappyRate: 1 / 1.7f);
    }
}