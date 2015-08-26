using UnityEngine;
using System.Collections;

public class ScriptPlayer : MonoBehaviour {

    [Range(0, 10)]
    public float speed = 0.1f;
    [Range(1, 100)]
    public float rotateSpeed = 10f;



    void Update()
    {
        float fowardTranslate = speed * Time.deltaTime;
        float horizontalRotate = Input.GetAxis("Horizontal") * rotateSpeed;
        float verticalRotate = Input.GetAxis("Vertical") * rotateSpeed;
        transform.Rotate(new Vector3(verticalRotate, 0, -horizontalRotate) * Time.deltaTime);
        transform.Translate(0, 0, fowardTranslate);
        
    }
}
