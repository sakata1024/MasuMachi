using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 場に出すBuildingBlockを持つクラス
/// </summary>
public class BuildingBlockObject : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public TownBuildingBlockObject townBuildingBlockPrefab; //場に生成するオブジェクトのプレハブ
    //public UITermPanel termPanelPrefab;
    //private GameObject termPanel;
    private TownBuildingBlockObject townBuildingBlockInstance; //場に生成したインスタンス。ドラッグ終了まで見る
    public List<Vector2Int> blockList = new List<Vector2Int>(); //ブロックがある位置
    public BuildingBlock buildingBlock; //BuildingBlockデータクラス
    public GameObject buildBarrier;
    protected float scale = 1f; // 1ブロックの縮小率

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (buildingBlock.CanBuild())
        {
            buildBarrier.SetActive(false);
        }
        else
        {
            buildBarrier.SetActive(true);
        }
    }

    // 90度右に回転する関数
    private void TurnBuildingObject()
    {
        foreach (Transform t in transform)
        {
            t.RotateAround(transform.position, Vector3.back, 90f);
            t.Rotate(Vector3.forward, 90f);
        }

        blockList = blockList.Select(v => new Vector2Int(-v.y, v.x)).ToList();
    }

    // 子オブジェクトを場のblockにコピーする関数
    private void CopyBuildingObjectToTown(TownBuildingBlockObject townObject)
    {
        GameObject origin = transform.GetChild(0).gameObject; //ポインタ位置に相当するオブジェクト
        foreach (Transform child in transform)
        {
            GameObject instance = Instantiate(child.gameObject, townObject.transform);
            float stageScale = GridUtility.GetGridCellSize(Town.Instance.townStatus.stageSize) / (instance.GetComponent<SpriteRenderer>().sprite.bounds.size.x);
            instance.transform.localPosition = child.transform.localPosition - origin.transform.localPosition;
            instance.transform.localPosition = Vector3.Scale(instance.transform.localPosition, new Vector3(1.0f / scale * stageScale, 1.0f / scale * stageScale, 1f));
            instance.transform.localScale = Vector3.Scale(instance.transform.localScale, new Vector3(1.0f / scale * stageScale, 1.0f / scale * stageScale, 1f));
        }
    }

    // 自身がクリックされたときの動作
    public void OnPointerClick(PointerEventData eventData)
    {
        if(buildingBlock.CanBuild())
            TurnBuildingObject();
    }

    // ドラッグ開始時の処理(TownBuildingBlockObjectの生成)
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!buildingBlock.CanBuild())
        {
            return;
        }
        Vector2 screenPos = eventData.pressPosition;
        Vector3 worldPos = eventData.pressEventCamera.ScreenToWorldPoint(screenPos);
        worldPos.z = -5;
        townBuildingBlockInstance = Instantiate(townBuildingBlockPrefab.gameObject, worldPos, Quaternion.identity).GetComponent<TownBuildingBlockObject>();
        CopyBuildingObjectToTown(townBuildingBlockInstance);
        townBuildingBlockInstance.Setup(blockList, buildingBlock);
    }

    // ドラッグ時の処理(TownBlockに依存)
    public void OnDrag(PointerEventData eventData)
    {
        if (!buildingBlock.CanBuild())
        {
            return;
        }
        townBuildingBlockInstance.OnDrag(eventData);
    }

    // ドラッグ終了時の処理(解放)
    public void OnEndDrag(PointerEventData eventData)
    {
        /*if (!buildingBlock.CanBuild())
        {
            return;
        }*/
        townBuildingBlockInstance?.OnEndDrag(eventData);
        townBuildingBlockInstance = null;
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        if (buildBarrier.activeInHierarchy)
        {
            termPanel = Instantiate(termPanelPrefab.gameObject, GameObject.Find("Canvas").transform);
            termPanel.GetComponent<UITermPanel>().SetUp(buildingBlock);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buildBarrier.activeInHierarchy)
        {
            DestroyImmediate(termPanel);
        }
    }*/
    
}
