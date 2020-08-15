using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyStartManager : MonoBehaviour
{
    public void GetStart()
    {
        Town.Instance.PlayStart();
        gameObject.SetActive(false);
    }
}
