using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wizard : MonoBehaviour {
	public GameObject player; //So NPC can look at player

	//Dialogue GUI
	public Text dialog0;
	public Button dialog1;
	public Button dialog2;
	public RawImage box;

	private bool pressed = false;

	// Use this for initialization
	void Start () {
		box.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
		{
			GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = false;
			GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
			GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = false;

			float distance = Vector3.Distance(transform.position, player.transform.position);
			if (distance <= 5.0f)
			{
				pressed = true;
				transform.LookAt(player.transform);
				box.gameObject.SetActive(true);
				dialog0.gameObject.SetActive(true);
				dialog1.gameObject.SetActive(false);
				dialog2.gameObject.SetActive(true);

				dialog0.text = "My goodness sir, you're a cube! Just like me! How may I assist you?";
				dialog2.GetComponentInChildren<Text>().text = "Where can I find the dragon?";

				dialog2.onClick.AddListener(FindWand);
			}
			else if (pressed == true)
			{
				pressed = false;
				box.gameObject.SetActive(false);
			}
		}
	}

	void FindWand()
	{
		dialog0.text = "That three headed reptile lives in cave over yonder, as the story goes. But I am not sure where the dragon's lair may be.\n\nYou see, I did in fact try to fight the dragon, as any disgruntled cube would do. You may think it would be a simple task to take out this fire breather for a powerful and genius wizard such as myself. The problem is, wizards are not as courageous as you might think! When I got surrounded by some scruffy green cubes I slid my cube behind out of the cave faster than you can cast a spell!";
		dialog2.GetComponentInChildren<Text>().text = "If I find your wand, will you help me fight the dragon?";

		dialog2.onClick.RemoveAllListeners();
		dialog2.onClick.AddListener(Perhaps);
	}

	void Perhaps()
	{
		dialog0.text = "Perhaps, I will need to receive my wand first. My magic energy needs to recharge, you see.";
		dialog2.GetComponentInChildren<Text>().text = "Well, see you later then...";

		dialog2.onClick.RemoveAllListeners();
		dialog2.onClick.AddListener(SeeYou);
	}

	void SeeYou()
	{
		box.gameObject.SetActive(false);
		dialog0.gameObject.SetActive(false);

		GameObject.Find("Player").GetComponent<PlayerAttack>().enabled = true;
		GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
		GameObject.Find("Main Camera").GetComponent<SmoothMouseLook>().enabled = true;
	}
}

