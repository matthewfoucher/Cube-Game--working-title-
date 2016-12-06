using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

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
