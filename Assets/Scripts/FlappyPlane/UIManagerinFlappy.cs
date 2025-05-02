using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerinFlappy : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    public void Start()
    {
        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
