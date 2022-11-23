using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // initialize Variables
    [SerializeField] float movementFactor = 10f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //Translates the position of the player based on the Horizontal/Vertical inputs
        float xValue = Input.GetAxis("Horizontal") * movementFactor * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * movementFactor * Time.deltaTime;
        transform.Translate(xValue,0,zValue);
    }

    void PrintInstructions()
    {
        //Print instructions to the log
        Debug.Log("This is a comment");
        Debug.Log("Move the player with the keyboard");
        Debug.Log("Try not to break through the walls!");
    }
}
