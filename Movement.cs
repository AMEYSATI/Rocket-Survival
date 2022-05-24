using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float tspeed = 100f;
    [SerializeField] float rspeed = 20f;

    [SerializeField] ParticleSystem rocketboost;
    [SerializeField] ParticleSystem sideboost1;
    [SerializeField] ParticleSystem sideboost2;

    AudioSource audiosource;
    [SerializeField]AudioClip audiothrust;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        thrust();
        planerotation();
        quit();
    }
    void thrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            startthrusting();
        }
        else
        {
            audiosource.Stop();
            rocketboost.Stop();
        }
    }

    void startthrusting()
    {
        rb.AddRelativeForce(Vector3.up * tspeed * Time.deltaTime);
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(audiothrust);
        }
        if (!rocketboost.isPlaying)
        {
            rocketboost.Play();
        }
    }

    void planerotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            planerotationleft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            planerotationright();

        }
        else
        {
            sideboost1.Stop();
            sideboost2.Stop();
        }
    }

    void planerotationright()
    {
        applyplanerotation(-rspeed);
        if (sideboost2.isPlaying)
        {
            sideboost2.Play();
        }
    }

    void planerotationleft()
    {
        applyplanerotation(rspeed);
        if (!sideboost1.isPlaying)
        {
            sideboost1.Play();
        }
    }

    void applyplanerotation(float rotatespeed)
    {
        transform.Rotate(Vector3.forward * rotatespeed * Time.deltaTime);
        
    }
     void quit()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
