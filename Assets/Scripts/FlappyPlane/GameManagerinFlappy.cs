using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerinFlappy : MonoBehaviour
{
    static GameManagerinFlappy gameManagerinFlappy;
    UIManagerinFlappy uiManagerinFlappy;

    public UIManagerinFlappy UIManagerinFlappy
    {
        get { return uiManagerinFlappy; }
    }

    public static GameManagerinFlappy Instance
    {
        get { return gameManagerinFlappy; }
    }

    private int currentScore = 0;

    private void Awake()
    {
        gameManagerinFlappy = this;
        uiManagerinFlappy = FindObjectOfType<UIManagerinFlappy>();
    }

    public void GameOver()
    {
        uiManagerinFlappy.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }
}
