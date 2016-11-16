using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Outside");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
