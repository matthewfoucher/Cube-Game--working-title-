using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Dialogue options for the Dovahkiid.
public class Dovahkiid : MonoBehaviour
{ 
    public GameObject player; //So NPC can look at player

    //Dialogue GUI
    public Text dialog0;
    public Button dialog1;
    public Button dialog2;
    public RawImage box;

    private bool complete;
    // Use this for initialization
    void Start()
    {
        box.gameObject.SetActive(false);
        complete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && complete == false) // If the player hasn't done the Dovahkiid's quest yet,
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 5.0f) // If the player is within talking distance,
            {
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;

                // Set up dialogue GUI, and call resulting dialogue functions.
                transform.LookAt(player.transform);
                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(true);
                dialog2.gameObject.SetActive(true);
                dialog1.onClick.RemoveAllListeners();
                dialog2.onClick.RemoveAllListeners();

                dialog0.text = "Hello, mister. I am the Dovahkiid. The kid of legend, destined to slay the dragon. Just one small problem, I got lost in this cave! Would you by any chance know the directions to him?";

                dialog1.GetComponentInChildren<Text>().text = "The dragon's that way.";
                dialog1.onClick.AddListener(ThankYou);

                dialog2.GetComponentInChildren<Text>().text = "Hey, this is a strange question, but could I have a sample of your blood?";
                dialog2.onClick.AddListener(Huh);
            }
        }
    }

    void ThankYou()
    {
        dialog0.text = "Oh thank you, mister. Say... if you are going try and fight the dragon as well, I hope we can have some jolly cooperation! See you there!";
        dialog1.GetComponentInChildren<Text>().text = "Let's kick some dragon ASS!";

        Quests.dovahkiid = 3; //3 is jolly coop
        dialog2.gameObject.SetActive(false);
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(ASS);
		gameObject.SetActive (false); // disables dovahkiid when he joins the coop for dragon, so you can't get epic sword too
    }

    void Huh()
    {
        dialog0.text = "Huh, that is a strange question, mister. But as the Savior of the Cubes, I will trust that you have good intent. Here. (The mini-cube draws blood.)";
        Quests.dovahkiid++; //0 to 1
        dialog1.GetComponentInChildren<Text>().text = "Thanks, I needed it.";
        dialog2.gameObject.SetActive(false);
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(ASS);
    }

    void ASS() //exits dialogue
    {
        dialog0.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        box.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        complete = true; //either the player gets the blood or coop

        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }
}