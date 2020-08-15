using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountdown : MonoBehaviour
{
    [SerializeField]
    private Text currentTextComponent = null;

    // Start is called before the first frame update
    void Start()
    {
        if (currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTextComponent)
            currentTextComponent.text = Town.Instance.townStatus.currentTime.ToString();
    }
}
