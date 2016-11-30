﻿using UnityEngine;
using System.Collections;

public enum ItemType {MANA, HEALTH, WEAPON, WAND, FLOWER, BLOOD};	
public enum Quality {COMMON,UNCOMMON,RARE,EPIC,LEGENDARY,ARTIFACT}

public class Item : MonoBehaviour 
{

    /// <summary>
    /// The current item type
    /// </summary>
    public ItemType type;

    /// <summary>
    /// The items quality
    /// </summary>
    public Quality quality;

    /// <summary>
    /// The item's neutral sprite
    /// </summary>
    public Sprite spriteNeutral;

    /// <summary>
    /// The item's highlighted sprite
    /// </summary>
    public Sprite spriteHighlighted;

    /// <summary>
    /// The max amount of times the item can stack
    /// </summary>
    public int maxSize;

    /// <summary>
    /// These variable contains the stats of the item
    /// </summary>
    public float strength, intellect, agility, stamina;

    /// <summary>
    /// The item's name
    /// </summary>
    public string itemName;

    /// <summary>
    /// The item's description
    /// </summary>
    public string description;


    /// <summary>
    /// Uses the item
    /// </summary>
    public void Use()
    {
        switch (type) //Checks which kind of item this is
        {
            case ItemType.HEALTH:
                GameObject player = GameObject.Find("Player");
                player.GetComponent<Player>().Heal();
                Debug.Log("I just used a health potion");
                break;
        }

    }

    public string GetTooltip()
    {
        string stats = string.Empty;  //Resets the stats info
        string color = string.Empty;  //Resets the color info
        string newLine = string.Empty; //Resets the new line

        if (description != string.Empty) //Creates a newline if the item has a description, this is done to makes sure that the headline and the describion isn't on the same line
        {
            newLine = "\n";
        }

        switch (quality) //Sets the color accodring to the quality of the item
        {
            case Quality.COMMON:
                color = "white";
                break;
            case Quality.UNCOMMON:
                color = "lime";
                break;
            case Quality.RARE:
                color = "navy";
                break;
            case Quality.EPIC:
                color = "magenta";
                break;
            case Quality.LEGENDARY:
                color = "orange";
                break;
            case Quality.ARTIFACT:
                color = "red";
                break;
        }

        //Adds the stats to the string if the value is larger than 0. If the value is 0 we dont need to show it on the tooltip
        if (strength > 0)
        {
            stats += "\n+" + strength.ToString() + " Strength";
        }
        if (intellect > 0)
        {
            stats += "\n+" + intellect.ToString() + " Intellect";
        }
        if (agility > 0)
        {
            stats += "\n+" + agility.ToString() + " Agility";
        }
        if (stamina > 0)
        {
            stats += "\n+" + stamina.ToString() + " Stamina";
        }

        //Returns the formattet string
        return string.Format("<color=" + color + "><size=16>{0}</size></color><size=14><i><color=lime>" + newLine + "{1}</color></i>{2}</size>", itemName, description, stats);
    }

    public void SetStats(Item item)
    {
        this.type = item.type;

        this.quality = item.quality;

        this.spriteNeutral = item.spriteNeutral;

        this.spriteHighlighted = item.spriteHighlighted;

        this.maxSize = item.maxSize;

        this.strength = item.strength;

        this.intellect = item.intellect;

        this.agility = item.agility;

        this.stamina = item.stamina;

        this.itemName = item.itemName;

        this.description = item.description;

        switch (type)
        {
            case ItemType.MANA:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            case ItemType.HEALTH:
                GetComponent<Renderer>().material.color = Color.red;
                break;
            case ItemType.WEAPON:
                GetComponent<Renderer>().material.color = Color.green;
                break;
			case ItemType.WAND:
				GetComponent<Renderer> ().material.color = Color.blue;
				break;
			case ItemType.FLOWER:
				GetComponent<Renderer> ().material.color = Color.red;
				break;
			case ItemType.BLOOD:
				GetComponent<Renderer> ().material.color = Color.red;
				break;
        }
    }

}
