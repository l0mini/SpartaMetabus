using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum UIState
{
    Home,
    Game,
    Score,
}
public class UIManagerinFlappy : MonoBehaviour
{
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

        ChangeState(UIState.Home);
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
        //gameManagerinFlappy.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
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

