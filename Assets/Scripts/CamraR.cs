using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraR : MonoBehaviour
{
    public float mouseS = 3.0f;
    public float rotationY;
    public float rotationX;
    public Transform target;
    public float distance = 65.0f;
    public Vector3 currentRotation;
    public Vector3 smoothVelocity = Vector3.zero;
    public float smoothTime = 0.2f;
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseS;
        float mouseY = Input.GetAxis("Mouse Y") * -mouseS;
        rotationY += mouseX;
        rotationX += mouseY;
        rotationX = Mathf.Clamp(rotationX, -30, 60);
        if (Input.GetMouseButton(1))
        {
            Vector3 nextRotation = new Vector3(rotationX, rotationY);
            currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
            transform.localEulerAngles = currentRotation;
            transform.position = target.position - transform.forward * distance;
        }
    }
}