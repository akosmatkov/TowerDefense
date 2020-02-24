using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 5f;

    private float xAxisInput = 0;
    private float zAxisInput = 0;

    Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        xAxisInput = Input.GetAxis("Horizontal") * Time.deltaTime * cameraSpeed;
        zAxisInput = Input.GetAxis("Vertical") * Time.deltaTime * cameraSpeed;

        Vector3 position = new Vector3(xAxisInput, 0, zAxisInput);

        camera.transform.position += position;
    }
}
