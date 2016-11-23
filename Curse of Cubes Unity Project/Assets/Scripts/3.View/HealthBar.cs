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
	    GameObject player = GameObject.Find("Player");
	    healthbar.fillAmount = (player.gameObject.GetComponent<Player>().currentHealth/100.0f);
	}
}
