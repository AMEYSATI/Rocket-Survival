using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collider : MonoBehaviour
{
    int currentscene;
    int nextscene;
    

    [SerializeField] AudioClip audiocrash;
    [SerializeField] AudioClip audiofinish;

    [SerializeField] ParticleSystem particlefinish;
    [SerializeField] ParticleSystem particlecrash;

    AudioSource audiosource;

    Movement stopmovement;

    bool isduoblecollision = false;
    //bool cheatdisable = false;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        stopmovement = GetComponent<Movement>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(isduoblecollision == true)
        {
            return;
        }
        if(collision.gameObject.tag == "Finish")
        {
            stopmovement.enabled = false;
            audiosource.PlayOneShot(audiofinish);
            isduoblecollision = true;
            particlefinish.Play();
            Invoke("scenechangeonfinish", 2);
        }
        else if(collision.gameObject.tag == "Launch")
        {
            Debug.Log("Friendly");
        }
        else
        {
            stopmovement.enabled = false;
            audiosource.PlayOneShot(audiocrash);
            isduoblecollision = true;
            particlecrash.Play();
            Invoke("scenechangeondead" , 2);
        }
        
    }

     void Update()
    {
         cheatcodescene();
    }
    void cheatcodescene()
    {
        if(Input.GetKey(KeyCode.L))
        {
            scenechangeonfinish();
        }
       
    }
    void scenechangeonfinish()
    {
        currentscene = SceneManager.GetActiveScene().buildIndex;
        nextscene = currentscene + 1;
        if (nextscene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextscene);
        }
        else
        {
            nextscene = 0;
            SceneManager.LoadScene(nextscene);
        }
    }
    void scenechangeondead()
    {
        currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }
}
