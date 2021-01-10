using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// グリッドを生成してくれる工場クラス
/// </summary>
public class GridPanelFactory : MonoBehaviour
{
    [SerializeField]
    GridPanel gridPanelPrefab = null;

    // GridPanelを生成する関数
    public GridPanel[] MakeGridPanels(int panelCount)
    {
        GridPanel[] panels = new GridPanel[panelCount*panelCount];
        float cellSize = GridUtility.GetGridCellSize(panelCount);

        for (int i = 0; i < panelCount; i++)
        {
            for (int j = 0; j < panelCount; j++)
            {
                Vector3 pos = Vector3.zero;
                if (panelCount % 2 == 0)
                {
                    pos = new Vector2(j - (panelCount / 2 - 0.5f), (panelCount / 2 - 0.5f) - i) * cellSize;
                }
                else
                {
                    pos = new Vector2(j - panelCount / 2, panelCount / 2 - i) * cellSize;
                }
                
                pos.z = -0.1f;
                GameObject instance = Instantiate(gridPanelPrefab.gameObject, transform, false);
                instance.transform.localPosition = pos;
                float scale = cellSize / instance.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
                instance.transform.localScale = Vector3.one * scale * 0.9f;
                panels[i * panelCount + j] = instance.GetComponent<GridPanel>();
                panels[i * panelCount + j].Setup(i * panelCount + j);
            }
        }

        return panels;
    }
}

public static class GridUtility
{
    static float originGridSize = 6f; // world座標でのグリッドサイズ

    public static float GetGridCellSize(int size)
    {
        float fixedCellSize = originGridSize / size; // world座標でのセルサイズ

        return fixedCellSize;
    }
}