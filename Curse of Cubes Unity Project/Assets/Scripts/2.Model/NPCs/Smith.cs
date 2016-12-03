using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Smith : MonoBehaviour
{
    public GameObject player; //So NPC can look at player

    private int complete;

    //Dialogue GUI
    public Text dialog0;
    public Button dialog1;
    public Button dialog2;
    public RawImage box;

    // Use this for initialization
    void Start()
    {
        complete = 0;
        box.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && complete < 4)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 5.0f)
            {

                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;

                //pressed = true;
                transform.LookAt(player.transform);
                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(false);
                dialog2.gameObject.SetActive(false);
                dialog1.onClick.RemoveAllListeners();
                dialog2.onClick.RemoveAllListeners();
                if (complete < 3)//if the player is doing the fetch quest
                {
                    dialog0.text = "Morn' pal. This is me smith";
                    if (Quests.magic == true && Quests.blood == true) //if the player is holding both flower and blood
                    {
                        dialog2.gameObject.SetActive(true);
                        dialog2.GetComponentInChildren<Text>().text = "I found the magic.";
                        dialog2.onClick.AddListener(Magic);
                    }
                    else if (Quests.flower == true) //if player has the flower
                    {
                
                        dialog1.gameObject.SetActive(true);
                        dialog1.GetComponentInChildren<Text>().text = "I found the flower.";

                        dialog1.onClick.AddListener(Flower);
                    }
                    else if (Quests.magic == true) //if player has the magic
                    {
                       
                        dialog2.gameObject.SetActive(true);
                        dialog2.GetComponentInChildren<Text>().text = "I found the magic.";
                        dialog2.onClick.AddListener(Magic);
                    }
                    else if (Quests.blood == true)//if player has the blood
                    {
                        dialog2.gameObject.SetActive(true);
                        dialog2.GetComponentInChildren<Text>().text = "I got the Dovahkiid's blood.";
                        dialog2.onClick.AddListener(Blood);
                    }
                    else //if quest has not started. 
                    {
                        dialog2.gameObject.SetActive(true);
                        dialog2.GetComponentInChildren<Text>().text = "Do you know where the dragon is?";
                        dialog2.onClick.AddListener(HeBe);
                    }
                }
                else //if the player completed the fetch quest
                {
                    dialog0.text = "Praise be ta tha gods! With this sword, ye can be able to slay the dragon! Tha dovahkiid failed us, so me dub ye a new savior. Ye be the Dovahkube!";
                    Quests.epicswordquest = 4; //removes sword, gives player epic sword
                    complete++;
                    dialog2.gameObject.SetActive(true);
                    dialog2.GetComponentInChildren<Text>().text = "Thank you, I the Dovahkube will not disappoint you.";
                    dialog2.onClick.AddListener(Sure);
                }
            }
        }
    }

    void HeBe()
    {
        dialog0.text = "He be in tha cave right over yonder. But findin' em ain't be tha hard part. Ay, you would be smart to come prepared. Tha sword ye be holdin' there wouldn't leave a scratch!";
        dialog2.GetComponentInChildren<Text>().text = "How do I hurt the dragon?";

        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(Luckily);
    }

    void Luckily()
    {
        dialog0.text = "Luckily ye be talkin' to the best smith in tha land! I can forge an epic sword that'll smack the scales off tha dragon's behind! But only if ye be willin' ta find me tha materials.";
        dialog2.GetComponentInChildren<Text>().text = "Sure I'll look for them.";

        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(Sure);
    }

    void Sure() //exits dialogue
    {
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        box.gameObject.SetActive(false);

        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }

    void Flower()
    {
        complete++;
        Quests.epicswordquest = 1; //removes flower
        Quests.flower = false; //since item removed, back to false and so the option doesnt show up when re-talking to smith
        dialog0.text = "Gimme tha flower... Smells spicy. Thank ye.\nFind the rest of tha items.";
        dialog1.GetComponentInChildren<Text>().text = "Alright.";

        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Sure);
    }

    void Magic()
    {
        complete++;
        Quests.epicswordquest = 2; //removes magic
        Quests.magic = false;
        dialog0.text = "Gimme tha magic... Tha Wizard be jealous if ye told him I had this!\nDon't forget to find the rest of tha items.";
        dialog2.GetComponentInChildren<Text>().text = "Ok.";

        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(Sure);
    }

    void Blood()
    {
        complete++;
        Quests.epicswordquest = 3; //removes blood
        Quests.blood = false;
        dialog0.text = "Gimme tha blood... I be glad that tha lil punk is gone now. If he can't save us, ye Dovahkube will. Now find tha rest of the items.";
        dialog2.GetComponentInChildren<Text>().text = "K.";

        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(Sure);
    }
}
