using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopulation : MonoBehaviour
{
    [SerializeField]
    private Text currentTextComponent = null;

    [SerializeField]
    private Text targetTextComponent = null;

    // Start is called before the first frame update
    void Start()
    {
        if(currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentPopulation.ToString();

        if(targetTextComponent)
            targetTextComponent.text = Town.Instance.townStatus.targetPopulation.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentPopulation.ToString();

        if (targetTextComponent)
            targetTextComponent.text = Town.Instance.townStatus.targetPopulation.ToString();
    }
}
