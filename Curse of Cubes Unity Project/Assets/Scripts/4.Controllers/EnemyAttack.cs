using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour {

	public float speed = 10.0f;

	public float rotSpeed = 2.0f;

	public Transform target;

    private float aggro_dis = 20;

	private float min_dis = 2.0f;

    public bool hostile; // If the enemy is hostile, this is true.

    public GameObject weapon; // The enemy's weapon.
    public float attackTimer; // The remaining time before the enemy can attack again.
    public float coolDown; // The total time before the enemy can attack again.
    private bool weaponDown; // Is the weapon in attack position?

    // Use this for initialization
    void Start ()
    {
        hostile = false;

        attackTimer = 0;
        coolDown = 2;
        weaponDown = false;
        weapon.GetComponent<BoxCollider>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;

	    if (hostile) // Only calculate distance if the enemy is hostile. This makes the game run much faster.
	    {
            // If player is within aggro distance of goblin,
	        if ((Vector3.Distance(transform.position, target.position) < aggro_dis) && (Vector3.Distance(transform.position, target.position) > min_dis))
	        {
                // Rotate to look at the player.
                transform.LookAt(target.transform);

                //Go Forward
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }

            if (Vector3.Distance(transform.position, target.position) < 2.5f) // If player is within striking distance,
            {
                // Atack the player.
                if (attackTimer == 0)
                {
                    // Attack();
                    weapon.GetComponent<BoxCollider>().enabled = true; // Enable sword's box collider so it can do damage.
                    weapon.transform.Rotate(0, 0, 90); // Rotate sword down 90 degrees.
                    attackTimer = coolDown; // Reset attackTimer. Enemy may attack again in 2 seconds.
                    weaponDown = true; // Weapon is attacking.
                    Invoke("ResetAttack", 0.2f); // Wait 0.2 seconds, then reset the attack position of the sword.
                }
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // If the player violates the enemy's personal space,
        {
            hostile = true; // enemy is now hostile.
        }
    }

    void ResetAttack()
    {
        if (weaponDown) // Reset the weapon back to attack position.
        {
            weapon.GetComponent<BoxCollider>().enabled = false; // Disable the box collider, so it can't hurt the player anymore.
            weaponDown = false; // Weapon is not down anymore.
            weapon.transform.Rotate(0, 0, -90); // Rotate weapon up 90 degrees.
        }
    }
}
