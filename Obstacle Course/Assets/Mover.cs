using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float xMoveValue = 0;
    [SerializeField] float yMoveValue = 0.01f;
    [SerializeField] float zMoveValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(xMoveValue,yMoveValue,zMoveValue); 
    }
}
