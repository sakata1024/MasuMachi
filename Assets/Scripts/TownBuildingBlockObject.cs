using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 場に出ているオブジェクトについてのクラス
/// </summary>
public class TownBuildingBlockObject : MonoBehaviour
{
    public GridPanel currentPanel; //今真下にあるパネル
    public List<Vector2Int> blockList; //ブロックの位置を持つリスト
    public BuildingBlock buildingBlock; //BuildingBlockデータクラス

    // 生成時の設定
    public void Setup(List<Vector2Int> blockList, BuildingBlock buildingBlock)
    {
        this.blockList = blockList;
        this.buildingBlock = buildingBlock;
    }

    // ドラッグ時の処理(パネルについてと移動の処理)
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 screenPos = eventData.position;
        Vector3 worldPos = eventData.pressEventCamera.ScreenToWorldPoint(screenPos);
        worldPos.z = -5;
        transform.position = worldPos;

        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);

        // 現在のパネルを取得(nullの場合もあり)
        RaycastResult resultPanel = result.Where(x => x.gameObject.layer == 8).FirstOrDefault();
        if(currentPanel?.gameObject != resultPanel.gameObject)
        {
            currentPanel = resultPanel.gameObject?.GetComponent<GridPanel>();
            Town.Instance.townGrid.HighLightPanel(this);
        }

    }

    // ドラッグ終了時の処理(固定できるなら固定)
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 screenPos = eventData.position;
        Vector3 worldPos = eventData.pressEventCamera.ScreenToWorldPoint(screenPos);
        worldPos.z = -5;
        transform.position = worldPos;

        if (Town.Instance.townGrid.CanSetBuilding(this))
        {
            Town.Instance.townGrid.CancelHighLightPanel();
            Vector3 pos = currentPanel.transform.position;
            pos.z = -2;
            transform.position = pos;
            Town.Instance.townGrid.SetBuilding(this);
        }
        else
        {
            // 設置できないなら自身を削除
            Destroy(this.gameObject);
        }
        
    }

}
