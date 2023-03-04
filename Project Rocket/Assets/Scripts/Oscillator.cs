using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 4f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; //Each period over time is a cycle
        const float tau = Mathf.PI * 2; //Tau is Pi * 2 and is the amount of radians in a circle
        float rawSinWave = Mathf.Sin( cycles * tau ); //generating a sin wave with cycles by Tau

        movementFactor = Mathf.Abs(rawSinWave); // Absolute value of sin wave will cycle it in double the period
        //Can also be done through more complicated math
        //movementFactor = ( rawSinWave + 1 ) / 2 // averaging the movement factor will cycle the sin wave in regular speed

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }
}
