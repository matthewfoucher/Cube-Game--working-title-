using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour
{

    public GameObject rock; // Reference to the rock object.
	public GameObject kiid;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rock.SetActive(true); // If the player walks through the trigger, spawn a big rock so the player cannot leave the dragon's cave.
			if (Quests.dovahkiid == 3) //If the dovahkiid quest was accepted, activate him.
			{
				kiid.SetActive (true);
			}
		}
    }
}
