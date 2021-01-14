using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGraphManager : MonoBehaviour
{
    private int currentTime = -1;
    private List<float> populationResults = default;
    private List<float> happyResults = default;
    private List<float> moneyResults = default;

    public ScoreGraphRenderer populationGraphRenderer;
    public ScoreGraphRenderer happyGraphRenderer;
    public ScoreGraphRenderer moneyGraphRenderer;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = -1;
        populationResults = new List<float>();
        happyResults = new List<float>();
        moneyResults = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Town.Instance.townStatus.currentTime != currentTime)
        {
            currentTime = Town.Instance.townStatus.currentTime;
            populationResults.Add(Town.Instance.townStatus.currentPopulation);
            happyResults.Add(Town.Instance.townStatus.currentHappy);
            moneyResults.Add(Town.Instance.townStatus.currentMoney);
        }
    }

    public void Finish()
    {
        if(currentTime != 60)
        {
            currentTime = Town.Instance.townStatus.currentTime;
            populationResults.Add(Town.Instance.townStatus.currentPopulation);
            happyResults.Add(Town.Instance.townStatus.currentHappy);
            moneyResults.Add(Town.Instance.townStatus.currentMoney);
        }
        populationGraphRenderer.RenderScoreGraph(populationResults, Town.Instance.townStatus.targetPopulation);
        happyGraphRenderer.RenderScoreGraph(happyResults, Town.Instance.townStatus.targetHappy);
        moneyGraphRenderer.RenderScoreGraph(moneyResults, Town.Instance.townStatus.targetMoney);
    }
}
