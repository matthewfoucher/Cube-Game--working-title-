﻿using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{


    private bool render = false;

    void OnGUI()
    {
        if (render)
        {
            // Make a background box
            GUI.Box(new Rect(10, 10, 100, 90), "Inventory");
        }
    }

    void ToggleWindow()
    {
        render = !render;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleWindow();
        }
    }
}

