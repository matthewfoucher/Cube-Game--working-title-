using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	//public float maxSpeed = 200f;//Replace with your max speed

    public float speed;
   	//public float jumpForce;
  //  public GridLayoutGroup grid;
    //public Camera mainCamera;
   // private bool pressed;
    private Rigidbody rb;
    /// <summary>
    /// A reference to the inventory
    /// </summary>
    public Inventory inventory;

    //Dialogue GUI for pause menu
    public Text dialog0;
    public Button dialog1;
    public Button dialog2;
    public RawImage box;
    private bool paused;

    public GameObject blood; // The pickup object for the Dovahkiid's blood.
    public GameObject epicsword; // The pickup object for the epic sword.
    public GameObject weapon; // The player's weapon.
    public GameObject epic; // The player's epic sword.

    void Start()
    {
        box.gameObject.SetActive(false);
        //  pressed = false;
        rb = GetComponent<Rigidbody>();
        epic.SetActive(false);
        paused = false;
        //  inventory.gameObject.SetActive(false); //instead of grid, inventory cus it actually disables it
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

        if (Input.GetKeyDown(KeyCode.Escape)) // Quit to main menu.
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;

                box.gameObject.SetActive(true);
                dialog0.gameObject.SetActive(true);
                dialog1.gameObject.SetActive(true);
                dialog2.gameObject.SetActive(true);
                dialog1.onClick.RemoveAllListeners();
                dialog2.onClick.RemoveAllListeners();
                GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;

                dialog0.text = "Do you want to quit back to the Main Menu?";

                dialog1.GetComponentInChildren<Text>().text = "Yes";
                dialog1.onClick.AddListener(Yes);

                dialog2.GetComponentInChildren<Text>().text = "No";
                dialog2.onClick.AddListener(No);
            }
        }

        if (Quests.dovahkiid == 1)
        {
            Instantiate(blood, gameObject.transform.position, Quaternion.identity); //give player blood item
            Quests.dovahkiid++; //1 to 2, 2 means no coop
        }

        if (Quests.epicswordquest == 4)
        {
            Instantiate(epicsword, gameObject.transform.position, Quaternion.identity); //give player epic sword
            weapon.SetActive(false); // Disable regular sword.
            epic.SetActive(true); // Enable epic sword.
            epic.GetComponent<BoxCollider>().enabled = false; // Disable epic sword's box collider until the player attacks.
            Quests.epicswordquest = 5;
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get the horizontal axis for player movement from the A and D keys.
        float moveVertical = Input.GetAxis("Vertical"); // Get the vertical axis for player movement from the W and S keys.

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Put these two movement axes into a vector.
        movement = transform.TransformDirection(movement); // Apply the proper rotation to the movement vector.
        // Move in directions relative to where the player is facing, not world space.


		rb.AddForce(movement * speed, ForceMode.VelocityChange); // Apply the movement vector to the player as a velocity change.

    }

    private void OnCollisionEnter(Collision collision) //add more item collision detection for each quest item
    {
        if (collision.gameObject.tag == "Item") //If we collide with an item that we can pick up
        {
            inventory.AddItem(collision.gameObject.GetComponent<Item>()); //Adds the item to the inventory.
            if (collision.gameObject.GetComponent<Item>().type == ItemType.WAND)
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
            Destroy(collision.gameObject);
        }
    }

    void Yes()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }

    void No()
    {
        dialog0.gameObject.SetActive(false);
        dialog1.gameObject.SetActive(false);
        dialog2.gameObject.SetActive(false);
        box.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
        paused = false;
    }
}