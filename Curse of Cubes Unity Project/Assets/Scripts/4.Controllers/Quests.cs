﻿using UnityEngine;
using System.Collections;

public class Quests : MonoBehaviour {

    public static int wandquest; //once it reaches level 1, the quest is complete
    public static int epicswordquest;

    public static bool flower;
    public static bool magic;
    public static bool blood;

    // Use this for initialization
    void Start () {
        wandquest = 0;
        epicswordquest = 0;

        flower = false;
        magic = false;
        blood = false;
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
