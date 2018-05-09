using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeTimer : MonoBehaviour
{

    public float maxAllowedTime = 500; // Max time allowed to player
    public float timeLimit;
    private float currentTime = 500; // Current Time in Seconds

    void Start()
    {
        currentTime = maxAllowedTime;
    }
    
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {

        }
    }
}
