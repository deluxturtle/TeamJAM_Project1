using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//@Author:   Andrew Seba
//@Date:     8/28/2015
//Description: Holds and controlls ship distance from sun
public class ScriptGameController : MonoBehaviour {

    public Text textDistanceSunPlayer;

    //[Tooltip("Place your Camera that follows the player here.")]
    //GameObject playerCamera;
    //[Tooltip("Place your Camera that you want to use to view behind the menu.")]
    //GameObject menuCamera;
    
    GameObject player;
    GameObject sun;

    Vector3 distSunPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sun = GameObject.Find("Sun");
    }

	// Update is called once per frame
	void Update () {
        //Gets the distance between the two vectors.
        distSunPlayer = new Vector3(
            sun.transform.position.x - player.transform.position.x,
            sun.transform.position.y - player.transform.position.y,
            sun.transform.position.z - player.transform.position.z);
        

        textDistanceSunPlayer.text = "Sol Distance:" + distSunPlayer.magnitude.ToString("N2");
	}

    
}
