using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanel : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // 自分自身のspriteRenderer
    public TownBuildingBlockObject townBlock; //このパネルが参照するtownBlock
    public int index; //グリッドから見たインデックス

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // indexの設定
    public void Setup(int idx)
    {
        index = idx;
    }

    // 自身のハイライト
    public void HighLight()
    {
        Color c = spriteRenderer.color;
        c.a = 1.0f;
        spriteRenderer.color = c;
    }

    // ハイライトの終了
    public void CancelHighLight()
    {
        Color c = spriteRenderer.color;
        c.a = 0.3f;
        spriteRenderer.color = c;
    }

    // Gridを占領しているTownBuildingBlockの追加
    public void Set(TownBuildingBlockObject townBlock)
    {
        this.townBlock = townBlock;

    }

}
