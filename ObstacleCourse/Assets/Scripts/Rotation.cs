using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float xAngle = 0f;
    [SerializeField] float yAngle = 0.5f;
    [SerializeField] float zAngle = 0f;
    [SerializeField] bool flipRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        if(flipRotation){
            xAngle = xAngle * -1f;
            yAngle = yAngle * -1f;
            zAngle = zAngle * -1f;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle,yAngle,zAngle);
    }
}
