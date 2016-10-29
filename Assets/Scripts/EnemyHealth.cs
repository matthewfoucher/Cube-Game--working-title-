using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    bool isDead;                                // Whether the enemy is dead.

    BoxCollider boxCollider;            // Reference to the capsule collider.

    // Use this for initialization
    void Start () {
        boxCollider = GetComponent<BoxCollider>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
	    if (isDead)
	    {
            gameObject.SetActive(false);
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
}
