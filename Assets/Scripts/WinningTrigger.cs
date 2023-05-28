using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningTrigger : MonoBehaviour
{
    public bool triggerChecked = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box1") || other.gameObject.CompareTag("Box2") || other.gameObject.CompareTag("Box3") || other.gameObject.CompareTag("Box4") || other.gameObject.CompareTag("Box5") || other.gameObject.CompareTag("Box6"))
        {
            triggerChecked = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box1") || other.gameObject.CompareTag("Box2") || other.gameObject.CompareTag("Box3") || other.gameObject.CompareTag("Box4") || other.gameObject.CompareTag("Box5") || other.gameObject.CompareTag("Box6"))
        {
            triggerChecked = false;
        }
    }

}
