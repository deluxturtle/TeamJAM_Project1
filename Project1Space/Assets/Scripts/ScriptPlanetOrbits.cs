using UnityEngine;
using System.Collections;

public class ScriptPlanetOrbits : MonoBehaviour 
{
    public Transform orbitPoint;
    public float orbitalVelocity;

	public float inclinationMax;
	public float inclinationMin;
    public float inclination;

	public float rotationVelocity;

	// Use this for initialization
	void Start () 
    {
        inclination = Random.Range(inclinationMin, inclinationMax);
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
        transform.RotateAround(orbit, new Vector3 (0, orbitalVelocity), inclination);
    }

    void Rotate()
    {
		transform.Rotate (new Vector3(0, rotationVelocity, 0), inclination);
    }
}
