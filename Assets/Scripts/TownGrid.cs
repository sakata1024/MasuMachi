using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TownGrid : MonoBehaviour
{
    private GridPanelFactory factory; // グリッド生成クラス
    private GridPanel[] grid; // パネルの1次元配列
    private int stageSize = 3; // 街グリッドサイズ(削除予定)

    // Start is called before the first frame update
    void Start()
    {
        factory = GetComponent<GridPanelFactory>();

        grid = factory.MakeGridPanels(stageSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 該当するパネルにハイライトする関数
    public void HighLightPanel(TownBuildingBlockObject buildingObject)
    {
        CancelHighLightPanel(); //現在のハイライトを消す

        // 直下のパネルがなければハイライトしない
        if(buildingObject.currentPanel == null)
        {
            return;
        }

        // 今設置が不可能ならハイライトしない(NGパネルとかほしい)
        if (!CanSetBuilding(buildingObject))
        {
            return;
        }

        var indices = TownBuildingUtility.GridPanelsToIndices(buildingObject);

        // はみ出していなければハイライトする
        if(indices.All(i => i != -1))
        {
            indices.ForEach(i => grid[i].HighLight());
        }
        
    }

    // ハイライトがかかっている状態をすべて初期化する
    public void CancelHighLightPanel()
    {
        System.Array.ForEach(grid, p => p.CancelHighLight());
    }

    // 設置できるか判定する関数
    public bool CanSetBuilding(TownBuildingBlockObject buildingObject)
    {
        // 該当するパネルがなければfalse
        if(buildingObject.currentPanel == null)
        {
            return false;
        }

        var buildingIndices = TownBuildingUtility.GridPanelsToIndices(buildingObject);

        // -1がindexにあればはみ出しているのでfalse
        if (buildingIndices.Contains(-1))
        {
            return false;
        }

        // TownBuildingBlockを重複なしで取得
        List<TownBuildingBlockObject> oldBuildings = buildingIndices.Select(x => grid[x].townBlock).Where(x => x != null).Distinct().ToList();

        // それぞれのTownBlockが設置しようとしているブロックと完全に被っていたらtrueとなる
        return oldBuildings.All(x => TownBuildingUtility.IsOverlapBuildingBlock(buildingObject, x));
    }

    // TownBuildingBlockを設置する
    public void SetBuilding(TownBuildingBlockObject buildingObject)
    {
        var indices = TownBuildingUtility.GridPanelsToIndices(buildingObject);
        foreach (var idx in indices)
        {
            // 被っているTownBlockは削除
            if(grid[idx].townBlock != null)
            {
                Destroy(grid[idx].townBlock.gameObject);
            }

            grid[idx].Set(buildingObject);
        }
    }

    public List<BuildingBlock> GetAllTownBuildingBlock()
    {
        return grid.Select(x => x.townBlock).Distinct().Select(x => x.buildingBlock).ToList();
    }
}
