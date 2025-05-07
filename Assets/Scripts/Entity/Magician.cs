using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.CangeUI(NPCUI.Magician);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIManager.Instance.CangeUI(NPCUI.None);
        }
    }
}
