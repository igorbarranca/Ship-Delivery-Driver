using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;

    public void UpdateScoreText(int score)
    {
        scoreText.text = "rescued castaways: " + score.ToString();
    }

    public void GameOverTextActivator()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
