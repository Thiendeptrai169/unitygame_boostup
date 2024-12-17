using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColliderHandle : MonoBehaviour
{
    // PARAMETER
    [SerializeField]AudioClip crashSound;
    [SerializeField]AudioClip successSound;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    // CACHE 
    AudioSource audioSource;

    // STATE 
    bool isTransitioning = false;
    bool collisionDisable = false;
     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadNextlevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = true;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisable) { return; }
        
            switch (other.gameObject.tag)
            {
                case "Begin":
                    Debug.Log("Welcome to the game!");
                    break;
                case "Finish":
                    startSequence();
                    break;
                case "Unfriendly":
                    crashSequence();
                    break;
                case "Fuel":
                    Debug.Log("You've just picked up fuel");
                    break;
                default:
                    crashSequence();
                    break;
            }
        }
    
    void crashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("reloadLevel", 2f);
    }
    void startSequence()
    {
            isTransitioning = true;
            audioSource.Stop();
            audioSource.PlayOneShot(successSound);
            successParticles.Play();
            GetComponent<Movement>().enabled = false;
            Invoke("loadNextlevel", 2f);    
      
    }
    void reloadLevel()
    {
        int currentScreenindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScreenindex);
    }
    void loadNextlevel()
    {
        int currentScreenindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScreenindex + 1);
    }
    
}
