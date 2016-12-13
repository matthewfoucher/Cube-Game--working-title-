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
        hostile = false;
        jawsOpen = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;

	    if (hostile || Quests.dragon == 1)
	    {
            // Atack the player.
	        if (attackTimer == 0)
	        {
                upperJaw.transform.Rotate(-30, 0, 0);
                lowerJaw.transform.Rotate(30, 0, 0);
                attackTimer = coolDown;
                jawsOpen = true;
                // Instantiate(fireball, gameObject.transform.position, Quaternion.identity); // Drop a big fireball.
	            Vector3 spawnPosition = gameObject.transform.position + new Vector3(0, -3, 3);
	            Instantiate(fireball, spawnPosition, Quaternion.Euler(90, 0, 0));
                Invoke("ResetAttack", 2.0f);
            }

        }
    }

    void ResetAttack()
    {
        if (jawsOpen)
        {
            upperJaw.transform.Rotate(30, 0, 0);
            lowerJaw.transform.Rotate(-30, 0, 0);
            jawsOpen = false;
        }
    }
}
