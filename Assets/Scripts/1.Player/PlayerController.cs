using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
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
        transform.position += (movement * speed * Time.deltaTime);


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

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime, Space.World);
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
}