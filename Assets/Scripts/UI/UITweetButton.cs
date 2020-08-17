using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweetButton : MonoBehaviour
{
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition -= new Vector3(0, Mathf.Sin(t) * 70f * Time.deltaTime, 0);
        t += Time.deltaTime;
    }

    public void Tweet()
    {
        string tweetText = string.Format("【60年間の街づくりの成果】\n人口:{0}人\n満足度:{1:F2}%\n資金:{2}円\nお疲れさまでした。\n",
            Town.Instance.townStatus.currentPopulation, Town.Instance.townStatus.currentHappy, Town.Instance.townStatus.currentMoney);
        naichilab.UnityRoomTweet.Tweet("masumachi", tweetText, "マスマチ", "unity1week");
    }
}
