using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMoveValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yMoveValue = 0f * moveSpeed;
        float zMoveValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate( xMoveValue, yMoveValue, zMoveValue ); 
    }
}
