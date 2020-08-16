﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{

    public void ClickAction()
    {
        SceneManager.LoadScene("TitleScene");
        SEPlayer.Instance.PlaySE("detect");
        BGMPlayer.Instance.StopBGM();
    }

}
