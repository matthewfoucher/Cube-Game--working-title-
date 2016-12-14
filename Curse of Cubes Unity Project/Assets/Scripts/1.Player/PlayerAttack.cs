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
        attackTimer = 0; // When the attackTime is equal to 0, the player can attack using the left mouse button.
        coolDown = 1; // The player can attack every 1.0 seconds.
        weaponDown = false; // The weapon is ready for attacking.
        weapon.GetComponent<BoxCollider>().enabled = false; // Disable the weapon's box collider. This way, enemies won't be damage if we bump into them without attacking.
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0) // If the attack is on cooldown,
            attackTimer -= Time.deltaTime; // Subtract the amount of time since the last frame.

        if (attackTimer < 0) // Reset to 0 if attackTime is less than zero.
            attackTimer = 0;

        if (Input.GetKeyDown(KeyCode.Mouse0)) // If the player clicks the left mouse button,
        {
            if (attackTimer == 0) // Attack, only if the player's attack is not still on cooldown (i.e. it has been at least 1 second since the player last attacked.)
            {
                // Attack();
                if (weapon.activeSelf) // If we have the regular sword, attack with it.
                {
                    weapon.GetComponent<BoxCollider>().enabled = true; // Enable the sword's box collider, so it can do damage.
                    weapon.transform.Rotate(0, 0, 90); // Rotate the sword down 90 degrees.
                }

                else if (epic.activeSelf) // If we have the epic sword, attack with that instead.
                {
                    epic.GetComponent<BoxCollider>().enabled = true; // Enable the sword's box collider, so it can do damage.
                    epic.transform.Rotate(0, 0, 90); // Rotate the sword down 90 degrees.
                }

                attackTimer = coolDown; // The attackTimer is now equal to the coolDown time. After 1.0 seconds, the player may attack again.
                weaponDown = true; // The weapon is currently down, meaning that it is attacking.
                Invoke("ResetAttack", 0.2f); // Call Reset Attack after 0.2 seconds.
            }
        }
    }

    // Purpose: Put the sword back into ready position.
    void ResetAttack()
    {
        if (weaponDown) // If the weapon is not currently down (attacking), leave the function because we have nothing to do.
        {
            weaponDown = false; // Set weaponDown to false. This function resets the weapon to ready position.
            if (weapon.activeSelf) // If we have the regular sword, rotate it back to ready position.
            {
                weapon.GetComponent<BoxCollider>().enabled = false; // Disable the box collider for the sword, so enemies won't take any more damage.
                weapon.transform.Rotate(0, 0, -90); // Rotate the sword up 90 degrees.
            }
            else if (epic.activeSelf) // If we have the epic sword, rotate that instead.
            {
                epic.GetComponent<BoxCollider>().enabled = false; // Disable the box collider for the sword, so enemies won't take any more damage.
                epic.transform.Rotate(0, 0, -90); // Rotate the sword up 90 degrees.
            }
        }
    }
}

