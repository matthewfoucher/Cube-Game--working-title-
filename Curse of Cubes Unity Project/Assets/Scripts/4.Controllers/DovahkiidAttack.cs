using UnityEngine;
using System.Collections;

public class DovahkiidAttack : MonoBehaviour {

	public float speed = 10.0f;
	public float rotSpeed = 2.0f;

	//Dragons to target
	public Transform target1;
	public Transform target2;
	public Transform target3;

	// Update is called once per frame
	void Update () {
		if (Quests.dragonCount == 3) 
		{
			//Rotates to look at the dragon
			transform.LookAt(target3.transform);

			//Go Forward
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		if (Quests.dragonCount == 2) 
		{
			//Rotates to look at the dragon
			transform.LookAt(target2.transform);

			//Go Forward
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		if (Quests.dragonCount == 1) 
		{
			//Rotates to look at the dragon
			transform.LookAt(target1.transform);

			//Go Forward
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
	}
}
