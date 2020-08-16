using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField]
    private BGMData bgm_data = null;

    private static BGMPlayer _instance;

    private AudioSource audioSource;

    public static BGMPlayer Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("BGM Player is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM(string name)
    {
        audioSource.Stop();

        AudioClip clip = bgm_data.GetBGM(name);
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void ChangeVolume(bool isPlay)
    {
        if (isPlay)
        {
            audioSource.volume = 0.2f;
        }
        else
        {
            audioSource.volume = 0;
        }
    }
}
