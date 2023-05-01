using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Zinnia.Pointer;

public class PlayerMovement : MonoBehaviour
{


    public bool isColored = false;
    GameManager gameManager;
    [SerializeField] GameObject Bottom;
    
    void Start()
    {
        Debug.Log("player" + transform.position);
        gameManager = GameManager.Instance;
    }


    public void Player(ObjectPointer.EventData data)
    {
       
    }

    private void OnMouseDown()
    {
        ChangeColors();
    }


    public void ChangeColors()
    {
        isColored = !isColored;
        Bottom.SetActive(isColored);
        DetectBoxObjects();
    }
    
    public float detectDistance = 0.1f; 
    public string boxTag = "Box"; 


    public Vector3[] DetectBoxObjects()
    {
        
        Vector3[] Directions = new Vector3[4];
        int i = 0;
        // Detect box objects on the left
        RaycastHit leftHit;
        if (Physics.Raycast(transform.position, - transform.right, out leftHit, detectDistance))
        {
            GameObject obj = leftHit.collider.gameObject;
            if (obj.CompareTag(boxTag) && obj.GetComponent<BoxMovement>().CanMove(Vector3.left) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {
                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = Vector3.left;
                    i++;
                }
            }
        }

        // Detect box objects on the right
        RaycastHit rightHit;
        if (Physics.Raycast(transform.position, transform.right, out rightHit, detectDistance))
        {
            GameObject obj = rightHit.collider.gameObject;
            if (obj.CompareTag(boxTag) && obj.GetComponent<BoxMovement>().CanMove(Vector3.right) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {
                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = Vector3.right;
                    i++;
                }
            }
        }

        // Detect box objects forward
        RaycastHit forwardHit;
        if (Physics.Raycast(transform.position, transform.forward, out forwardHit, detectDistance))
        {
            GameObject obj = forwardHit.collider.gameObject;
            if (obj.CompareTag(boxTag) && obj.GetComponent<BoxMovement>().CanMove(Vector3.forward) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {
                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = Vector3.forward;
                    i++;
                }
            }
        }

        // Detect box objects backward
        RaycastHit backwardHit;
        if (Physics.Raycast(transform.position, -transform.forward, out backwardHit, detectDistance))
        {
            GameObject obj = backwardHit.collider.gameObject;
            if (obj.CompareTag(boxTag) && obj.GetComponent<BoxMovement>().CanMove(Vector3.back) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {
                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = Vector3.back;
                    i++;
                }
            }
        }
       
        return Directions;
    }
}