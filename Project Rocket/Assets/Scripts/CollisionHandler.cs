using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip explodeAudio;
    [SerializeField] ParticleSystem successBoom;
    [SerializeField] ParticleSystem failBoom;

    AudioSource myAudio;

    bool isTransitioning = false;

    private void Start() {
        //Get the audio source when script initializes
        myAudio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning) { return; }
        switch (other.gameObject.tag)
        {
            case "Respawn":
                Debug.Log("You hit a friendly!");
                break;
            case "Finish":
                WinSequence();
                break;
            case "Fuel":
                Debug.Log("You got the fuel!");
                break;
            default:
                CrashSequence();
                break;
        }
    }

    void WinSequence()
    {
        //Sequence for successfully navigating level
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;

        myAudio.Stop();
        myAudio.PlayOneShot(successAudio);
        successBoom.Play();

        Debug.Log("Next Level! Good Job!");
        Invoke("LoadNextScene",1.5f);
    }

    void CrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        myAudio.Stop();
        myAudio.PlayOneShot(explodeAudio);
        failBoom.Play();
        Debug.Log("Oh no! You've exploded!");
        Invoke("ReloadScene", 2f);
    }

    void ReloadScene()
    {//Reload the current Scene
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = currentScene.buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings;
        string thisSceneName = SceneManager.GetActiveScene().name;

        //Logging
        Debug.Log("The next scene is: '" + thisSceneName + "'.");
        Debug.Log("Next scene should be: " + nextSceneIndex.ToString() + ". Last Scene is: " + lastSceneIndex.ToString());

        if(nextSceneIndex == lastSceneIndex)
        {
            Debug.Log("Restarting Game!");
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
