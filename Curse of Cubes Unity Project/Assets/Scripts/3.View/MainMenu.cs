using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text NewGame;
    public Text Quit;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

    }

    public void Update()
    {
        NewGame.text = "New Game";
        Quit.text = "Quit";
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
