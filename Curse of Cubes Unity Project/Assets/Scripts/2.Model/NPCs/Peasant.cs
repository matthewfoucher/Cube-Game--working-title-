using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Peasant : MonoBehaviour
{
    public GameObject player; //So NPC can look at player

    //Dialogue GUI
    public Text dialog0;
    public Button dialog1;
    public Button dialog2;
    public RawImage box;
    // Use this for initialization
    void Start()
    {
        box.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 5.0f)
            {
                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;

                transform.LookAt(player.transform);
                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(true);
                dialog2.gameObject.SetActive(true);
                dialog1.onClick.RemoveAllListeners();
                dialog2.onClick.RemoveAllListeners();

                dialog0.text = "Oh look another cube.";
                dialog1.GetComponentInChildren<Text>().text = "Where's the dragon?";
                dialog2.GetComponentInChildren<Text>().text = "Okay, what the hell is going on in this game?";

                dialog1.onClick.AddListener(funny1);
                dialog2.onClick.AddListener(funny2);
            }
        }
    }

    void Leave() //leaves dialogue box
    {
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        box.gameObject.SetActive(false);

        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }

    void funny1()
    {
        dialog2.gameObject.SetActive(false);
        dialog0.text = "He's over in the cave. But I think we should be more worried about the other cubes. I mean, they're all cubes with weird hats. How can we even know who they are?";
        dialog1.GetComponentInChildren<Text>().text = "Yeah, I guess the developers were pretty lazy.";

        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Leave);
    }

    void funny2()
    {
        dialog1.gameObject.SetActive(false);
        dialog0.text = "You know, it's a school project where you fight a dragon. There are a bunch of stupid jokes and a lot of unoptimized code.";
        dialog2.GetComponentInChildren<Text>().text = "Sounds about right.";

        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(Leave);
    }
}
