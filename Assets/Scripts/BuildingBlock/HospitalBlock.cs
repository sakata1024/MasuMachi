using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HospitalBlock : BuildingBlockObject
{
    protected override void Start()
    {
        buildingBlock = new Hospital();
        blockList.Add(new Vector2Int(0, 0));
        blockList.Add(new Vector2Int(1, 0));
        scale = 0.5f;
        base.Start();
    }
}

public class Hospital : BuildingBlock
{
    public Hospital()
    {
        populationTerm = 10000;
        moneyTerm = 1000000;
    }

    public override void OnSetAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -1000000, changePopulationRate: 1.2f, changeHappy: 0.1f, changeHappyRate: 1.01f);
    }

    public override void OnUpdateAction()
    {

    }

    public override void OnDestroyAction()
    {
        Town.Instance.townStatus.ChangeStatus(changeMoney: -500000, changePopulationRate: 1 / 1.5f,  changeHappy: -0.15f, changeHappyRate: 1/1.1f);
    }
}