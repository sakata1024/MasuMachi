using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreGraphRenderer : MonoBehaviour
{
    public Color c;
    private LineRenderer lineRenderer;
    private float graphWidth;
    private float graphHeight;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        RectTransform rectTransform = GetComponent<RectTransform>();
        graphWidth = rectTransform.sizeDelta.x;
        graphHeight = rectTransform.sizeDelta.y;
    }

    public void RenderScoreGraph(List<float> scoreList)
    {
        // スコアデータの統計
        float max = scoreList.Max();
        float min = scoreList.Min();
        int count = scoreList.Count;
        float heightScale = graphHeight / (max - min);
        float width = graphWidth / (count - 1);

        // 位置リスト生成
        List<float> yList = scoreList.Select(x => x * heightScale - graphHeight / 2).ToList();
        Vector3[] posList = yList.Zip(Enumerable.Range(0, count).Select(x => x * width), (y, x) => new Vector3(x - graphWidth / 2, y, 0)).ToArray();

        // renderer設定
        lineRenderer.positionCount = posList.Length;
        lineRenderer.SetPositions(posList);
        lineRenderer.startColor = c;
        lineRenderer.endColor = c;
    }


}
