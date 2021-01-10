using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TownStatus : MonoBehaviour
{
    private float deltaPopulation = 1000f;
    private float deltaMoney = 30000f;
    private float deltaHappy = 0.01f;
    private float _currentPopulation;
    private float _currentMoney;
    private float _currentHappy;
    private float _targetPopulation;
    private float _targetMoney;
    private float _targetHappy;

    private float _currentTime;
    private bool isStarted = false;

    public int stageSize
    {
        get;
        private set;
    }

    public ulong currentPopulation
    {
        get { return (ulong)_currentPopulation; }
    }

    public long currentMoney
    {
        get { return (long)_currentMoney; }
    }

    public float currentHappy
    {
        get { return Mathf.Floor(_currentHappy * 10000) / 100; }
    }

    public int targetPopulation
    {
        get { return (int)_targetPopulation; }
    }

    public int targetMoney
    {
        get { return (int)_targetMoney; }
    }

    public float targetHappy
    {
        get { return Mathf.Floor(_targetHappy * 10000) / 100; }
    }

    public bool isAchivePopulation
    {
        get { return currentPopulation >= (ulong)targetPopulation; }
    }

    public bool isAchiveMoney
    {
        get { return currentMoney >= (long)targetMoney; }
    }

    public bool isAchiveHappy
    {
        get { return currentHappy >= targetHappy; }
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

    public void Setup(LevelData levelData)
    {
        stageSize = levelData.stageSize;
        _currentPopulation = levelData.firstPopulation;
        _currentMoney = levelData.firstMoney;
        _currentHappy = levelData.firstHappy;
        _targetPopulation = levelData.targetPopulation;
        _targetMoney = levelData.targetMoney;
        _targetHappy = levelData.targetHappy;
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
        var blockList = Town.Instance.townGrid.GetAllTownBuildingBlock();
        blockList.ForEach(x => x.OnUpdateAction());

        if(currentPopulation > (ulong)targetPopulation)
        {
            deltaHappy = deltaHappy - 0.001f * Time.deltaTime;
        }

        if(currentTime >= 40)
        {
            deltaPopulation = deltaPopulation - 600f * Time.deltaTime;
        }

        _currentPopulation += deltaPopulation * Time.deltaTime;
        _currentMoney += deltaMoney * Time.deltaTime;
        _currentHappy += deltaHappy * Time.deltaTime;

        _currentHappy = Mathf.Clamp(_currentHappy, -1, 1);
        _currentPopulation = Mathf.Clamp(_currentPopulation, 0, float.MaxValue);
    }

    public void ChangeStatus(float changePopulation = 0f, float changeMoney=0f, float changeHappy=0f, float changePopulationRate=1f, float changeMoneyRate=1f, float changeHappyRate = 1f)
    {
        _currentPopulation += changePopulation;
        _currentMoney += changeMoney;
        _currentHappy += changeHappy;
        deltaPopulation *= changePopulationRate;
        deltaMoney *= changeMoneyRate;
        deltaHappy *= changeHappyRate;
    }
}
