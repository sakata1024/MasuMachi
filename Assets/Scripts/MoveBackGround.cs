using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    [SerializeField]
    GameObject currentBG;
    [SerializeField]
    GameObject nextBG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentBG.transform.Translate(-1f, 0, 0);
        nextBG.transform.Translate(-1f, 0, 0);

        if(nextBG.transform.localPosition.x <= 0)
        {
            currentBG.transform.localPosition = new Vector2(nextBG.GetComponent<RectTransform>().sizeDelta.x, 0);
            var tmp = currentBG;
            currentBG = nextBG;
            nextBG = tmp;
        }
    }
}
