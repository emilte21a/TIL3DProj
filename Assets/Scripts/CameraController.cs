using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    Vector3 vec = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime = 0.14f;

    [Range(100, 752)]
    public float sensitivity = 10;

    float yRotation = 0;

    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref vec, smoothTime);

        if (Input.GetMouseButton(1) || (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftAlt)))
        {
            yRotation += Input.GetAxis("Mouse X") * Time.deltaTime;
        }

        Vector3 v = new Vector3(0, yRotation, 0) * sensitivity;

        transform.eulerAngles = v;

    }
}
