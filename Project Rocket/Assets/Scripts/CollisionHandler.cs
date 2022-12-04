using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        Scene nextScene = SceneManager.GetSceneByBuildIndex(0);

        Debug.Log("The next scene is: '" + nextScene.name + "'.");

        switch (other.gameObject.tag)
        {
            case "Respawn":
                Debug.Log("You hit a friendly!");
                break;
            case "Finish":
                Debug.Log("Next Level! Good Job!");
                //SceneManager.LoadScene(nextScene.buildIndex);
                break;
            case "Fuel":
                Debug.Log("You got the fuel!");
                break;
            default:
                Debug.Log("Oh no! You've exploded!");
                ReloadScene();
                break;
        }

    }

    void ReloadScene()
    {//Reload the current Scene
        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = currentScene.buildIndex;

        Debug.Log("The current scene is: '" + currentScene.name + "'.");

        SceneManager.LoadScene(currentSceneIndex);
    }
}
