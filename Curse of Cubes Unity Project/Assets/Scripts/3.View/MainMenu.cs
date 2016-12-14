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
        SceneManager.LoadScene("Outside"); // The Outside scene is the main game scene. Load it when the player clicks on New Game.
    }

    public void OnClickQuit()
    {
        Application.Quit(); // Quit the game if the player clicks on quit. This only works in the built version of the game, not the editor.
    }
}
