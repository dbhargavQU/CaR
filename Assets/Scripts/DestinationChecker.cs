using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChecker : MonoBehaviour
{
    private int currentDestination;

    [SerializeField] private LoadScene Load;
    [SerializeField] private SplineFollower Car;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDestination(int destination)
    {
        if (destination != currentDestination + 1) { return; }
        else
        {
            currentDestination = destination;
            Car.follow = true;
        }
    }
    public void LoadDestination()
    {
        Load.sceneToLoad = "Area" + currentDestination;
        Load.Load();
    }
}