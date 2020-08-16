using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/BGMData")]
public class BGMData : ScriptableObject
{
    [SerializeField]
    private List<BGM> bgmList = new List<BGM>();

    public AudioClip GetBGM(string name)
    {
        return bgmList.SingleOrDefault(x => x.name == name).source;
    }

    [System.Serializable]
    public class BGM
    {
        public string name;
        public AudioClip source;
    }
}
