using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GridLayoutGroup grid;
    public Image panel;
    private bool pressed;
    // private Rigidbody rb;

    void Start()
    {
        pressed = false;
        // rb = GetComponent<Rigidbody>();
        grid.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += (movement * speed);

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(0, -(Time.deltaTime * 50), 0);
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(0, (Time.deltaTime * 50), 0);
        }
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

    void FixedUpdate()
    {
        
    }
}