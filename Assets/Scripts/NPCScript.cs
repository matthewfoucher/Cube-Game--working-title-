using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{
    public GameObject player;
    public Text dialog;
    public RawImage box;
    private bool pressed = false;
	// Use this for initialization
	void Start ()
	{
	    dialog.text = "";
        box.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.E))
	    {
	        float distance = Vector3.Distance(transform.position, player.transform.position);
	        if (distance <= 5.0f)
	        {
	            pressed = true;
	            transform.LookAt(player.transform);
                box.gameObject.SetActive(true);
	            dialog.text = "We've all been turned into cubes by the three-headed dragon!";
	        }
            else if (pressed == true)
            {
                pressed = false;
                box.gameObject.SetActive(false);
                dialog.text = "";
            }
        }
    }
}
