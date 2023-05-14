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
    public void BoxClick(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Player")
        {
            Debug.Log("Box method called");
            PushBox();
            //player.StopColors();
            Debug.Log("Box method done");
        }
    }

    private void Update()
    {
        if (!player.isColored && GetComponent<MeshRenderer>().material.color == Color.blue)
            GetComponent<MeshRenderer>().material.color = new Color(0.254f, 0.169f, 0.063f, 1f);
    }
    private void OnMouseDown()
    {
        PushBox();
    }

    public void ClickBox1(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Box1")
            PushBox();
    }
    public void ClickBox2(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Box2")
            PushBox();
    }
    public void ClickBox3(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Box3")
            PushBox();
    }
    public void ClickBox4(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Box4")
            PushBox();
    }
    public void ClickBox5(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Box5")
            PushBox();
    }
    public void ClickBox6(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Box6")
            PushBox();
    }
    public void PushBox()
    {
        GameObject Box = GameObject.FindGameObjectWithTag("Box1");
        if (transform.tag.Equals("Box2")) { Box = GameObject.FindGameObjectWithTag("Box2"); }
        else if (transform.tag.Equals("Box3")) { Box = GameObject.FindGameObjectWithTag("Box3"); }
        else if (transform.tag.Equals("Box4")) { Box = GameObject.FindGameObjectWithTag("Box4"); }
        else if (transform.tag.Equals("Box5")) { Box = GameObject.FindGameObjectWithTag("Box5"); }
        else if (transform.tag.Equals("Box6")) { Box = GameObject.FindGameObjectWithTag("Box6"); }
        Vector3[] directions = player.DetectBoxObjects();
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("direction is :" + (Box.transform.position - player.transform.position));
            if (CanMove(directions[i] * 0.2f) && Box.transform.position - player.transform.position == directions[i] * 0.2f && player.isColored)
            {
                if (!directions[i].Equals(Vector3.zero))
                {
                    Debug.Log("YES" + directions[i]);
                    Box.transform.Translate(directions[i] * 0.2f);
                    player.transform.Translate(directions[i] * 0.2f);
                    player.ChangeColors();
                    if (player.isColored)
                        GetComponent<MeshRenderer>().material.color = Color.blue;
                    else
                        GetComponent<MeshRenderer>().material.color = new Color(0.254f, 0.169f, 0.063f, 1f);
                }
                break;
            }
        }
    }
    public bool CanMove(Vector3 direction)
    {
        // Define the length of the raycast
        float raycastDistance = 0.2f;       //scale

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
            else if (hit.collider.CompareTag("Box1") || hit.collider.CompareTag("Box2") || hit.collider.CompareTag("Box3") || hit.collider.CompareTag("Box4") || hit.collider.CompareTag("Box5") || hit.collider.CompareTag("Box6"))
            {

                return false;
            }
        }
        // If there is no obstacle, the box can move
        return true;
    }


}
