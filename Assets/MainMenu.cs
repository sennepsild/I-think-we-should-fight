using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitSittingPosition()
    {
        SceneManager.LoadScene(0);
    }

    public void IThinkWeShouldFight()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToStandingPosition()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("quitting now");
        Application.Quit();
    }
}
