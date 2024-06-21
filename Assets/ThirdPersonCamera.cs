using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance;

    private Vector2 look;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        look.x += Input.GetAxis("Mouse X");
        look.y += Input.GetAxis("Mouse Y");
        look.y = Mathf.Clamp(look.y, -80f, 80f);
    }

    public void FixedUpdate()
    {
        Vector3 offset = Quaternion.Euler(look.y, look.x, 0) * Vector3.forward * distance;
        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}
