using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownStatus : MonoBehaviour
{
    private float deltaPopulation = 100f;
    private float deltaMoney = 10000f;
    private float deltaHappy = 0.01f;
    private float _currentPopulation;
    private float _currentMoney;
    private float _currentHappy;
    private int _targetPopulation;
    private int _targetMoney;
    private int _targetHappy;

    private float _currentTime;
    private bool isStarted = false;

    public int currentPopulation
    {
        get { return (int)_currentPopulation; }
    }

    public int currentMoney
    {
        get { return (int)_currentMoney; }
    }

    public float currentHappy
    {
        get { return Mathf.Floor(_currentHappy * 10000) / 100; }
    }

    public int targetPopulation
    {
        get { return _targetPopulation; }
    }

    public int targetMoney
    {
        get { return _targetMoney; }
    }

    public float targetHappy
    {
        get { return Mathf.Floor(_targetHappy * 10000) / 100; }
    }

    public int currentTime
    {
        get { return (int)_currentTime; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0f;
        isStarted = false;
    }

    public void Setup(float firstPopulation, float firstMoney, float firstHappy, int targetPopulation, int targetMoney, int targetHappy)
    {
        _currentPopulation = firstPopulation;
        _currentMoney = firstMoney;
        _currentHappy = firstHappy;
        _targetPopulation = targetPopulation;
        _targetMoney = targetMoney;
        _targetHappy = targetHappy;
    }

    public void GetStart()
    {
        isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            _currentTime += Time.deltaTime;
            UpdateStatus();

            if(currentTime >= 60)
            {
                Finish();
            }
        }
    }

    public void Finish()
    {
        isStarted = false;
        Town.Instance.PlayFinish();
    }

    private void UpdateStatus()
    {
        //TODO: doAction等を追加したら戻す
        //var blockList = Town.Instance.townGrid.GetAllTownBuildingBlock();

        _currentPopulation += deltaPopulation * Time.deltaTime;
        _currentMoney += deltaMoney * Time.deltaTime;
        _currentHappy += deltaHappy * Time.deltaTime;

        _currentHappy = Mathf.Clamp(_currentHappy, -1, 1);
    }

    private void ChangeStatus(float changePopulation = 0f, float changeMoney=0f, float changeHappy=0f, float changePopulationRate=1f, float changeMoneyRate=1f, float changeHappyRate = 1f)
    {
        _currentPopulation += changePopulation;
        _currentMoney += changeMoney;
        _currentHappy += changeHappy;
        deltaPopulation *= changePopulationRate;
        deltaMoney *= changeMoneyRate;
        deltaHappy *= changeHappyRate;
    }
}
