using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanelFactory : MonoBehaviour
{
    public GridPanel gridPanelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        MakeGridPanels(3);
    }

    public void MakeGridPanels(int panelCount)
    {
        for (int i = 0; i < panelCount; i++)
        {
            for (int j = 0; j < panelCount; j++)
            {
                Vector3 pos = new Vector2(j - panelCount / 2, i - panelCount / 2) * 2f;
                pos.z = -0.1f;
                GameObject instance = Instantiate(gridPanelPrefab.gameObject, transform, false);
                instance.transform.localPosition = pos;
            }
        }
    }
}
