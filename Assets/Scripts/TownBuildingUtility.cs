using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 街に関する便利関数が夢のようにつまったクラス
/// </summary>
public static class TownBuildingUtility
{
    // 2つのブロックが重なりきっているか判断する関数
    // underBlockが完全にoverBlockの下にいるならtrue
    public static bool IsOverlapBuildingBlock(TownBuildingBlockObject overBlock, TownBuildingBlockObject underBlock)
    {
        var overPanelIndices = GridPanelsToIndices(overBlock);
        var underPanelIndices = GridPanelsToIndices(underBlock);

        return underPanelIndices.All(x => overPanelIndices.Contains(x));
    }

    // Vector2Intで表現されているブロック位置を1次元パネル配列のインデックスに変える関数
    public static List<int> GridPanelsToIndices(TownBuildingBlockObject buildingObject)
    {
        List<int> result = new List<int>();

        var currentPanelIdx = buildingObject.currentPanel.index;
        var center_x = currentPanelIdx % Town.Instance.townSize;
        var center_y = currentPanelIdx / Town.Instance.townSize;

        foreach (var item in buildingObject.blockList)
        {
            // 範囲外にあれば-1を入れる
            if((center_x + item.x) >= 0 && (center_x + item.x) < Town.Instance.townSize && (center_y + item.y) >= 0 && (center_y + item.y) < Town.Instance.townSize)
            {
                result.Add((center_x + item.x) + Town.Instance.townSize * (center_y + item.y));
            }
            else
            {
                result.Add(-1);
            }
            
        }
        result.Sort();

        return result;
    }
}
