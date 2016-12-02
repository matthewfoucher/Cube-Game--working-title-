using UnityEngine;
using System.Collections;

public class Quests : MonoBehaviour {

    public static int wandquest; //once it reaches level 1, the quest is complete

	// Use this for initialization
	void Start () {
        wandquest = 0;
	}

    /*
    public void FindWand()
    {
        wandquest++;
      
        if (wandquest == 1)
            wandquest = 9;
            
        return;
    }*/
}
