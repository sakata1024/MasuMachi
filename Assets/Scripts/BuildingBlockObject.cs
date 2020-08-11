using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingBlockObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public GameObject townBuildingBlockPrefab;
    private TownBuildingBlockObject townBuildingBlockInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 screenPos = eventData.pressPosition;
        Vector3 worldPos = eventData.pressEventCamera.ScreenToWorldPoint(screenPos);
        worldPos.z = -5;
        townBuildingBlockInstance = Instantiate(townBuildingBlockPrefab, worldPos, Quaternion.identity).GetComponent<TownBuildingBlockObject>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        townBuildingBlockInstance?.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        townBuildingBlockInstance?.OnEndDrag(eventData);
        townBuildingBlockInstance = null;
    }
}
