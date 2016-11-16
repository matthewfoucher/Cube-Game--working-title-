using UnityEngine;
using System.Collections;


public class Seek : MonoBehaviour {

	public float speed = 10.0f;

	public float rotSpeed = 2.0f;

	public Transform target;

    private float aggro_dis = 20;

	private float min_dis = 2.0f;

    public bool hostile; // If the enemy is hostile, this is true.

    public GameObject weapon; // The enemy's weapon.
    public float attackTimer; // The remaining time before the player can attack again.
    public float coolDown; // The total time before the player can attack again.
    private bool weaponDown; // Is the weapon in attack position?

    // Use this for initialization
    void Start () {
	    if (CompareTag("Tutorial"))
	    {
	        hostile = false;
	    }
	    else
	    {
	        hostile = true;
	    }

        attackTimer = 0;
        coolDown = 2;
        weaponDown = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;

        Debug.Log (target.position);
		if ((Vector3.Distance(transform.position, target.position) < aggro_dis) && (Vector3.Distance (transform.position, target.position) > min_dis) && (hostile)) 
		{
            /*Rotate to the target point
			Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);		
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed); 
            */

            // Rotate to look at the player.
            transform.LookAt(target.transform);

            //Go Forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}

	    if ((Vector3.Distance(transform.position, target.position) < 2.5f) && (hostile))
	    {
            // Atack the player.
            if (attackTimer == 0)
            {
                // Attack();
                weapon.transform.Rotate(0, 0, 90);
                attackTimer = coolDown;
                weaponDown = true;
                Invoke("ResetAttack", 0.1f);
            }
        }
	}

    void ResetAttack()
    {
        if (weaponDown)
        {
            weaponDown = false;
            weapon.transform.Rotate(0, 0, -90);
        }
    }
}
