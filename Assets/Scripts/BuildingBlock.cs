using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBlock
{
    public int populationTerm;
    public int moneyTerm;

    public bool CanBuild()
    {
        return (Town.Instance.townStatus.currentPopulation >= (ulong)populationTerm && Town.Instance.townStatus.currentMoney >= (long)moneyTerm);
    }

    public abstract void OnSetAction();

    public abstract void OnUpdateAction();

    public abstract void OnDestroyAction();
}
