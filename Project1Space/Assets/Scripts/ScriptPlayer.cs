using UnityEngine;
using System.Collections;


//@Author:      Andrew Seba
//@Date:        8/28/2015
//@Description: Controls the player's movement and speed.
public class ScriptPlayer : MonoBehaviour {
    [Tooltip("Speed of the space ship.")]
    [Range(0, 100)]
    public float speed = 0.1f;
    [Tooltip("Speed at wich the ship can rotate at.")]
    [Range(1, 100)]
    public float rotateSpeed = 10f;

    //public Particle topFrontRightJet;
    //public Particle topBackRightJet;
    //public Particle topFrontLeftJet;
    //public Particle topBackLeftJet;



    void Update()
    {
        float fowardTranslate = speed * Time.deltaTime;
        float horizontalRotate = Input.GetAxis("Horizontal") * rotateSpeed;
        float verticalRotate = Input.GetAxis("Vertical") * rotateSpeed;
        transform.Rotate(new Vector3(verticalRotate, 0, -horizontalRotate) * Time.deltaTime);
        transform.Translate(0, 0, fowardTranslate);
        
    }
}
