using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBehavior : MonoBehaviour
{
    public void OnPointerTrigger()
    {
        // Perform the desired behavior of the interactable object here
        Debug.Log("TRIGGER");
    }
}
