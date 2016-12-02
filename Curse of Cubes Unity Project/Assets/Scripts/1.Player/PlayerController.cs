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

    void Start()
    {
      //  pressed = false;
        rb = GetComponent<Rigidbody>();
      //  inventory.gameObject.SetActive(false); //instead of grid, inventory cus it actually disables it
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //why repeat?
        {
            speed = speed / 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
			
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = transform.TransformDirection(movement); // is this still being used?


		rb.AddForce(movement * speed, ForceMode.VelocityChange); 

		/* No need for Jump
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			rb.AddForce (Vector3.up * jumpForce);

		}*/

		/*
		if(rb.velocity.magnitude > maxSpeed) //possibly needs to be in update
		{
			//rb.velocity = rb.velocity.normalized * maxSpeed;
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}
		*/
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") // If we collide with an item that we can pick up 
        {
            inventory.AddItem(other.GetComponent<Item>()); // Adds the item to the inventory.
        }
    }*/

    private void OnCollisionEnter(Collision collision) //add more item collision detection for each quest item
    {
        if (collision.gameObject.tag == "Item") //If we collide with an item that we can pick up
        {
            inventory.AddItem(collision.gameObject.GetComponent<Item>()); //Adds the item to the inventory.
            if (collision.gameObject.GetComponent<Item>().type == ItemType.WAND)
            {
                Quests.wandquest++; //quest is incremented 0 to 1
            }
            Destroy(collision.gameObject);
        }
    }
}