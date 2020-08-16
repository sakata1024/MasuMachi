using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEndStar : MonoBehaviour
{
    [SerializeField]
    private Image populationStar = null;

    [SerializeField]
    private Image happyStar = null;

    [SerializeField]
    private Image moneyStar = null;

    public void BlightPopulationAction()
    {
        if (Town.Instance.townStatus.isAchivePopulation)
        {
            StartCoroutine(BlightStar(populationStar));
        }
    }

    public void BlightHappyAction()
    {
        if (Town.Instance.townStatus.isAchiveHappy)
        {
            StartCoroutine(BlightStar(happyStar));
        }
    }

    public void BlightMoneyAction()
    {
        if (Town.Instance.townStatus.isAchiveMoney)
        {
            StartCoroutine(BlightStar(moneyStar));
            SEPlayer.Instance.PlaySE("star");
        }
    }

    public void PlayFinishSE()
    {
        SEPlayer.Instance.PlaySE("finish");
    }

    public void PlayDisplaySE()
    {
        SEPlayer.Instance.PlaySE("display");
    }

    IEnumerator BlightStar(Image star)
    {
        float h, s, v;

        Color.RGBToHSV(star.color, out h, out s, out v);

        while (v < 1)
        {
            v += 2f * Time.deltaTime;

            v = Mathf.Clamp(v, 0, 1);

            star.color = Color.HSVToRGB(h, s, v);

            yield return null;
        }
    }
}
