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

   
}
