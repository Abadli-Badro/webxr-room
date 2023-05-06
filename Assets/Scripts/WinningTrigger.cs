using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTrigger : MonoBehaviour
{
    public bool triggerChecked= false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box1") || other.gameObject.CompareTag("Box2") || other.gameObject.CompareTag("Box3") || other.gameObject.CompareTag("Box4"))
        {
            triggerChecked = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            triggerChecked = false;
        }
    }
    
}
