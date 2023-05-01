using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zinnia.Pointer;

public class BoxMovement : MonoBehaviour
{

    private PlayerMovement player;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void BoxClick()
    {
        Debug.Log("Box method called");
        PushBox();
        //player.StopColors();
        Debug.Log("Box method done");
    }

    private void Update()
    {
        if (!player.isColored && GetComponent<MeshRenderer>().material.color == Color.blue)
            GetComponent<MeshRenderer>().material.color = new Color(0.254f, 0.169f, 0.063f, 1f);
    }


    public void PushBox()
    {
        Vector3[] directions = player.DetectBoxObjects();
        for (int i = 0; i < 4; i++)
        {
            if (CanMove(directions[i] * gameManager.Scale) && transform.position - player.transform.position == directions[i] * gameManager.Scale && player.isColored)
            {
                transform.Translate(directions[i] * gameManager.Scale);
                player.transform.Translate(directions[i] * gameManager.Scale);
                player.isColored = false;
                if (player.isColored)
                    GetComponent<MeshRenderer>().material.color = Color.blue;
                else
                    GetComponent<MeshRenderer>().material.color = new Color(0.254f, 0.169f, 0.063f, 1f);
            }
        }
    }

   


    public bool CanMove(Vector3 direction)
    {
        // Define the length of the raycast
        float raycastDistance = gameManager.Scale;

        // Cast a ray in the given direction to detect obstacles
        RaycastHit hit;
        bool hasObstacle = Physics.Raycast(transform.position, direction, out hit, raycastDistance);

        // If the raycast hits something, check its tag
        if (hasObstacle)
        {
            // If the obstacle is a wall, the box cannot move
            if (hit.collider.CompareTag("Wall"))
            {
                return false;
            }
            // If the obstacle is another box, check if it can move in the same direction
            else if (hit.collider.CompareTag("Box"))
            {
                Box box = hit.collider.GetComponent<Box>();
                return false;
            }
        }

        // If there is no obstacle, the box can move
        return true;
    }


}
