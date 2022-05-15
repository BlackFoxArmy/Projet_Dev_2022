using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingsPannel : MonoBehaviour
{
    public GameObject settingsWindow;
    public GameObject LoginsWindow;
    public GameObject RegistrersWindow;

    public void Login()
    {
        LoginsWindow.SetActive(true);
    }

    public void Registrer()
    {
        RegistrersWindow.SetActive(true);
    }

    public void CloseParametre()
    {
        settingsWindow.SetActive(false);
    }
}

