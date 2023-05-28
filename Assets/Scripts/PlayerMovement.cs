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

        Debug.Log("Bottom active" + Bottom.transform.position);
        Bottom.SetActive(false);
        Debug.Log("Bottom !active" + Bottom.transform.position);
    }

    public void Player(ObjectPointer.EventData data)                        //controls the pointer input (selecting the player) and colors the player and the available positions when activated
    {
        if (data.CollisionData.transform.tag == "Player")                   //the pointer is in collision with the player object, which triggers this function 
        {
            Debug.Log("Player method called");
            if (!isColored)
            {
                Debug.Log("!color");
                ChangeColors();
            }
            else
            {
                Debug.Log("color");
                Bottom.SetActive(false);
                isColored = !isColored;
            }
            Debug.Log("Player method finished");
        }
    }

    private void OnMouseDown()
    {
        //ChangeColors();
        if (!isColored)
        {
            Debug.Log("!color");
            ChangeColors();
            Bottom.SetActive(true);
            isColored = true;
        }
        else
        {
            Debug.Log("color");
            //gameManager.DestroyDestinations();
            Bottom.SetActive(false);
            isColored = false;
        }
        Debug.Log("Player method finished");
    }


    public void ChangeColors()                                           //colors the player and available destinations, also checks if there are any boxes nearby and colors them as well
    {
        Debug.Log("Change COlORS");
        if (!isColored)
        {
            isColored = true;
            Bottom.SetActive(true);
        }
        else
        {
            isColored = false;
            Bottom.SetActive(false);
        }

        DetectBoxObjects();
    }

    public float detectDistance = 0.1f;
    public string boxTag = "Box";


    public Vector3[] DetectBoxObjects()                                 //Detects boxes near the player and colors them, returns the directions of those boxes
    {
        Debug.Log("DETECTING OBJECTS...");

        Vector3[] Directions = new Vector3[4];
        int i = 0;
        // Detect box objects on the left

        RaycastHit leftHit;
        if (Physics.Raycast(transform.position, -transform.right, out leftHit, detectDistance))
        {
            GameObject obj = leftHit.collider.gameObject;
            if ((obj.CompareTag("Box1") || obj.CompareTag("Box2") || obj.CompareTag("Box3") || obj.CompareTag("Box4") || obj.CompareTag("Box5") || obj.CompareTag("Box6")) && obj.GetComponent<BoxMovement>().CanMove(Vector3.left) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {
                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = new Vector3(-1, 0, 0);
                    Debug.Log("Right" + Directions[i]);
                    i++;
                }
            }
        }


        // Detect box objects on the right
        RaycastHit rightHit;
        if (Physics.Raycast(transform.position, transform.right, out rightHit, detectDistance))
        {
            GameObject obj = rightHit.collider.gameObject;
            if ((obj.CompareTag("Box1") || obj.CompareTag("Box2") || obj.CompareTag("Box3") || obj.CompareTag("Box4") || obj.CompareTag("Box5") || obj.CompareTag("Box6")) && obj.GetComponent<BoxMovement>().CanMove(Vector3.right) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {
                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = new Vector3(1, 0, 0);
                    Debug.Log("Right" + Directions[i]);
                    i++;
                }
            }
        }

        // Detect box objects forward
        RaycastHit forwardHit;
        if (Physics.Raycast(transform.position, transform.forward, out forwardHit, detectDistance))
        {
            GameObject obj = forwardHit.collider.gameObject;
            if ((obj.CompareTag("Box1") || obj.CompareTag("Box2") || obj.CompareTag("Box3") || obj.CompareTag("Box4") || obj.CompareTag("Box5") || obj.CompareTag("Box6")) && obj.GetComponent<BoxMovement>().CanMove(Vector3.forward) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {

                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = new Vector3(0, 0, 1);
                    Debug.Log("FORWARD" + Directions[i]);
                    i++;
                }
            }
        }

        // Detect box objects backward
        RaycastHit backwardHit;
        if (Physics.Raycast(transform.position, -transform.forward, out backwardHit, detectDistance))
        {
            GameObject obj = backwardHit.collider.gameObject;
            if ((obj.CompareTag("Box1") || obj.CompareTag("Box2") || obj.CompareTag("Box3") || obj.CompareTag("Box4") || obj.CompareTag("Box5") || obj.CompareTag("Box6")) && obj.GetComponent<BoxMovement>().CanMove(Vector3.back) && Vector3.Distance(transform.position, obj.transform.position) <= 1f)
            {
                Renderer rend = obj.GetComponent<MeshRenderer>();
                if (rend != null)
                {
                    rend.material.color = Color.blue;
                    Directions[i] = new Vector3(0, 0, -1);
                    Debug.Log("Back" + Directions[i]);
                    i++;
                }
            }
        }
        Debug.Log("Directions : "+Directions);
        return Directions;
    }
}