using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Réalisé par Simon*/

public class MainMenuManager : MonoBehaviour
{
    public GameObject GameMenuPanel;
    public GameObject HowToPanel;
    public GameObject CreditsPanel;

    public Animator animator;

    public void btn_load_scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }

    public void LaunchHowToPlay()
    {
        animator.SetTrigger("Start");
    }

    public void LaunchMainMenu()
    {
        animator.SetTrigger("LaunchMainMenu");
    }

    public void LaunchCredits()
    {
        animator.SetTrigger("LaunchCredits");
    }

    public void LaunchGame()
    {
        animator.SetTrigger("LaunchGame");
    }

    public void GoHowToPlay()
    {
        HowToPanel.SetActive(true);
        GameMenuPanel.SetActive(false);
    }

    public void GoToCredits()
    {
        CreditsPanel.SetActive(true);
        GameMenuPanel.SetActive(false);
    }

    public void ReturnMenu()
    {
        GameMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        HowToPanel.SetActive(false);
    }
}
