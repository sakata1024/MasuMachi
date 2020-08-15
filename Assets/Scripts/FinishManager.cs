using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    [SerializeField]
    private Text populationText = null;

    [SerializeField]
    private Text happyText = null;

    [SerializeField]
    private Text moneyText = null;

    public void FinishAction()
    {
        populationText.text = Town.Instance.townStatus.currentPopulation.ToString();
        happyText.text = Town.Instance.townStatus.currentHappy.ToString("F2");
        moneyText.text = Town.Instance.townStatus.currentMoney.ToString();
    }
}
