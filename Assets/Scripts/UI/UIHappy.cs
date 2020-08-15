using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHappy : MonoBehaviour
{
    [SerializeField]
    private Text currentTextComponent = null;

    [SerializeField]
    private Text targetTextComponent = null;

    // Start is called before the first frame update
    void Start()
    {
        if (currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentHappy.ToString("F2");

        if (targetTextComponent)
            targetTextComponent.text = Town.Instance.townStatus.targetHappy.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentHappy.ToString("F2");

        if (targetTextComponent)
            targetTextComponent.text = Town.Instance.townStatus.targetHappy.ToString("F2");
    }
}
