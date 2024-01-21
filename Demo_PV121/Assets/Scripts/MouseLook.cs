using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes
    {

        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;

    [SerializeField]
    private float sensHorizontal = 9.0f;

    [SerializeField]
    private float sensVertical = 9.0f;

    [SerializeField]
    private float maxVertAngle = 45.0f;

    [SerializeField]
    private float minVertAngle = -45.0f;

    private float angleVert = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {

            angleVert -= Input.GetAxis("Mouse Y") * sensVertical;
            angleVert = Mathf.Clamp(angleVert, minVertAngle, maxVertAngle);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(angleVert, rotationY, 0);
        }
        else
        {
            angleVert -= Input.GetAxis("Mouse Y") * sensVertical;
            angleVert = Mathf.Clamp(angleVert, minVertAngle, maxVertAngle);

            float delta = Input.GetAxis("Mouse X") * sensVertical;

            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(angleVert, rotationY, 0);
        }
    }
}
