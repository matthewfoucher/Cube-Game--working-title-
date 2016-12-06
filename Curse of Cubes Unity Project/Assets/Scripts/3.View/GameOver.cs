using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


    public Text title;
    public Text desc;
    public Button mainmenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        title.text = "GAME OVER";
        desc.text = "The Dovahkube has died. Better luck next time!";
    }


	// Update is called once per frame
	/*void Update () {
        if (Quests.dragon == 0)
        {
            title.text = "GAME OVER";
            desc.text = "The Dovahkube has died. Better luck next time!";
        }
        if (Quests.dragon == 1)
        {
            title.text = "VICTORY";
            desc.text = "The Dovahkube has defeated the dragon and become the legend of the ages!";
        }
        if (Quests.dragon == 2)
        {
            title.text = "CONGRATULATIONS";
            desc.text = "The Dovahkiid has defeated the dragon and become the legend of the ages... The Dovahkube is quickly forgotten.";
        }
    }
    */
    public void OnClickMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
