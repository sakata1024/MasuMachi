using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITermPanel : MonoBehaviour
{
    [SerializeField]
    private Text populationTermText = null;

    [SerializeField]
    private Text moneyTermText = null;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetUp(BuildingBlock buildingBlock)
    {
        populationTermText.text = buildingBlock.populationTerm.ToString();
        moneyTermText.text = buildingBlock.moneyTerm.ToString();
    }

    private void Update()
    {
        rectTransform.localPosition = transform.InverseTransformPoint(Input.mousePosition);
        Debug.Log(rectTransform.localPosition);
    }
}
