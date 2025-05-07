using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerinFlappy : MonoBehaviour
{
    static GameManagerinFlappy gameManagerinFlappy;
    UIManagerinFlappy uiManagerinFlappy;

    int bestScore = 0;
    public int currentScore = 0;
    public int BestScore { get => bestScore; }
    private const string BestScoreKey = "BestScore";

    public UIManagerinFlappy UIManagerinFlappy
    {
        get { return uiManagerinFlappy; }
    }

    public static GameManagerinFlappy Instance
    {
        get { return gameManagerinFlappy; }
    }

    

    private void Awake()
    {
        gameManagerinFlappy = this;
        uiManagerinFlappy = FindObjectOfType<UIManagerinFlappy>();
    }

    void Start()
    {
        UIManagerinFlappy.Instance?.SetGameManager(this);
    }

    public void GameOver()
    {
        UpdateScore();
        UIManagerinFlappy.Instance.SetScoreUI();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManagerinFlappy.UpdateScore();
    }
    public void UpdateScore()
    {
        if (bestScore < currentScore)
        {
            Debug.Log("최고 점수 갱신");
            bestScore = currentScore;

            PlayerPrefs.SetInt(BestScoreKey, bestScore);
        }
    }


}
