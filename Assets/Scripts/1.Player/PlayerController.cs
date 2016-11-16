using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public GridLayoutGroup grid;
    public Camera mainCamera;
    private bool pressed;
    private Rigidbody rb;

    void Start()
    {
        pressed = false;
        rb = GetComponent<Rigidbody>();
        grid.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!pressed)
            {
                grid.gameObject.SetActive(true);
                pressed = true;
            }
            else
            {
                grid.gameObject.SetActive(false);
                pressed = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 1.5f;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = transform.TransformDirection(movement);
        rb.AddForce(movement * speed, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}