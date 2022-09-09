using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject creditsText;
    [SerializeField] float loadGameDelay = 2.5f;

    public void LoadGame()
    {
        AudioPlayer.instance.PlayStartGameClip();
        StartCoroutine(WaitAndLoad("Game", loadGameDelay));
    }

    public void LoadCredits()
    {
        AudioPlayer.instance.PlayCreditsSound();
        creditsText.SetActive(true);
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
