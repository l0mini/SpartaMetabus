using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    UIManager uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
        {
            uiManager.CangeUI(NPCUI.Magician);
        }
    }
}
