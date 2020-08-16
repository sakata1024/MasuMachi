using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SEData")]
public class SEData : ScriptableObject
{
    [SerializeField]
    private List<SE> seList = new List<SE>();

    public SE GetSE(string name)
    {
        return seList.SingleOrDefault(x => x.name == name);
    }

    [System.Serializable]
    public class SE
    {
        public string name;
        public AudioClip source;
        [Range(0f,1f)]
        public float volume;
    }
}
