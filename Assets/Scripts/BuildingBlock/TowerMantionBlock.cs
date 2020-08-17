using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMantionBlock : BuildingBlockObject
{
    protected override void Start()
    {
        buildingBlock = new TowerMantion();
        blockList.Add(new Vector2Int(0, 0));
        blockList.Add(new Vector2Int(1, 0));
        blockList.Add(new Vector2Int(-1, 0));
        scale = 0.35f;
        base.Start();
    }
}

public class TowerMantion : BuildingBlock
{
    public TowerMantion()
    {
        populationTerm = 300000;
        moneyTerm = 100000;
    }

    public override void OnSetAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -50000, changePopulation: 10000, changePopulationRate: 1.7f, changeMoneyRate: 1.7f, changeHappy: 0.1f);
    }

    public override void OnUpdateAction()
    {

    }

    public override void OnDestroyAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -100000, changePopulation: -10000, changePopulationRate: 1/1.4f, changeMoneyRate: 1/1.7f, changeHappy: -0.2f);
    }
}