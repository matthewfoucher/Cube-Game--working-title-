using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	
	private Vector3 offset;

	
	void Start () {
		offset = transform.position - player.transform.position;
	}

    void Update()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -(Time.deltaTime*50), 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, (Time.deltaTime * 50), 0);
        }
        */
    }
	
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
