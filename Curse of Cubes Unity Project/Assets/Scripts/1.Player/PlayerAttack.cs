using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject weapon; // The player's weapon.
    public GameObject epic; // The player's epic sword.
    private float attackTimer; // The remaining time before the player can attack again.
    private float coolDown; // The total time before the player can attack again.
    private bool weaponDown; // Is the weapon in attack position?
    

    // Use this for initialization
    void Start()
    {
        attackTimer = 0;
        coolDown = 1;
        weaponDown = false;
        weapon.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
            attackTimer = 0;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (attackTimer == 0)
            {
                // Attack();
                if (weapon.activeSelf) // If we have the regular sword, attack with it.
                {
                    weapon.GetComponent<BoxCollider>().enabled = true;
                    weapon.transform.Rotate(0, 0, 90);
                }

                else if (epic.activeSelf) // If we have the epic sword, attack with that instead.
                {
                    epic.GetComponent<BoxCollider>().enabled = true;
                    epic.transform.Rotate(0, 0, 90);
                }

                attackTimer = coolDown;
                weaponDown = true;
                Invoke("ResetAttack", 0.2f); // Call Reset Attack after 0.2 seconds.
            }
        }
    }

    // Purpose: Put the sword back into ready position.
    void ResetAttack()
    {
        if (weaponDown)
        {
            weaponDown = false;
            if (weapon.activeSelf) // If we have the regular sword, rotate it back to ready position.
            {
                weapon.GetComponent<BoxCollider>().enabled = false;
                weapon.transform.Rotate(0, 0, -90);
            }
            else if (epic.activeSelf) // If we have the epic sword, rotate that instead.
            {
                epic.GetComponent<BoxCollider>().enabled = false;
                epic.transform.Rotate(0, 0, -90);
            }
        }
    }
}

