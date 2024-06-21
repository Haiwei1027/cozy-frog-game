using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class Floater : MonoBehaviour
{
    private List<WaterVolume> waterVolumes = new List<WaterVolume>();

    private Rigidbody rigidbody;

    public bool isFloating()
    {
        return waterVolumes.Count > 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        WaterVolume waterVolume = other.GetComponent<WaterVolume>();
        if (waterVolume != null)
        {
            waterVolumes.Add(waterVolume);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WaterVolume waterVolume = other.GetComponent<WaterVolume>();
        if (waterVolume != null)
        {
            waterVolumes.Remove(waterVolume);
        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isFloating())
        {
            rigidbody.AddForce(-Physics.gravity);
        }
    }
}
