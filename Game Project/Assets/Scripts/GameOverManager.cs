using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickepUpCountOnScene);
        // Réessayer le niveau 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Recharger la scène 
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuiButton()
    {
        // Fermer le Jeu 
        Application.Quit();
    }
}
