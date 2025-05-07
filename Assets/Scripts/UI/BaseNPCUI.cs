using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNPCUI : MonoBehaviour
{
   protected UIManager uimanager;

    public virtual void Init(UIManager uimanager)
    {
        this.uimanager = uimanager;
    }
    protected abstract NPCUI GetUIState();
    public void SetActive(NPCUI ui)
    {
        gameObject.SetActive(GetUIState() == ui);
    }

}
