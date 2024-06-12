using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterVolume : MonoBehaviour
{
    public int underwaterRendererId = 1;
    public int surfaceRendererId = 0;
    public float switchThreshold = 0.001f;

    Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        Camera camera = Camera.main;
        if (Vector3.Distance(camera.transform.position, GetComponent<Collider>().ClosestPoint(camera.transform.position)) < switchThreshold)
        {
            camera.GetUniversalAdditionalCameraData().SetRenderer(underwaterRendererId);
        }
        else
        {
            camera.GetUniversalAdditionalCameraData().SetRenderer(surfaceRendererId);
        }
    }
}
