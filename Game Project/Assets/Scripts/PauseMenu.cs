using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        //Afficher le menu pause
        pauseMenuUI.SetActive(true);
        //Stopper le temps 
        Time.timeScale = 0;
        //changer status du jeu 
        gameIsPaused = true;
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        //Afficher le menu pause
        pauseMenuUI.SetActive(false);
        //Stopper le temps 
        Time.timeScale = 1;
        //changer status du jeu 
        gameIsPaused = false;
    }

    public void Parametre()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseParametre()
    {
        settingsWindow.SetActive(false);
    }
    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MenuPrincipal");
    }
}
