using UnityEngine;
using System.Collections;

public class ScriptCameraMouse : MonoBehaviour
{

    public float lookSpeed = 200.0f;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("Player").transform.position);

        if (Input.GetMouseButton(1))
        {
            StartCoroutine("MouseMovement");

        }

    }

    IEnumerator MouseMovement()
    {
        transform.LookAt(GameObject.Find("Player").transform.position);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.RotateAround(GameObject.Find("Player").transform.position, new Vector3(mouseY, mouseX, 0), lookSpeed * Time.deltaTime);
        yield return null;
    }
}
