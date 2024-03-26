using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rigidBody;

    [SerializeField] private float moveSpeed = 10;

    public Transform cameraRotation;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
        Vector3 forward = new Vector3(0, cameraRotation.eulerAngles.y + 45, 0);
        transform.eulerAngles = forward;
        transform.Translate(move);
    }
}
