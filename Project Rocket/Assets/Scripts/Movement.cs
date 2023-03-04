using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustFactor = 1000f;
    [SerializeField] float rotationFactor = 1f;
    [SerializeField] AudioClip mainThrust;
    [SerializeField] ParticleSystem leftJet;
    [SerializeField] ParticleSystem rightJet;
    [SerializeField] ParticleSystem leftThrust;
    [SerializeField] ParticleSystem rightThrust;

    AudioSource moveAudio;
    Rigidbody moveRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        moveRigidbody = GetComponent<Rigidbody>();
        moveAudio = GetComponent<AudioSource>();
        Debug.Log("Audio Clip:" + moveAudio.clip.name);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Pressed Space - Thrusting");
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        if (!moveAudio.isPlaying)
        {
            moveAudio.PlayOneShot(mainThrust);
            leftJet.Play();
            rightJet.Play();
        }

        moveRigidbody.AddRelativeForce(Vector3.up * thrustFactor * Time.deltaTime);
    }

    void StopThrusting()
    {
        if (moveAudio.isPlaying)
        {
            moveAudio.Stop();
            leftJet.Stop();
            rightJet.Stop();
        }
    }

    void ProcessRotation(){

        if((Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.D)))
        {
            Debug.Log("Rotate Left");
            RotateLeft();
        }
        else if (!(Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.D)))
        {
            Debug.Log("Rotate Right");
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    void RotateRight()
    {
        if (!leftThrust.isPlaying)
        {
            leftThrust.Play();
        }
        ApplyRotation(-rotationFactor);
    }

    void RotateLeft()
    {
        ApplyRotation(rotationFactor);
        if (!rightThrust.isPlaying)
        {
            rightThrust.Play();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        //Prevent physics from affecting rotation
        moveRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

        //Give physics control of rotation again
        moveRigidbody.freezeRotation = false;
    }

    private void StopRotation()
    {
        leftThrust.Stop();
        rightThrust.Stop();
    }
}
