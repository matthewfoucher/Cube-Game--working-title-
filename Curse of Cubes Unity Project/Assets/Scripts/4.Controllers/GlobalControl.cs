using UnityEngine;
using System.Collections;

// Game manager script found at: https://www.sitepoint.com/saving-data-between-scenes-in-unity/
// All credit goes to the original creators.
public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public int dragon; // The dragon quest state.
	public int thief; //thief quest state
	public int npc; //npc status 

    void Awake() // Only allow one instance of the game manager. It is a singleton.
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}