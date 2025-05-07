using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightUI : BaseNPCUI
{
    protected override NPCUI GetUIState()
    {
        return NPCUI.Knight;
    }

    public override void Init(UIManager uimanager)
    {
        base.Init(uimanager);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
        {
            uimanager.CangeUI(NPCUI.Knight);
        }
    }
}
