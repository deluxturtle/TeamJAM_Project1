using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//@Author:   Andrew Seba
//@Date:     8/28/2015
//Description: Holds and controlls ship distance from sun
public class ScriptGameController : MonoBehaviour {

    public Text textDistanceSunPlayer;

    public GameObject respawnMenu;

    //[Tooltip("Place your Camera that follows the player here.")]
    //GameObject playerCamera;
    //[Tooltip("Place your Camera that you want to use to view behind the menu.")]
    //GameObject menuCamera;
    
    //holds player and sun gameobject
    [Tooltip("Place the Player prefab here.")]
    public GameObject player;
    [Tooltip("Place the Sun prefab here.")]
    public GameObject sun;


    Vector3 distSunPlayer;

    void Start()
    {
        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(sun == null)
        {
            sun = GameObject.Find("Sun");
        }
    }

	// Update is called once per frame
	void Update () {
        //Gets the distance between the two vectors.
        distSunPlayer = new Vector3(
            sun.transform.position.x - player.transform.position.x,
            sun.transform.position.y - player.transform.position.y,
            sun.transform.position.z - player.transform.position.z);
        

        textDistanceSunPlayer.text = "Sol Distance:" + distSunPlayer.magnitude.ToString("N2");

        if(player == null && respawnMenu.gameObject.activeInHierarchy == false)
        {
            respawnMenu.gameObject.SetActive(enabled);
        }
	}


    //Click to change ship color
    //Just relized will use invoke for menu popping up to respawn.
    //IEnumerator WaitForClick()
    //{
    //    while (canChangeColors)
    //    {
    //        if (Input.GetMouseButton(0))
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            RaycastHit[] hits;
    //            hits = Physics.RaycastAll(ray, 100f);

    //            for (int i = 0; i < hits.Length; i++)
    //            {
    //                if (hits[i].collider.gameObject == GameObject.Find("Ship"))
    //                {
    //                    hits[i].collider.gameObject.GetComponent<Renderer>().material.SetColor("Color", Color.white);
    //                }
    //            }
    //        }
    //    }
    //}
    
}
