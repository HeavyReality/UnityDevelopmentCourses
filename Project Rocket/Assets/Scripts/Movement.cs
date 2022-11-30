using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody moveRigidbody;
    [SerializeField] float thrustFactor = 1000f;
    [SerializeField] float rotationFactor = 1f;

    // Start is called before the first frame update
    void Start()
    {
        moveRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("Pressed Space - Thrusting");
            moveRigidbody.AddRelativeForce( Vector3.up * thrustFactor * Time.deltaTime);
        }
    }
    void ProcessRotation(){

        if((Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.D)))
        {
            Debug.Log("Rotate Left");
            ApplyRotation(rotationFactor);
        }

        if (!(Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.D))){
            Debug.Log("Rotate Right");
            ApplyRotation(-rotationFactor);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        //Prevent physics from affecting rotation
        moveRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

        //Give physics control of rotation again
        moveRigidbody.freezeRotation = true;
    }
}