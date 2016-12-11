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


    /*
    void Update()
    {
        title.text = "GAME OVER";
        desc.text = "The Dovahkube has died. Better luck next time!";
    }
    */

	// Update is called once per frame
    void Update ()
    {
        if (Quests.dragon == 1)
        {
            title.text = "GAME OVER";
            desc.text = "The Dovahkube died while fighting the Dragon. So sad.";
        }
        if (Quests.dragon == 2)
        {
            title.text = "VICTORY";
            desc.text = "The Dovahkube has defeated the Dragon and become the legend of the ages!";
        }
        if (Quests.dragon == 3)
        {
            title.text = "CONGRATULATIONS";
            desc.text = "The Dovahkiid has defeated the Dragon and become the legend of the ages... The Dovahkube is quickly forgotten.";
        }
        if (Quests.dragon == 4)
        {
            title.text = "CONGRATULATIONS";
            desc.text = "The Dragon heads ate each other like an ouroboros chain. The Dovahkube saves the day non-violently... sort of?";
        }
        if (Quests.dragon == 5)
        {
            title.text = "HOLY SHIT!";
            desc.text = "HOW DID U KILL THE DRAGONS WITHOUT THE EPIC SWORD? WAS THAT 2 REAL TIME DAYS? TELL THE DEVS!!!";
        }
        else
        {
            title.text = "GAME OVER";
            desc.text = "The Dovahkube has died. Better luck next time!";
        }

    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
