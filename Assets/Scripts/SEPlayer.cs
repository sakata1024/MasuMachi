using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    [SerializeField]
    private SEData se_data = null;

    private static SEPlayer _instance;

    private AudioSource audioSource;

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
        _instance = this;
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySE(string name)
    {
        AudioClip clip = se_data.GetSE(name);
        audioSource.PlayOneShot(clip);
    }

    public void ChangeVolume(bool isPlay)
    {
        if (isPlay)
        {
            audioSource.volume = 1;
        }
        else
        {
            audioSource.volume = 0;
        }
    }
}
