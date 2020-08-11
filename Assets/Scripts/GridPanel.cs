using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanel : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void HighLight()
    {
        Color c = spriteRenderer.color;
        c.a = 1.0f;
        spriteRenderer.color = c;
    }

    public void CancelHighLight()
    {
        Color c = spriteRenderer.color;
        c.a = 0.3f;
        spriteRenderer.color = c;
    }

}
