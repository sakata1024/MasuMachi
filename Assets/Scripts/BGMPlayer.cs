using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField]
    private BGMData bgm_data = null;

    private static BGMPlayer _instance;

    private AudioSource audioSource;

    public static bool isSound
    {
        get;
        private set;
    } = true;

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
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
        }
        _instance = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (isSound)
        {
            audioSource.volume = 0.2f;
        }
        else
        {
            audioSource.volume = 0;
        }
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
        isSound = isPlay;
        if (isSound)
        {
            audioSource.volume = 0.2f;
        }
        else
        {
            audioSource.volume = 0;
        }
    }
}
