using UnityEngine;
using System.Collections;

public class DragonAttack : MonoBehaviour {
    public bool hostile; // If the enemy is hostile, this is true.
    public float attackTimer = 0.0f; // The remaining time before the player can attack again.
    public float coolDown = 5.0f; // The total time before the player can attack again.
    private bool jawsOpen; // This is true if the dragon has its mouth open.
    public GameObject upperJaw; // The dragon's upper jaw.
    public GameObject lowerJaw; // The dragon's lower jaw.
    public GameObject fireball; // The dragon's fireball attack.

    // Use this for initialization
    void Start () {
        hostile = false; // Dragon is not hostile. Dragon won't attack.
        jawsOpen = false; // Dragon's jaws are closed.
    }
	
	// Update is called once per frame
	void Update () {
        if (attackTimer > 0) // Dragon attacks every 5 seconds. If dragon's attackTimer is on cooldown,
            attackTimer -= Time.deltaTime; // Subtract the amount of time that has passed since the last frame.

        if (attackTimer < 0) // If attackTimer goes below 0,
            attackTimer = 0; // Reset to 0.

	    if (hostile || Quests.dragon == 1) // If the dragon is hostile, or the dragon has initiated attack due to dialogue,
	    {
            // Atack the player.
	        if (attackTimer == 0)
	        {
                upperJaw.transform.Rotate(-30, 0, 0); // Rotate the dragon's upper jaw up 30 degrees,
                lowerJaw.transform.Rotate(30, 0, 0); // and the lower jaw down 30 degrees, so the dragon's mouth appears open.
                attackTimer = coolDown; // Dragon may attack again after 5.0 seconds.
                jawsOpen = true; // Dragon's jaws are open.
                // Instantiate(fireball, gameObject.transform.position, Quaternion.identity); // Drop a big fireball.
	            Vector3 spawnPosition = gameObject.transform.position + new Vector3(0, -3, 3); // Spawn the fireball in a specific position near the dragon's jaws.
	            Instantiate(fireball, spawnPosition, Quaternion.Euler(90, 0, 0)); // Rotate fireball so it faces straight down.
                Invoke("ResetAttack", 2.0f); // Wait 2.0 seconds, then call dragon's ResetAttack function.
            }

        }
    }

    // Reset the dragon back to non-attacking position.
    void ResetAttack()
    {
        if (jawsOpen) // If the jaws are open,
        {
            upperJaw.transform.Rotate(30, 0, 0); // Close the dragon's jaws.
            lowerJaw.transform.Rotate(-30, 0, 0);
            jawsOpen = false;
        }
    }
}
