using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour
{
    public int startingHealth = 15000; // The amount of health the enemy starts the game with.
    public int currentHealth; // The current health the enemy has.
    bool isDead; // Whether the enemy is dead.
    private DragonAttack aggro; // This will enable the dragon attack script for the dragon head.
    private DragonAttack aggroAlly; // This will enable the dragon attack script for one of the other two dragon heads.
    private DragonAttack aggroSecondAlly; // This will enable the dragon attack script for the third dragon head.
    private Dragon dragonAlly; // This will enable the dragon script for one of the other dragon heads.
    private Dragon secondDragonAlly; // This will enable the dragon script for the third dragon head.
    public GameObject otherOne; // The game object reference to the second dragon head.
    public GameObject thirdOne; // The game object reference to the third dragon head.
    private bool notAttacked; // If the dragon has not been attacked yet, this is true.

    // Use this for initialization
    void Start()
    {
        isDead = false; // Dragon is alive.
        // Setting the current health when the dragon first spawns.
        currentHealth = startingHealth;
        notAttacked = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        if (notAttacked) // If either the knight or the thief is attacked:
        {
            aggro = GetComponent<DragonAttack>(); // Get the Dragon Attack script attached to the dragon head that got attacked.
            aggroAlly = otherOne.GetComponent<DragonAttack>(); // Get the Dragon Attack script for the second dragon head.
            aggroSecondAlly = thirdOne.GetComponent<DragonAttack>(); // Get the Dragon Attack script for the third dragon head.
            dragonAlly = otherOne.GetComponent<Dragon>(); // Get the Dragon script for the second dragon head.
            secondDragonAlly = thirdOne.GetComponent<Dragon>(); // Get the Dragon script for the third dragon head.
            aggro.hostile = true; // The attacked dragon head becomes hostile.
            aggroAlly.hostile = true; // The second dragon head becomes hostile.
            aggroSecondAlly.hostile = true; // The third dragon head becomes hostile.
            notAttacked = false;
            dragonAlly.notAttacked = false;
            secondDragonAlly.notAttacked = false;
        }

        if (other.gameObject.CompareTag("PlayerSword")) // If the player's regular sword hits the enemy.
        {
            currentHealth -= 30; // Deal 30 damage.
        }

        if (other.gameObject.CompareTag("EpicSword")) // If the player's epic sword hits the enemy.
        {
            currentHealth -= 9001; // Deal over 9,000 damage.
        }

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            isDead = true; // The enemy is now dead.
            Destroy(gameObject); // Destroy the enemy's game object.
        }
    }
}
