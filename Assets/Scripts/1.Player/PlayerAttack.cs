using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject weapon; // The player's weapon.
    public float attackTimer; // The remaining time before the player can attack again.
    public float coolDown; // The total time before the player can attack again.
    private bool weaponDown; // Is the weapon in attack position?
    

    // Use this for initialization
    void Start()
    {
        attackTimer = 0;
        coolDown = 1;
        weaponDown = false;
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
                weapon.transform.Rotate(0, 0, 90);
                attackTimer = coolDown;
                weaponDown = true;
                Invoke("ResetAttack", 0.2f);
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

    private void Attack()
    {
        
    }
}

