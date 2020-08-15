using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    [SerializeField]
    private TownGrid _townGrid = null; // 場のグリッド

    [SerializeField]
    private GameObject finishPanel = null;

    public TownGrid townGrid
    {
        get { return _townGrid; }
    }

    [SerializeField]
    private TownStatus _townStatus = null; // 街状態の管理

    public TownStatus townStatus
    {
        get { return _townStatus; }
    }
    
    public Level townLevel = Level.Beginner; // 街のレベル

    [SerializeField]
    AllLevelData allLevelData = null;

    private static Town _instance; // シングルトン

    public static Town Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("TownMaster").GetComponent<Town>();
            }
            return _instance;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        LevelData levelData = allLevelData.GetLevelData(townLevel);
        townStatus.Setup(levelData);
        townGrid.Setup(levelData);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayStart()
    {
        townStatus.GetStart();
    }

    public void PlayFinish()
    {
        finishPanel.SetActive(true);
        GetComponent<FinishManager>().FinishAction();
    }

    private void OnDestroy()
    {
        _instance = null;
    }

}
