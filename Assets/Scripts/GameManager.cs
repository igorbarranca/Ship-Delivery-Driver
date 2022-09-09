using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIUpdater uiUpdater;

    [SerializeField] float restartLevelDelay = 3f;


    private int score = 0;

    public void IncreaseScore()
    {
        score++;
        uiUpdater.UpdateScoreText(score);
    }

    public void GameOver()
    {
        //attivare game over UI
        uiUpdater.GameOverTextActivator();
        
        StartCoroutine(RestartLevel());
        //Restartare il livello con un delay in secondi
    }

    IEnumerator RestartLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        
        yield return new WaitForSeconds(restartLevelDelay);
       
        SceneManager.LoadScene(levelIndex);
    }
}
