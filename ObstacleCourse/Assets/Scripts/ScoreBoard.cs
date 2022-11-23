using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int hitScore = 0;
    private void OnCollisionEnter(Collision other) {
        hitScore++;
        Debug.Log("You've bumped into " + hitScore.ToString() + " things!" );
    }
}
