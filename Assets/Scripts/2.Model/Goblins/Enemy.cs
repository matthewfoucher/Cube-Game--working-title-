using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public int startingHealth = 100; // The amount of health the enemy starts the game with.
    public int currentHealth; // The current health the enemy has.
    bool isDead; // Whether the enemy is dead.


    // Use this for initialization
    void Start()
    {
        isDead = false;
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Destroy(gameObject);
        }
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
