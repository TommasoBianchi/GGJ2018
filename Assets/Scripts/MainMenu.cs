using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainScreenPanel;
    public GameObject creditsPanel;

    void Start ()
    {
		
	}

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        mainScreenPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMainScreen()
    {
        creditsPanel.SetActive(false);
        mainScreenPanel.SetActive(true);
    }
}
