using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    UIManager uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
        {
            uiManager.CangeUI(NPCUI.Knight);
        }
    }
}
