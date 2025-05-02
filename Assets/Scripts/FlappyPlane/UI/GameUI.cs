using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUIinFlappy
{
    TextMeshProUGUI scoreText;

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public override void Init(UIManagerinFlappy uiManager)
    {
        base.Init(uiManager);
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
