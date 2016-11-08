using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GridLayoutGroup grid;
    public Image panel;
    public Camera mainCamera;
    private bool pressed;
    private Rigidbody rb;

    void Start()
    {
        pressed = false;
        rb = GetComponent<Rigidbody>();
        grid.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = transform.TransformDirection(movement);
        transform.position += (movement * speed);


        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!pressed)
            {
                grid.gameObject.SetActive(true);
                panel.gameObject.SetActive(true);
                pressed = true;
            }
            else
            {
                grid.gameObject.SetActive(false);
                panel.gameObject.SetActive(false);
                pressed = false;
            }

        }
    }

    /*void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }*/
}