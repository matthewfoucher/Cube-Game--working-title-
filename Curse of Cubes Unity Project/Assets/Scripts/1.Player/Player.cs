using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int startingHealth = 100;            // The amount of health the player starts the game with.
    public int currentHealth;                   // The current health the player has.
    bool isDead; // Whether the player is dead.
    private int healAmount;

    // Use this for initialization
    void Start ()
    {
        isDead = false;
        currentHealth = startingHealth;
        healAmount = 40;
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            currentHealth -= 10;
        }

        if (other.gameObject.CompareTag("Pit"))
        {
            isDead = true;
        }

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fireball"))
        {
            currentHealth -= 30;
        }

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }

    // Heals the player when using a health potion. Called by Inventory script.
    public void Heal()
    {
        if (currentHealth == 100) // We don't need to heal. Tell the Inventory script not to delete the health potion.
        {
            return;
        }
        else
        {
            currentHealth += healAmount;
            if (currentHealth > 100)
            {
                currentHealth = 100;
            }
        }
    }
}
