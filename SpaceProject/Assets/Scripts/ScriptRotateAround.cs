using UnityEngine;
using System.Collections;

public class ScriptRotateAround : MonoBehaviour {

    public GameObject target;
    [Range(1,360)]
    public float orbitSpeed = 50.0f;

	// Update is called once per frame
	void Update () {
        transform.RotateAround(target.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
	}
}
