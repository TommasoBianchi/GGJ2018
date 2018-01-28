using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public Timer timer;
    public int maxTime;
    public int killsToWin;

    public GameObject victoryPanel;
    public GameObject gameOverPanel;

    public string nextScene;

    void Start ()
    {
        timer.totalTime = maxTime;
        GameManager.Initialize();
	}

    void Update()
    {
        if (GameManager.killCounter >= killsToWin)
        {
            timer.enabled = false;
            victoryPanel.SetActive(true);
            StartCoroutine(DoAfter(5, () => SceneManager.LoadScene(nextScene)));
        }
    }

    public void GameOver()
    {
        timer.enabled = false;
        gameOverPanel.SetActive(true);
        StartCoroutine(DoAfter(5, () => SceneManager.LoadScene("MainMenu")));
    }

    IEnumerator DoAfter(float seconds, System.Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }
}
