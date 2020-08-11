using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class TownBuildingBlockObject : MonoBehaviour
{
    private GridPanel currentPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 screenPos = eventData.position;
        Vector3 worldPos = eventData.pressEventCamera.ScreenToWorldPoint(screenPos);
        worldPos.z = -5;
        transform.position = worldPos;

        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);

        RaycastResult resultPanel = result.Where(x => x.gameObject.layer == 8).FirstOrDefault();
        if(currentPanel?.gameObject != resultPanel.gameObject)
        {
            currentPanel?.CancelHighLight();
            currentPanel = resultPanel.gameObject?.GetComponent<GridPanel>();
            currentPanel?.HighLight();
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 screenPos = eventData.position;
        Vector3 worldPos = eventData.pressEventCamera.ScreenToWorldPoint(screenPos);
        worldPos.z = -5;
        transform.position = worldPos;

        if (currentPanel)
        {
            currentPanel.CancelHighLight();
            Vector3 pos = currentPanel.transform.position;
            pos.z = -2;
            transform.position = pos;
            currentPanel = null;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

}
