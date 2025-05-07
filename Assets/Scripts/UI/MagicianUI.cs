using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianUI : BaseNPCUI
{
    protected override NPCUI GetUIState()
    {
        return NPCUI.Magician;
    }

    public override void Init(UIManager uimanager)
    {
        base.Init(uimanager);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
        {
            uimanager.CangeUI(NPCUI.Magician);
        }
    }
}
