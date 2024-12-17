using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //PARAMETERS
    [SerializeField] float thSpeed = 200f, rSpeed = 200f;
    [SerializeField] ParticleSystem mainEngineparticles;
    [SerializeField] ParticleSystem leftThrusterparticles;
    [SerializeField] ParticleSystem rightThrusterparticles;

    // CACHE
    Rigidbody rb;
    AudioSource audioSource;

    // STATE


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        thrustProcess();
        rotateProcess();
    }
    void thrustProcess()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            startThrusting();
        }
        else
        {
            stopThrusting();
        }
    }
    void rotateProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotateRight();
        }
        else
        {
            stopRotate();
        }
    }
    private void startThrusting()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();

        }
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * thSpeed);
        if (!mainEngineparticles.isPlaying)
        {
            mainEngineparticles.Play();
        }
    }

    private void stopThrusting()
    {
        audioSource.Stop();
        mainEngineparticles.Stop();
    }

    private void rotateLeft()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rSpeed);
        if (!leftThrusterparticles.isPlaying)
        {
            leftThrusterparticles.Play();
        }
    }

    private void rotateRight()
    {
        transform.Rotate(-Vector3.forward, Time.deltaTime * rSpeed);
        if (!rightThrusterparticles.isPlaying)
        {
            rightThrusterparticles.Play();
        }
    }

    private void stopRotate()
    {
        rightThrusterparticles.Stop();
        leftThrusterparticles.Stop();
    }


    

  

}
