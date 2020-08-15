using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMoney : MonoBehaviour
{
    [SerializeField]
    private Text currentTextComponent = null;

    [SerializeField]
    private Text targetTextComponent = null;

    [SerializeField]
    private GameObject moneyStar = null;

    // Start is called before the first frame update
    void Start()
    {
        if (currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentMoney.ToString();

        if (targetTextComponent)
            targetTextComponent.text = Town.Instance.townStatus.targetMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentMoney.ToString();

        if (targetTextComponent)
            targetTextComponent.text = Town.Instance.townStatus.targetMoney.ToString();

        if (Town.Instance.townStatus.isAchiveMoney)
        {
            moneyStar.SetActive(true);
        }
        else
        {
            moneyStar.SetActive(false);
        }
    }
}
