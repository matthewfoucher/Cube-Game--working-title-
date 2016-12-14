using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour
{

    public GameObject rock; // Reference to the rock object.

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rock.SetActive(true); // If the player walks through the trigger, spawn a big rock so the player cannot leave the dragon's cave.
        }
    }
}
