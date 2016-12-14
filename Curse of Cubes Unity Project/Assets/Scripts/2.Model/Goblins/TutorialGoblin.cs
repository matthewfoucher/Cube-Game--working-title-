using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialGoblin : MonoBehaviour
{
    public GameObject player; //So NPC can look at player

	//Dialogue GUI
    public Text dialog0;
    public Button dialog1;
    public Button dialog2;
    public RawImage box;

    private bool pressed = false;
    private EnemyAttack aggro; // Reference to the Tutorial Goblin's enemyattack script.

    // Use this for initialization
    void Start()
    {
        box.gameObject.SetActive(false); // Disable dialogue box at start.
        aggro = GetComponent<EnemyAttack>(); // Get the enemyattack script.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (aggro.hostile == false)) // If the player presses E and the tutorial goblin is not currently attacking the player,
        {
            /*
            GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;
            */
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 5.0f) // If the player is less than 5 Unity units away from the Tutorial Goblin, talk to the player.
            {
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;

                // Set up dialogue GUI, display dialogue, and call the functions for the corresponding dialogue choices that are selected.

                pressed = true;
                transform.LookAt(player.transform);
                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(true);
                dialog2.gameObject.SetActive(true);
                dialog1.onClick.RemoveAllListeners();
                dialog2.onClick.RemoveAllListeners();

                dialog0.text = "Yaargh, welcome, welcome. If yargh confused let me break down thar controls.";
                dialog1.GetComponentInChildren<Text>().text = "Um, I would rather not.";
                dialog2.GetComponentInChildren<Text>().text = "... What?";

                dialog1.onClick.AddListener(Um);
                dialog2.onClick.AddListener(What);
            }
            else if (pressed == true)
            {
                pressed = false;
                box.gameObject.SetActive(false);
            }
        }
    }

    void Um() // exits dialogue
    {
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        box.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }

    void What()
    {
        dialog0.text = "WASD to move of course. Shift to slide around real quickie. Lookie at top write, stay green to keep yar health.";
        dialog1.GetComponentInChildren<Text>().text = "What are you talking about?";
        dialog2.gameObject.SetActive(false);

        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Whatare);
    }

    void Whatare()
    {
        dialog0.text = "Move yaargh mousie around to move thar cam. Left click to attack to hearts desire. Press E to talkie... but you musta figured that out already to talk to me yarharhar.";
        dialog1.GetComponentInChildren<Text>().text = "Mousies... WHAT? I don't understand what you're saying. Why are you green too?";
        dialog2.gameObject.SetActive(false);

        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Mousies);
    }

    void Mousies()
    {
        dialog0.text = "Yarhar... Press Q to use thar health potions. Esc to escape to tha main menu. And mostie importantly press I to open up thar inventory to see all yees items.  \n\n Oh Ima green cus Ima a goblin. FITE ME!!";
        dialog1.GetComponentInChildren<Text>().text = "BRING IT!";
        dialog2.gameObject.SetActive(false);
        dialog1.onClick.RemoveAllListeners();

        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Bring);
    }

    void Bring() //exits dialogue
    {
        box.gameObject.SetActive(false);
        dialog0.gameObject.SetActive(false);
        aggro.hostile = true; // Tutorial Goblin starts attacking the player.
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }
}
