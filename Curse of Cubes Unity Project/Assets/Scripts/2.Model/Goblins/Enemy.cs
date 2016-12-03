using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int startingHealth = 100; // The amount of health the enemy starts the game with.
    public int currentHealth; // The current health the enemy has.
    bool isDead; // Whether the enemy is dead.
    public GameObject health;

    // Use this for initialization
    void Start()
    {
        isDead = false; // Enemy is alive.
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;


        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;


        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

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
            isDead = true;
            Instantiate(health, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
