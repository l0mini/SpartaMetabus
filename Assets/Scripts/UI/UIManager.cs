using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCUI
{
    None,
    Magician,
    Knight
}
public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    NPCUI currentui;

    MagicianUI magicUI = null;
    KnightUI knightUI = null;

    private void Awake()
    {
        instance = this;
        magicUI = GetComponentInChildren<MagicianUI>(true);
        knightUI = GetComponentInChildren<KnightUI>(true);
    }

    public void CangeUI(NPCUI ui)
    {
        currentui = ui;
        magicUI?.SetActive(ui);
        knightUI?.SetActive(ui);
    }

    
}
