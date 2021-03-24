using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float RotationSensitivity = 8f;
    public Transform target;

    float RotationMin = -40f;
    float RotationMax = 80f;
     float smoothTime = 0.12f;

    Vector3 targetRotation;
    Vector3 currentVel;
    public bool enableMobileInputs = false;
    public FixedTouchField touchField;
    private void Start()
    {
        if (enableMobileInputs)
            RotationSensitivity = 0.2f;
    }
    void LateUpdate()
    {
        if (enableMobileInputs)
        {
            Yaxis += touchField.TouchDist.x * RotationSensitivity;
            Xaxis -= touchField.TouchDist.y * RotationSensitivity;
        }
        else { 

         Yaxis += Input.GetAxis("Mouse X")* RotationSensitivity;
         Xaxis -= Input.GetAxis("Mouse Y")* RotationSensitivity;
        }
        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);
        transform.eulerAngles = targetRotation;

        Vector3 _offset = target.position - transform.forward * 2f;
        _offset.y = 1.22f;
        transform.position = _offset;

       
    }
}
