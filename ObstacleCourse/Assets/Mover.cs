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
        
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * movementFactor * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * movementFactor * Time.deltaTime;
        transform.Translate(xValue,0,zValue);
    }
}
