using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVolume : MonoBehaviour
{
    [SerializeField]
    private Button soundOnVolume = null;

    [SerializeField]
    private Button soundOffVolume = null;

    // Start is called before the first frame update
    void Start()
    {
        if (BGMPlayer.isSound)
        {
            soundOnVolume.gameObject.SetActive(true);
            soundOffVolume.gameObject.SetActive(false);
        }
        else
        {
            soundOnVolume.gameObject.SetActive(false);
            soundOffVolume.gameObject.SetActive(true);
        }
    }

    public void ChangeVolume(bool isPlay)
    {
        BGMPlayer.Instance.ChangeVolume(isPlay);
        SEPlayer.Instance.ChangeVolume(isPlay);

        if (BGMPlayer.isSound)
        {
            soundOnVolume.gameObject.SetActive(true);
            soundOffVolume.gameObject.SetActive(false);
        }
        else
        {
            soundOnVolume.gameObject.SetActive(false);
            soundOffVolume.gameObject.SetActive(true);
        }
    }
}
