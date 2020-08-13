﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    [SerializeField]
    private TownGrid _townGrid; // 場のグリッド

    public TownGrid townGrid
    {
        get { return _townGrid; }
    }

    [SerializeField]
    private TownStatus _townStatus; // 街状態の管理

    public TownStatus townStatus
    {
        get { return _townStatus; }
    }

    public int townSize = 3; // 街グリッドのサイズ

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        _instance = null;
    }

}
