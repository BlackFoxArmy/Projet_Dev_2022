using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{

    public string levelToLoad;

    public GameObject settingsWindow;

    public void NouvellePartie()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Parametre()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Crédits");
    }

    public void LoadLeaderBoardScene()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
    public void QuitterJeu()
    {
        Application.Quit();
    }
}
