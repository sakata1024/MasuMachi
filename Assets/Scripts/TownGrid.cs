using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TownGrid : MonoBehaviour
{
    private GridPanelFactory factory; // グリッド生成クラス
    private GridPanel[] grid; // パネルの1次元配列
    private int stageSize; // 街グリッドサイズ(削除予定)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(LevelData level)
    {
        stageSize = level.stageSize;
        factory = GetComponent<GridPanelFactory>();
        grid = factory.MakeGridPanels(stageSize);

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

        var indices = TownBuildingUtility.GridPanelsToIndices(buildingObject);

        // 今設置が不可能ならハイライトしない(NGパネルとかほしい)
        if (!CanSetBuilding(buildingObject))
        {
            if(buildingObject.buildingBlock is Bomb)
            {
                return;
            }
            if (indices.All(i => i != -1))
            {
                indices.ForEach(i => grid[i].BadHighLight());
            }
            return;
        }

        if (buildingObject.buildingBlock is Bomb)
        {
            var block_indices = TownBuildingUtility.GridPanelsToIndices(grid[indices[0]].townBlock);
            block_indices.ForEach(i => grid[i].HighLight());
            return;
        }

        // はみ出していなければハイライトする
        if (indices.All(i => i != -1))
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

        if (buildingObject.buildingBlock is Bomb)
        {
            if (buildingObject.currentPanel.townBlock != null) return true;
            else return false;
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
        if(buildingObject.buildingBlock is Bomb)
        {
            
            grid[indices[0]].townBlock.buildingBlock.OnDestroyAction();
            Destroy(grid[indices[0]].townBlock.gameObject);
            var destroy_indices = TownBuildingUtility.GridPanelsToIndices(grid[indices[0]].townBlock);
            destroy_indices.ForEach(i => grid[i].ResetPanel());
            Destroy(buildingObject.gameObject);

            return;
        }

        foreach (var idx in indices)
        {
            // 被っているTownBlockは削除
            if(grid[idx].townBlock != null)
            {
                grid[idx].townBlock.buildingBlock.OnDestroyAction();
                Destroy(grid[idx].townBlock.gameObject);
            }

            grid[idx].Set(buildingObject);
            grid[idx].townBlock.buildingBlock.OnSetAction();
        }
    }

    public List<BuildingBlock> GetAllTownBuildingBlock()
    {
        return grid.Where(x => x.townBlock != null).Select(x => x.townBlock).Distinct().Select(x => x.buildingBlock).ToList();
    }
}
