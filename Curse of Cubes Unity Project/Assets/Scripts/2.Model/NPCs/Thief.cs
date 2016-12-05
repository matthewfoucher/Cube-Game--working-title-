using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Thief : MonoBehaviour
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

                dialog0.text = "Leave me be, or I'll cut you clean open Cube.";

                dialog1.GetComponentInChildren<Text>().text = "... Uhh Ok, you seem shady though.";

                dialog1.onClick.AddListener(Leave);
            }
        }
    }

    void Leave()
    {
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        box.gameObject.SetActive(false);
        Quests.thieves = 2;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }
}
