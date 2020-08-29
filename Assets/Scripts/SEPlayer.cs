using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    [SerializeField]
    private SEData se_data = null;

    private static SEPlayer _instance;

    private AudioSource audioSource;

    public static bool isSound
    {
        get;
        private set;
    } = true;

    public static SEPlayer Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SE Player is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance != null)
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
            audioSource.volume = 1f;
        }
        else
        {
            audioSource.volume = 0;
        }
    }

    public void PlaySE(string name)
    {
        SEData.SE se = se_data.GetSE(name);
        audioSource.PlayOneShot(se.source, se.volume);
    }

    public void ChangeVolume(bool isPlay)
    {
        isSound = isPlay;
        if (isSound)
        {
            audioSource.volume = 1;
        }
        else
        {
            audioSource.volume = 0;
        }
    }
}
