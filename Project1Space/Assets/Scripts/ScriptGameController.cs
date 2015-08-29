using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//@Author:   Andrew Seba
//@Date:     8/28/2015
//Description: Holds and controlls ship distance from sun
public class ScriptGameController : MonoBehaviour {

    [Tooltip("Place your ship spawn point here.")]
    public GameObject spawnPoint;

    [Tooltip("Time it takes to respawn after clicking the respawn button.")]
    public int respawnTime = 5;

    [Tooltip("Place the respawn UI messege here with Text_TimeLeft")]
    public GameObject respawnCountdown;

    [Tooltip("Place the text object for time left to respawn here.(Under The Panel RespawnMenu.")]
    public Text textTimeLeft;

    private int timeLeft;

    [Tooltip("Place your distance from Sun Text object here.")]
    public Text textDistanceSunPlayer;

    [Tooltip("Place your respawn menu here.")]
    public GameObject respawnMenu;

    bool inPlay = false;

    [Tooltip("Place your camera that you want on the ship.")]
    public Camera mainCamera;

    [Tooltip("Place the Player prefab here.")]
    public GameObject player;

    [Tooltip("Place the Sun prefab here.")]
    public GameObject sun;

    
    GameObject ship;

    Vector3 distSunPlayer;

    void Start()
    {
        //Init temp respawn variable
        timeLeft = respawnTime;
        textTimeLeft.text = timeLeft.ToString();


        if(player == null) {
            Debug.Log("Player object missing, place ship (player) prefab here.");
        }

        if(sun == null)
        {
            sun = GameObject.Find("Sun");
        }
    }


	void Update () {

        //Gets the distance between the two vectors.


        if(ship != null && sun != null)
        {
            distSunPlayer = new Vector3(
                sun.transform.position.x - ship.transform.position.x,
                sun.transform.position.y - ship.transform.position.y,
                sun.transform.position.z - ship.transform.position.z);
            textDistanceSunPlayer.text = "Sol Distance:" + distSunPlayer.magnitude.ToString("N2");

            //Begin Marshall's work for system escape prevention
            if (distSunPlayer.magnitude > 700)
            {
                Instantiate(ship.GetComponent<ScriptPlayer>().explosion, ship.transform.position, ship.transform.rotation);
                GameObject.FindGameObjectWithTag("MainCamera").transform.parent = null;
                Destroy(ship);
            }
            //End Marshall's code
        }

        if (ship != null)
        {
            mainCamera.transform.position = ship.transform.FindChild("CameraPos").transform.position;
        }

        if (ship == null && respawnMenu.gameObject.activeInHierarchy == false && inPlay && respawnCountdown.gameObject.activeInHierarchy == false)
        {
            inPlay = false;
            respawnMenu.SetActive(true);
        }
	}

    /// <summary>
    /// Spawns ship and sets inplay to true.
    /// </summary>
    public void _Spawn()
    {
        ship = Instantiate(player, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        //set rotation
        ship.transform.rotation = spawnPoint.transform.rotation;

        mainCamera.transform.parent = ship.transform;
        mainCamera.transform.rotation = ship.transform.rotation;
        inPlay = true;
    }

    /// <summary>
    /// Begins the respawn menu and countdown timer.
    /// </summary>
    public void _Respawn()
    {
        InvokeRepeating("CountDown", 1, 1);
        Debug.Log("Respawn invoked!");
        respawnCountdown.SetActive(true);
        Debug.Log("RespawnMessege should pop up.");
    }

    /// <summary>
    /// handes the countdown timer and menu.
    /// </summary>
    void CountDown()
    {

        if(timeLeft <= 0)
        {
            CancelInvoke("CountDown");
            ship = Instantiate(player, spawnPoint.transform.position, Quaternion.identity) as GameObject;
            //set rotation
            ship.transform.rotation = spawnPoint.transform.rotation;

            //Set camera to ship.
            mainCamera.transform.parent = ship.transform;
            mainCamera.transform.rotation = ship.transform.rotation;

            timeLeft = respawnTime;
            inPlay = true;
            respawnCountdown.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(timeLeft);
            timeLeft -= 1;
            textTimeLeft.text = timeLeft.ToString();
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
