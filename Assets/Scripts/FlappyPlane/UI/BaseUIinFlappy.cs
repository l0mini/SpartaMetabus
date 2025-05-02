using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIinFlappy : MonoBehaviour
{
    protected UIManagerinFlappy uiManagerinFlappy;

    public virtual void Init(UIManagerinFlappy uiManager)
    {
        this.uiManagerinFlappy = uiManager;
    }

    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
