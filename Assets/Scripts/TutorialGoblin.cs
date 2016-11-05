using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialGoblin : MonoBehaviour
{
    public GameObject player;
    public Text dialog1;
    public Text dialog2;
    public Text dialog3;
    public RawImage box;
    private bool pressed = false;
    private Seek aggro;
    int dialogueLevel; // Which part of the dialogue we are in.
    // Use this for initialization
    void Start()
    {
        dialog1.text = "";
        dialog2.text = "";
        dialog3.text = "";
        box.gameObject.SetActive(false);
        dialogueLevel = 0;
        aggro = GetComponent<Seek>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 5.0f)
            {
                pressed = true;
                transform.LookAt(player.transform);
                box.gameObject.SetActive(true);
                dialog1.text = "Yaargh, welcome, welcome. If yargh confused, let me break down thar controls.";
                dialog2.text = "1. Um, I would rather not.";
                dialog3.text = "2. ...What?";
                dialogueLevel = 1;

            }
            else if (pressed == true)
            {
                pressed = false;
                box.gameObject.SetActive(false);
                dialog1.text = "";
                dialog2.text = "";
                dialog3.text = "";
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switch (dialogueLevel)
            {
                case 1:
                    dialog1.text = "";
                    dialog2.text = "";
                    dialog3.text = "";
                    dialogueLevel = 0;
                    box.gameObject.SetActive(false);
                    break;
                case 2:
                    dialog1.text = "Move yaargh mousie around to move thar cam. But that isn't available in this version yet! Left click to attack to yaargh heart's desire. Move thar cross hairs over an item to put it in yur pocket (coming soon), or over someone and press E to talkie... but you musta figured that out already to talk to me yarharhar.";
                    dialog2.text = "1. Mousies... WHAT? I don't understand what you're saying. Why are you green, too?";
                    dialog3.text = "";
                    dialogueLevel = 3;
                    break;
                case 3:
                    dialog1.text = "Yarhar... Press Q to use tha health potions. And mostie importantly, press I to open up thar inventory to see all yees items, and J for thar questies. The developers have been sleeping a lot lately, so some of these features might not work yet.\n\nOh, I'ma green cus I'ma a goblin. FITE ME!!";
                    dialog2.text = "";
                    dialog3.text = "";
                    dialogueLevel = 4;
                    break;
                case 4:
                    dialog1.text = "";
                    dialog2.text = "";
                    dialog3.text = "";
                    box.gameObject.SetActive(false);
                    aggro.hostile = true;
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switch (dialogueLevel)
            {
                case 1:
                    dialog1.text = "WASD to move, of course. Space to hop hop. Shift to slide around real quickie.";
                    dialog2.text = "1. What are you talking about?";
                    dialog3.text = "";
                    dialogueLevel = 2;
                    break;
                case 2:
                    dialog1.text = "";
                    dialog2.text = "";
                    dialog3.text = "";
                    break;
                case 3:
                    dialog1.text = "";
                    dialog2.text = "";
                    dialog3.text = "";
                    dialogueLevel = 4;
                    break;
                case 4:
                    dialog1.text = "";
                    dialog2.text = "";
                    dialog3.text = "";
                    box.gameObject.SetActive(false);
                    aggro.hostile = true;
                    break;
                default:
                    break;
            }
        }
    }
}
