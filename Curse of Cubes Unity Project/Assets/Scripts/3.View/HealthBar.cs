using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HealthBar : MonoBehaviour
{

    public Image healthbar;

	// Use this for initialization
	void Start ()
	{
	    healthbar.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    GameObject player = GameObject.Find("Player"); // The health bar will be filled based on the percentage of health that the player has remaining.
	    healthbar.fillAmount = (player.gameObject.GetComponent<Player>().currentHealth/100.0f);
	}
}
