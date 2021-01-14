using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResultPanel : MonoBehaviour
{
    public bool isDetailShow = true;

    [SerializeField]
    public GameObject detailPanel;

    [SerializeField]
    public GameObject resultPanel;

    [SerializeField]
    private Text buttonText;

    public void OnClick()
    {
        if (isDetailShow)
        {
            resultPanel.SetActive(false);
            detailPanel.SetActive(true);
            buttonText.text = "街の評価";
            isDetailShow = false;
        }
        else
        {
            resultPanel.SetActive(true);
            detailPanel.SetActive(false);
            buttonText.text = "街の歴史";
            isDetailShow = true;
        }
    }
}
