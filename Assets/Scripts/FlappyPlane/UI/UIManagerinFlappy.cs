using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum UIState
{
    Home,
    Game,
    Score,
}
public class UIManagerinFlappy : MonoBehaviour
{

    [SerializeField] private string mainScene = "SampleScene";
    static UIManagerinFlappy instance;

    GameManagerinFlappy gameManagerinFlappy;
    public static UIManagerinFlappy Instance
    {
        get { return instance; }
    }

    UIState currentState = UIState.Home;
    
    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;
    private void Awake()
    {
        instance = this;

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);
        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this);

        gameManagerinFlappy = GameManagerinFlappy.Instance;

        if (!GameManagerinFlappy.isLoaded)
        {
            ChangeState(UIState.Home);
            GameManagerinFlappy.isLoaded = true;
        }
        else
        {
            ChangeState(UIState.Game);
        }
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        Time.timeScale = 1f;
        ChangeState(UIState.Game);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManagerinFlappy.currentScore = 0;
    }

    public void OnClickExit()
    {
        GameManagerinFlappy.isLoaded = false;
        gameManagerinFlappy.currentScore = 0;
        SceneManager.LoadScene(mainScene);
    }

    public void UpdateScore()
    {
        gameUI.SetUI(gameManagerinFlappy.currentScore);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(gameManagerinFlappy.currentScore, gameManagerinFlappy.BestScore);
        ChangeState(UIState.Score);
    }
    public void SetGameManager(GameManagerinFlappy gm)
    {
        gameManagerinFlappy = gm;
    }


}

