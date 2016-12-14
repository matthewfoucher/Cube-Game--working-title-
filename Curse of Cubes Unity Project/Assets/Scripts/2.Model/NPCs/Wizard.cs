using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// Dialogue options for the Wizard.
public class Wizard : MonoBehaviour {
	public GameObject player; //So NPC can look at player

	//Dialogue GUI
	public Text dialog0;
	public Button dialog1;
	public Button dialog2;
	public RawImage box;

    //private bool pressed = false;

    private bool complete; //quest complete? wizard will stop talking to player if done
    // Use this for initialization
    void Start () {
		box.gameObject.SetActive(false);
        complete = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && complete == false)
		{
            /*
            GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
			GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
			GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;
            */
			float distance = Vector3.Distance(transform.position, player.transform.position);
			if (distance <= 5.0f)
			{
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;
                
                //pressed = true;
                transform.LookAt(player.transform);
				box.gameObject.SetActive(true);
				dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(false);
                dialog2.gameObject.SetActive(true);
                dialog2.onClick.RemoveAllListeners();

                dialog0.text = "My goodness, sir, you're a cube! Just like me! How may I assist you?";
                
                if (Quests.wandquest == 1)
                {
					Quests.wandquest++; //1 to 2

                    dialog2.GetComponentInChildren<Text>().text = "Here's your wand... went through a lot of trouble to get it.";

                    dialog2.onClick.AddListener(Splendid);
                }
                else
                {
                    dialog2.GetComponentInChildren<Text>().text = "Where can I find the dragon?";

                    dialog2.onClick.AddListener(FindWand);
                }
			}
			/*else if (pressed == true)
			{
				pressed = false;
                box.gameObject.SetActive(false);
			}*/
		}
	}

	void FindWand()
	{
		dialog0.text = "That three-headed reptile lives in the cave over yonder, as the story goes. But I am not sure where the dragon's lair may be.\n\nYou see, I did in fact try to fight the dragon, as any disgruntled cube would do. You may think it would be a simple task to take out this fire breather for a powerful and genius wizard such as myself. The problem is, wizards are not as courageous as you might think! When I got surrounded by some scruffy green cubes, I slid my cube behind out of the cave faster than you can cast a spell!";
		dialog2.GetComponentInChildren<Text>().text = "If I find your wand, will you help me fight the dragon?";

		dialog2.onClick.RemoveAllListeners();
		dialog2.onClick.AddListener(Perhaps);
	}

	void Perhaps()
	{
		dialog0.text = "Perhaps, I will need to receive my wand first. My magic energy needs to recharge, you see.";
		dialog2.GetComponentInChildren<Text>().text = "Well, see you later then...";

		dialog2.onClick.RemoveAllListeners();
		dialog2.onClick.AddListener(SeeYou);
	}

	void SeeYou() //exits dialogue
	{
        dialog0.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        box.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
		GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
		GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
	}

    void Splendid()
    {
        dialog0.text = "Splendid! Now be about your way. I have wizard things to do.";
        dialog2.GetComponentInChildren<Text>().text = "Wait, weren't you gonna help me fight the dragon?";

        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(Err);
    }

    void Err()
    {
        dialog0.text = "Oh. Er. Uh. You got me... I am sorry, sir, but I can not. I have lied to you, a wizard trick. I can not, in fact, use magic at all in this cube form. I wanted my wand back for its sentimental value.\n\nYou are on your own, sir. But maybe... maybe the Dovahkiid can help you. He's somewhere in that cave. May the gods shine on you.";
        dialog2.GetComponentInChildren<Text>().text = "So I just did a pointless fetch quest for a wizard... Great.";

        complete = true;

        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(SeeYou);
    }
}

