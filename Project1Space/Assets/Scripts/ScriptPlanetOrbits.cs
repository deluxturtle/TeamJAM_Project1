using UnityEngine;
using System.Collections;

public class ScriptPlanetOrbits : MonoBehaviour 
{
    [Tooltip("Point that the body orbits")]
    public Transform orbitPoint;

    [Tooltip("Axis of Orbit")]
    public float orbitalAxis = 1;
    [Tooltip("Maximum Orbital Velecity")]
	public float velocityMax = 0.4f; // Added a default incase of scene data loss. -Andrew
    [Tooltip("Minimum Orbital Velecity")]
	public float velocityMin = 0.2f; // Added a default incase of scene data loss. -Andrew
    [Tooltip("Current Orbital Velecity")]
    public float velocity;

    [Tooltip("Planetary Rotational Velecity")]
	public float rotationVelocity;

	// Use this for initialization
	void Start () 
    {
        velocity = Random.Range(velocityMin, velocityMax);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Orbit();
        Rotate();
	}

    void Orbit()
    { 
		Vector3 orbit = orbitPoint.transform.position;
        transform.RotateAround(orbit, new Vector3 (0, orbitalAxis), velocity);
    }

    void Rotate()
    {
		transform.Rotate (new Vector3(0, rotationVelocity, 0), velocity);
    }
}
