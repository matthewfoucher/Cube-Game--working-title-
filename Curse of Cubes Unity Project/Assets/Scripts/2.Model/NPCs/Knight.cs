using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// Dialogue options for the Knight.
public class Knight : MonoBehaviour {
    public GameObject player; //So NPC can look at player

    //Dialogue GUI
    public Text dialog0;
    public Button dialog1;
    public Button dialog2;
    public RawImage box;
    // Use this for initialization
    void Start () {
        box.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && Quests.thieves != 3)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 5.0f)
            {
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;

                transform.LookAt(player.transform);
                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(true);
                dialog2.gameObject.SetActive(false);
                dialog1.onClick.RemoveAllListeners();

                dialog0.text = "Excuse you, I am busy on guard duty. Do not disturb me.";
                if (Quests.thieves == 2)
                {
                    dialog1.GetComponentInChildren<Text>().text = "There's this shady cube hanging around in the forest, you should probably check on that.";

                    dialog1.onClick.AddListener(NoWorry);
                }
                else
                {
                    dialog1.GetComponentInChildren<Text>().text = "Sorry!";

                    dialog1.onClick.AddListener(Leave);
                }
            }
        }
    }

    void Leave()
    {
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        box.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }

    void NoWorry()
    {
        dialog0.text = "Hmmmm uh. (Coughs) Excuse me, but I wouldn't worry about that. Please go about your way as I have to go back to standing around- I mean uh guarding.";
        dialog1.GetComponentInChildren<Text>().text = "If you say so...";

        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Leave);
    }
}
