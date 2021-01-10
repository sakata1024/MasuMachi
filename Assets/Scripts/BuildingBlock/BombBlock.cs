using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlock : BuildingBlockObject
{
    protected override void Start()
    {
        buildingBlock = new Bomb();
        blockList.Add(new Vector2Int(0, 0));
        scale = 1f;
        base.Start();
    }
}

public class Bomb: BuildingBlock
{
    public Bomb()
    {
        populationTerm = 0;
        moneyTerm = int.MinValue;
    }

    public override void OnDestroyAction()
    {
        
    }

    public override void OnSetAction()
    {
        
    }

    public override void OnUpdateAction()
    {
        
    }
}