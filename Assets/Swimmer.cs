using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Floater))]
public class Swimmer : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private Vector3 move;

    private Rigidbody rigidbody;
    private Transform camera;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
    }

    private void Update()
    {
        //move.x = Input.GetAxis("Horizontal");
        move.z = Mathf.Clamp(Input.GetAxis("Vertical"),0,1);
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(camera.TransformDirection(move) * moveSpeed);

        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(camera.transform.forward, Vector3.up), 
            Time.deltaTime * turnSpeed);
    }
}
