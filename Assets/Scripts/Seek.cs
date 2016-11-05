using UnityEngine;
using System.Collections;


public class Seek : MonoBehaviour {

	public float speed = 10.0f;

	public float rotSpeed = 2.0f;

	public Transform target;

    private float aggro_dis = 20;

	private float min_dis = 5;

    public bool hostile; // If the enemy is hostile, this is true.

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
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
