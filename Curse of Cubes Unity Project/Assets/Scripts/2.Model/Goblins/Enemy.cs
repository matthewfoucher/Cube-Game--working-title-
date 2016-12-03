using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 100; // The amount of health the enemy starts the game with.
    public int currentHealth; // The current health the enemy has.
    bool isDead; // Whether the enemy is dead.
    public GameObject health;
    private EnemyAttack aggro; // This will enable the enemy attack script for the thief or the knight when one is attacked.
    private EnemyAttack aggroAlly; // This will enable the enemy attack script for the ally of the thief or the knight.
    private Enemy enemyAlly; // This will enable the enemy script for the ally of the thief or the knight.
    public GameObject otherOne; // The game object reference to the ally of the thief or the knight.
    private bool notAttacked; // If the thief/knight has not been attacked yet, this is true.

    // Use this for initialization
    void Start()
    {
        isDead = false; // Enemy is alive.
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
        notAttacked = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        if (notAttacked && (CompareTag("Knight") || CompareTag("Thief"))) // If either the knight or the thief is attacked:
        {
            aggro = GetComponent<EnemyAttack>(); // Get the Enemy Attack script attached to the NPC that got attacked.
            aggroAlly = otherOne.GetComponent<EnemyAttack>(); // Get the Enemy Attack script for the other NPC.
            enemyAlly = otherOne.GetComponent<Enemy>(); // Get the Enemy script for the other NPC.
            aggro.hostile = true; // The attacked NPC becomes hostile.
            aggroAlly.hostile = true; // The NPC's ally becomes hostile.
            notAttacked = false;
            enemyAlly.notAttacked = false;
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
            Instantiate(health, gameObject.transform.position, Quaternion.identity); // Drop a health potion.
            Destroy(gameObject); // Destroy the enemy's game object.
        }
    }
}
