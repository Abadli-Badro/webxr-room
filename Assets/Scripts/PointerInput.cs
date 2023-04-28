using UnityEngine;
using Zinnia.Pointer;

public class PointerInput : MonoBehaviour
{
    public void Player(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Player")
        {
            Debug.Log("Player method called");
        }
    }
}