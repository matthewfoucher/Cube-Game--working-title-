using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    // private Rigidbody rb;

    void Start()
    {
       // rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += (movement * speed);

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(0, -(Time.deltaTime * 20), 0);
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(0, (Time.deltaTime * 20), 0);
        }
    }

    void FixedUpdate()
    {
        
    }
}