using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGraphButton : MonoBehaviour
{
    public enum GraphType
    {
        All,
        Population,
        Happy,
        Money,
    }
    
    [SerializeField]
    private GameObject populationGraph = default;
    [SerializeField]
    private GameObject happyGraph = default;
    [SerializeField]
    private GameObject moneyGraph = default;
    
    public void OnChangeButton(int graphType)
    {
        switch ((GraphType)graphType)
        {
            case GraphType.All:
                populationGraph.SetActive(true);
                populationGraph.transform.GetChild(0).gameObject.SetActive(false);
                happyGraph.SetActive(true);
                happyGraph.transform.GetChild(0).gameObject.SetActive(false);
                moneyGraph.SetActive(true);
                moneyGraph.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case GraphType.Population:
                populationGraph.SetActive(true);
                populationGraph.transform.GetChild(0).gameObject.SetActive(true);
                happyGraph.SetActive(false);
                moneyGraph.SetActive(false);
                break;
            case GraphType.Happy:
                populationGraph.SetActive(false);
                happyGraph.SetActive(true);
                happyGraph.transform.GetChild(0).gameObject.SetActive(true);
                moneyGraph.SetActive(false);
                break;
            case GraphType.Money:
                populationGraph.SetActive(false);
                happyGraph.SetActive(false);
                moneyGraph.SetActive(true);
                moneyGraph.transform.GetChild(0).gameObject.SetActive(true);
                break;
            default:
                break;
        }

    }
}
