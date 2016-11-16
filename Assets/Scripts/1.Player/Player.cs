using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int startingHealth = 100;            // The amount of health the player starts the game with.
    public int currentHealth;                   // The current health the player has.
    bool isDead; // Whether the player is dead.

    // Use this for initialization
    void Start ()
    {
        isDead = false;
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            currentHealth -= 30;
        }

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }
}
