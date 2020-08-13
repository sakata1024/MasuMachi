using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// グリッドを生成してくれる工場クラス
/// </summary>
public class GridPanelFactory : MonoBehaviour
{
    [SerializeField]
    GridPanel gridPanelPrefab;

    // GridPanelを生成する関数
    public GridPanel[] MakeGridPanels(int panelCount)
    {
        GridPanel[] panels = new GridPanel[panelCount*panelCount];

        for (int i = 0; i < panelCount; i++)
        {
            for (int j = 0; j < panelCount; j++)
            {
                Vector3 pos = new Vector2(j - panelCount / 2, panelCount / 2 - i) * 2f; // この辺でサイズが変わる
                pos.z = -0.1f;
                GameObject instance = Instantiate(gridPanelPrefab.gameObject, transform, false);
                instance.transform.localPosition = pos;
                panels[i * panelCount + j] = instance.GetComponent<GridPanel>();
                panels[i * panelCount + j].Setup(i * panelCount + j);
            }
        }

        return panels;
    }
}
