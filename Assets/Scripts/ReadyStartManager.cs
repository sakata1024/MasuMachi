using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStartManager : MonoBehaviour
{
    public void GetStart()
    {
        Town.Instance.PlayStart();
        gameObject.SetActive(false);
        BGMPlayer.Instance.PlayBGM("Main");
    }

    public void PlayCountSE()
    {
        SEPlayer.Instance.PlaySE("countdown");
    }

    public void PlayStartSE()
    {
        SEPlayer.Instance.PlaySE("start");
    }
}
