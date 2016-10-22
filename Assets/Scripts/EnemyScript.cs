using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    private bool aggro = false;
	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (aggro == false)
	    {
	        float distance = Vector3.Distance(transform.position, player.transform.position);
	        if (distance <= 20.0f)
	        {
	            aggro = true;
	            transform.LookAt(player.transform);
                
	        }
        }
    }
}
