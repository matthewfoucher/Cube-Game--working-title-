using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour {

	public float speed = 10.0f;

	public float rotSpeed = 2.0f;

	public Transform target;

    private float aggro_dis = 20;

	private float min_dis = 3;

    private int health = 100;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (target.position);
		if ((Vector3.Distance(transform.position, target.position) < aggro_dis) && (Vector3.Distance (transform.position, target.position) > min_dis)) 
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

	    if (health <= 0)
	    {
	        gameObject.SetActive(false);
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health = health - 30;

            if (health < 0)
            {
                health = 0;
            }
        }
    }
}
