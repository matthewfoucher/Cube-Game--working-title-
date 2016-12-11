using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragonDialogue : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E) && Quests.dragon == 0)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 5.0f)
            {
                Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor so the player can click on the buttons.
                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false; // Disable the player attack script.
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false; // Freeze the player until the dialogue is over.
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false; // Turn off mouse camera control.

                // Enable dialogue GUI
                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(true);
                dialog2.gameObject.SetActive(true);
                dialog1.onClick.RemoveAllListeners();
                dialog2.onClick.RemoveAllListeners();

                dialog0.text = "Black: What do you want, cube?";

                dialog1.GetComponentInChildren<Text>().text = "DIE, DRAGON!!!";
                dialog1.onClick.AddListener(GoesAggro);
                dialog2.GetComponentInChildren<Text>().text = "Um, I come in peace.";
                dialog2.onClick.AddListener(CalmDown);

            }
        }
    }


    void GoesAggro()
    {
        Quests.dragon = 1; //1 means aggro
        // Disable dialogue GUI.
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        dialog1.onClick.RemoveAllListeners();
        dialog2.onClick.RemoveAllListeners();
        box.gameObject.SetActive(false);
        // Lock mouse cursor so it doesn't move offscreen.
        Cursor.lockState = CursorLockMode.Locked;
        // Re-enable controllers, so player can fight.
        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
    }

    /*
    void Sample()
    {
        dialog0.text = "";

        dialog1.GetComponentInChildren<Text>().text = "";
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener();

        dialog2.GetComponentInChildren<Text>().text = "";
        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener();
    }
    */

    void CalmDown()
    {
        dialog0.text = "Pink: LET'S KILL THE TINY CUBE ALREADY!\n\nGreen: Calm down. Let us hear what it has to say at least.\n\nBlack: So what is it cube? Speak.";

        dialog1.GetComponentInChildren<Text>().text = "So, uh, dragon... Dragons? Uhm. Why did you turn us all into cubes?";
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(OnceStrong);

        dialog2.onClick.RemoveAllListeners();
        dialog2.gameObject.SetActive(false);
    }

    void OnceStrong()
    {
        dialog0.text = "Black: I was once strong with magical powers. I was able to shift the shape of anything I saw. But the day I was fused together with these two buffoons, my strength was split between them. Now I can only turn things into cubes.\n\nPink: When you cube, we EAT YOU RAAWWRGH.\n\nGreen: Quite so.";

        dialog1.GetComponentInChildren<Text>().text = "Is... is there any way to change me back?";
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Painful);

        dialog2.gameObject.SetActive(true);
        dialog2.GetComponentInChildren<Text>().text = "It doesn't sound like you really like your companions...";
        dialog2.onClick.AddListener(OfCourse);
    }

    void Painful()
    {
        dialog0.text = "Green: It would be extremely painful...\n\nBlack: Yes, we can kill you, hahahaha.\n\nPink: YES YES, MORE CUBES! ARH NOM NOM!!";

        dialog1.GetComponentInChildren<Text>().text = "NOononono!";
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(GoesAggro);

        dialog2.onClick.RemoveAllListeners();
        dialog2.gameObject.SetActive(false);
    }

    void OfCourse()
    {
        dialog0.text = "Black: Of course, these idiots suck the life out of me, literally. Miss Greenie here thinks she's all smart, but she does not possess a tactical mind like I do, so I have to figure everything out. Mr. Pink is strong, but freaks out all the time. He can't control himself and just wants to eat everything.\nSo I'm the only rational one here. I control this operation and no one gives me the respect I deserve.\n\nGreen: Oh, please... You would have been killed by some random knight long ago with us.\n\nBlack: Shut. UP!\n\nPink: ME HUNGY!";

        dialog1.GetComponentInChildren<Text>().text = "Hey, Black, you're better than those other heads of yours. I could help you take out the other two to free you!";
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(Die);

        dialog2.GetComponentInChildren<Text>().text = "Hey, Mr. Pink. If you're so hungry, why don't you try eating Black and Miss Greenie? I bet they taste good!";
        dialog2.onClick.RemoveAllListeners();
        dialog2.onClick.AddListener(FOOD);
    }

    void Die()
    {
        dialog0.text = "Black: ...Cube. I can't lie that the offer would be sound.... If I didn't already know that not only would I be weakened if you kill those doofuses since we are fused together, but also that you would kill me in that weak state.\nSo, prepare to die.\n\nGreen: Unfortunately so...\n\nPink: YES DIE DIE DIE";

        dialog1.GetComponentInChildren<Text>().text = "Welp... It was worth a shot.";
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(GoesAggro);

        dialog2.onClick.RemoveAllListeners();
        dialog2.gameObject.SetActive(false);
    }

    void FOOD()
    {
        dialog0.text = "Pink: ohhh.....Yes...hmmm(Salivates)\n\nBlack: Wait, you can't be serious? Like he would just bite the mouth that feeds?\n\nGreen: Black, I think Pink may actu-\n\nBlack: Oh Miss Greenie, your stupidness is showing. Pink does as I say and would never...\n\nPink: FOOOD FOOOD FOOD FOOD FOOD (Bites Black)\n\nBlack: AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH";

        dialog1.GetComponentInChildren<Text>().text = "YES YES YES YES!";
        dialog1.onClick.RemoveAllListeners();
        dialog1.onClick.AddListener(MrPink);

        dialog2.onClick.RemoveAllListeners();
        dialog2.gameObject.SetActive(false);
    }

    void MrPink()
    {
        Quests.dragon = 4;
        //changes dragon quest to reflect the 'suicide'
        SceneManager.LoadScene("GameOver");
    }
}