using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float smoothRotationTime = 0.12f;
    public bool enableMobileInputs = false;

    float currentVeclocity;
    float currentSpeed;
    float speedVelocity;

    public FixedJoystick joystick;
    public Transform rayOrigin;
    public GameObject crossHairPrefab;
    private Animator anim;
    private Transform cameraTransform;
    Vector3 crossHairVel;
    private bool fire;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        GameObject.Find("FireBtn").GetComponent<FireBtnScript>().SetPlayer(this);
        crossHairPrefab = Instantiate(crossHairPrefab);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        Vector2 input = Vector2.zero;
        if (enableMobileInputs)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);

        }
        else { 
          input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero )
        { 
           float rotation =  Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg+ cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVeclocity, smoothRotationTime);
        }
        if (fire)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * rotation;
        }
        float tragetSpeed = MoveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, tragetSpeed, ref speedVelocity, 0.02f);

        if (inputDir.magnitude > 0)
        {
            anim.SetBool("running", true);
        }
        else if (inputDir.magnitude == 0)
        {
            anim.SetBool("running", false);

        }

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
      //  PositionCrossHair();


    }

    private void LateUpdate()
    {
        PositionCrossHair();
    }

    void PositionCrossHair()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        int layer_mask = LayerMask.GetMask("Default");
        if(Physics.Raycast(ray,out hit, 100f, layer_mask))
        {
            Vector3 start = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f));
            crossHairPrefab.transform.position = Vector3.SmoothDamp(crossHairPrefab.transform.position,ray.GetPoint(10),ref crossHairVel,0.05f);
            crossHairPrefab.transform.LookAt(Camera.main.transform);
            //  print(hit.transform.gameObject.name);

            // Vector3 hitpos = hit.point;
            // hitpos.z = hitpos.z - 1;
            // crossHairPrefab.transform.position = hitpos;
            // crossHairPrefab.transform.LookAt(Camera.main.transform);

        }
    }
    public void Fire()
    {
        fire = true;
        anim.SetTrigger("fire");
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin.position, Camera.main.transform.forward, out hit, 25f))
        {
            print(hit.transform.gameObject.name);
        }

        Debug.DrawRay(rayOrigin.position , Camera.main.transform.forward * 25f, Color.green);
    }

    

   
    public void FireUp()
    {
        fire = false;
    }
   
}
