using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Game Over scene.
public class GameOver : MonoBehaviour {


    public Text title;
    public Text desc1;
	public Text desc2;
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

	// Display the game over message that corresponds to the current state of the dragon quest.
    void Update ()
    {
        if (GlobalControl.Instance.dragon == 1)
        {
            title.text = "GAME OVER";
            desc1.text = "The Dovahkube died while fighting the Dragon. So sad.";
        }
        else if (GlobalControl.Instance.dragon == 2)
        {
            title.text = "VICTORY";
            desc1.text = "The Dovahkube has defeated the Dragon and become the legend of the ages!";
        }
        else if (GlobalControl.Instance.dragon == 3)
        {
            title.text = "CONGRATULATIONS";
            desc1.text = "The Dovahkiid has defeated the Dragon and become the legend of the ages... The Dovahkube is quickly forgotten.";
        }
        else if (GlobalControl.Instance.dragon == 4)
        {
            title.text = "CONGRATULATIONS";
            desc1.text = "The Dragon heads ate each other like an ouroboros chain. The Dovahkube saves the day non-violently... sort of?";
        }
        else if (GlobalControl.Instance.dragon == 5)
        {
            title.text = "HOLY SHIT!";
            desc1.text = "HOW DID YOU KILL THE DRAGONS WITHOUT THE EPIC SWORD? WAS THAT 2 REAL TIME DAYS? TELL THE DEVS!!!";
        }
        else
        {
            title.text = "GAME OVER";
            desc1.text = "The Dovahkube has died. Better luck next time!";
        }

        if (GlobalControl.Instance.dragon > 1)
        {
            if (GlobalControl.Instance.thief == 4 && GlobalControl.Instance.npc == 4)
            {
                desc2.text = "The thieves were killed and the NPCs are restored back to their former selves.";
            }
            else if (GlobalControl.Instance.npc > 0 && GlobalControl.Instance.npc < 4)
            {
                desc2.text = "You killed some of the NPCs, you bastard!";
            }
            else if (GlobalControl.Instance.thief == 4 && GlobalControl.Instance.npc == 0)
            {
                desc2.text = "The Dovahkube murdered everything in his path. O_O";
            }
            else if (GlobalControl.Instance.thief != 4 && GlobalControl.Instance.npc == 4)
            {
                desc2.text = "The thieves killed everyone in the town, though. Nice going!";
            }
			else if (GlobalControl.Instance.thief != 4 && GlobalControl.Instance.npc == 0)
            {
                desc2.text = "You killed all of the NPCs, you bastard!";
            }
        }
        else
        {
            desc2.text = "";
        }
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("Main Menu"); // When the player clicks the button, go back to the main menu.
    }
}
