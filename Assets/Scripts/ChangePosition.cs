using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Pointer;

public class ChangePosition : MonoBehaviour
{

    [SerializeField] PlayerMovement player;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void OnMouseDown()
    {
        Debug.Log(player.transform.position);
        
        //player.transform.position = transform.position + new Vector3(0, 0.2f, 0);
        player.transform.Translate(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);
        //player.transform.Translate(transform.position + new Vector3(0, 0, 0.2f));
        player.ChangeColors();
   }

    public void ChangeDirection(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Destination")
        {
            Debug.Log(transform.position);
            player.transform.Translate(transform.position.x - player.transform.position.x , 0f , transform.position.z - player.transform.position.z);
            Debug.Log(player.transform.position);
            player.ChangeColors();
        }  
    }
    public void ChangeDirectionLeft(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Left")
        {
            Debug.Log(transform.position);
            player.transform.Translate(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);
            Debug.Log(player.transform.position);
            player.ChangeColors();
        }
    }

    public void ChangeDirectionRight(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Right")
        {
            Debug.Log(transform.position);
            player.transform.Translate(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);
            Debug.Log(player.transform.position);
            player.ChangeColors();
        }
    }

    public void ChangeDirectionForward(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Forward")
        {
            Debug.Log(transform.position);
            player.transform.Translate(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);
            Debug.Log(player.transform.position);
            player.ChangeColors();
        }
    }

    public void ChangeDirectionBackward(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Back")
        {
            Debug.Log(transform.position);
            player.transform.Translate(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);
            Debug.Log(player.transform.position);
            player.ChangeColors();
        }

    }

}
