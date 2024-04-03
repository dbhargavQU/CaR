using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Destination : MonoBehaviour, IPointerClickHandler
{
    public int destinationIndex;
    private DestinationChecker checker;

    private void Start()
    {
        checker = FindFirstObjectByType<DestinationChecker>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (checker != null)
        {
            checker.UpdateDestination(destinationIndex);
        }

        Debug.Log("Clicked Area " + destinationIndex);
    }
}