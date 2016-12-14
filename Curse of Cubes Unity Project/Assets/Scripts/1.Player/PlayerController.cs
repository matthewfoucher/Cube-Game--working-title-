using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed; // The speed at which the player will move.
    private Rigidbody rb; // We need to reference the player's rigidbody.
    /// <summary>
    /// A reference to the inventory
    /// </summary>
    public Inventory inventory;

    //Dialogue GUI for pause menu
    public Text dialog0;
    public Button dialog1;
    public Button dialog2;
    public RawImage box;
    private bool paused; // If true, the game is paused.

    public GameObject blood; // The pickup object for the Dovahkiid's blood.
    public GameObject epicsword; // The pickup object for the epic sword.
    public GameObject weapon; // The player's weapon.
    public GameObject epic; // The player's epic sword.

    void Start()
    {
        box.gameObject.SetActive(false); // Disable the pause menu's GUI at start.
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player.
        epic.SetActive(false); // The epic sword is disabled at start.
        paused = false; // The game is not paused at start.
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.BackQuote)) // Reset player's position (testing).
        {
            transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // While holding shift, move faster.
        {
            speed = speed * 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) // When the player lets go of shift, reset speed back to normal.
        {
            speed = speed / 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Open pause screen.
        {
            if (!paused) // Only open pause screen if the game is NOT paused. If the game is currently paused, do nothing when the player presses escape.
            {
                paused = true; // The game is now paused.
                Time.timeScale = 0.0f; // This changes Unity's passage of time. When Time.timeScale is set to 0.0f, the game is essentially paused.
                Cursor.lockState = CursorLockMode.None; // Unlock the mouse cursor, so the player can click on the pause menu options.

                // Draw the pause menu GUI.
                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(true);
                dialog2.gameObject.SetActive(true);
                dialog1.onClick.RemoveAllListeners();
                dialog2.onClick.RemoveAllListeners();
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false; // Disable the camera rotation while in the pause menu.
                GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false; // Disable the player's ability to attack while the game is paused.
                dialog0.text = "Do you want to quit back to the Main Menu?"; // Ask if the player wants to quit the game.

                dialog1.GetComponentInChildren<Text>().text = "Yes"; // If yes, quit the game.
                dialog1.onClick.AddListener(Yes);

                dialog2.GetComponentInChildren<Text>().text = "No"; // If no, resume the game.
                dialog2.onClick.AddListener(No);
            }
        }

        if (Quests.dovahkiid == 1) // If the Dovahkiid quest state is equal to 1, the player gets the Dovahkiid's blood.
        {
            Instantiate(blood, gameObject.transform.position, Quaternion.identity); //give player blood item
            Quests.dovahkiid++; //1 to 2, 2 means no coop
        }

        if (Quests.epicswordquest == 4) // If the epic sword quest state is equal to 1, we have completed the quest.
        {
            Instantiate(epicsword, gameObject.transform.position, Quaternion.identity); //give player epic sword
            weapon.SetActive(false); // Disable regular sword.
            epic.SetActive(true); // Enable epic sword.
            epic.GetComponent<BoxCollider>().enabled = false; // Disable epic sword's box collider until the player attacks.
            Quests.epicswordquest = 5; // Set epic sword quest state to 5, so we don't keep giving the player epic sword items every frame.
        }

    }

    // Physics stuff happens here.
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get the horizontal axis for player movement from the A and D keys.
        float moveVertical = Input.GetAxis("Vertical"); // Get the vertical axis for player movement from the W and S keys.

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Put these two movement axes into a vector.
        movement = transform.TransformDirection(movement); // Apply the proper rotation to the movement vector.
        // Move in directions relative to where the player is facing, not world space.


		rb.AddForce(movement * speed, ForceMode.VelocityChange); // Apply the movement vector to the player as a velocity change.

    }

    private void OnCollisionEnter(Collision collision) // add more item collision detection for each quest item
    {
        if (collision.gameObject.tag == "Item") //If we collide with an item that we can pick up
        {
            inventory.AddItem(collision.gameObject.GetComponent<Item>()); //Adds the item to the inventory.
            if (collision.gameObject.GetComponent<Item>().type == ItemType.WAND) // picking up wand
            {
                Quests.wandquest++; //quest is incremented 0 to 1
            }

            if (collision.gameObject.GetComponent<Item>().type == ItemType.FLOWER) //picking up flower
            {
                Quests.flower = true;
            }
            if (collision.gameObject.GetComponent<Item>().type == ItemType.MANA) //picking up magic
            {
                Quests.magic = true;
            }
            if(collision.gameObject.GetComponent<Item>().type == ItemType.BLOOD) //picking up blood
            {
                Quests.blood = true;
            }
            Destroy(collision.gameObject); // Destroy the world view of the game object that we just picked up.
        }
    }

    // If the player wants to quit the game,
    void Yes()
    {
        Time.timeScale = 1.0f; // Set timeScale back to 1.0. Game moves at regular speed now.
        SceneManager.LoadScene("Main Menu"); // Quit back to the main menu.
    }

    // If the player doesn't want to quit the game,
    void No()
    {
        // Turn off the pause menu GUI.
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        box.gameObject.SetActive(false);
        if (GameObject.Find("Inventory").GetComponent<Inventory>().getAlpha() == 0) // If the inventory is CLOSED:
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the mouse cursor, so we don't move the cursor offscreen while moving the camera around.
            GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true; // Re-enable the mouselook script, so we can move the camera around with the mouse again.
        }
        Time.timeScale = 1.0f; // Set timeScale back to 1.0. Game moves at regular speed now.
        paused = false; // The game is no longer paused.
        GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true; // Re-enable the player attack script.
    }
}