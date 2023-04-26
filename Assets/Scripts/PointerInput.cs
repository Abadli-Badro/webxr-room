using UnityEngine;
using Zinnia.Pointer;

public class PointerInput : MonoBehaviour
{
    public void DoIt(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "ObjectA")
        {
            Debug.Log("can do");
        }
    }
}