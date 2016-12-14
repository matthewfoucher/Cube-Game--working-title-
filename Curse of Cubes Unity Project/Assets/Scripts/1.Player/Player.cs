using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public int startingHealth = 100;            // The amount of health the player starts the game with.
    public int currentHealth;                   // The current health the player has.
    bool isDead; // Whether the player is dead.
    private int healAmount; // The amount for which the player will be healed upon using a health potion.

    // Use this for initialization
    void Start ()
    {
        isDead = false; // The player is not dead.
        currentHealth = startingHealth; // The player starts with 100 health.
        healAmount = 40; // The player will be healed for 40 health upon using a health potion.
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead) // If the player is dead,
        {
            GlobalControl.Instance.dragon = Quests.dragon; // we need to tell the game manager to save the state of the dragon quest, so it can be accessed in the game over scene.
            SceneManager.LoadScene("GameOver"); // The player died. Load the game over scene so we can tell the player why the game ended,
            // and give them the option to start a new game.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword")) // If the player got hit by the goblin's sword,
        {
            currentHealth -= 10; // Take 10 damage. This may be applied multiple times depending on how many points of contact were hit on the box collider.
            // This multiplicative damage is considered to be a critical hit in the context of our game.
        }

        if (other.gameObject.CompareTag("Pit")) // If the player falls into the dragon's pit:
        {
            isDead = true; // The player dies. Load the game over scene.
        }

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Reset the health to zero,
            isDead = true; // and kill the player.
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fireball")) // If the player gets hit by the dragon's fireball,
        {
            currentHealth -= 30; // take 30 damage.
        }

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Reset the health to zero,
            isDead = true; // and kill the player.
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
            currentHealth += healAmount; // Heal the player for healAmount. The value for healAmount is defined in Start();
            if (currentHealth > 100) // If the player got healed past its maximum health,
            {
                currentHealth = 100; // Set the player's health back to 100.
            }
        }
    }
}
