using UnityEngine;
using UnityEngine.SceneManagement;


public class Crédits : MonoBehaviour
{
   public void LoadMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenuPrincipal();
        }
    }

}
