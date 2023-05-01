using UnityEngine;
using Zinnia.Pointer;

public class PointerInput : MonoBehaviour
{
    [SerializeField] GameObject destination;
    PlayerMovement player;
    GameManager gameManager;
    public float detectDistance = 0.1f;
    public string boxTag = "Box";
    private void Start()
    {
        gameManager = GameManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void Player(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Player")
        {
            Debug.Log("Player method called");
            player.isColored = !player.isColored;
            Debug.Log("Color:" + player.isColored);
            if (player.isColored)
            {
                var d1 = Instantiate(destination, transform.position + new Vector3(-1,-1,0) * 0.2f, transform.rotation);
                d1.transform.parent = transform;
                Debug.Log(d1.transform.position);
                var d2 = Instantiate(destination, transform.position + new Vector3(1,-1,0) * 0.2f, transform.rotation);
                d2.transform.parent = transform;
                Debug.Log(d2.transform.position);
                var d3 = Instantiate(destination, transform.position + new Vector3(0,-1,1) * 0.2f, transform.rotation);
                d3.transform.parent = transform;
                Debug.Log(d3.transform.position);
                var d4 = Instantiate(destination, transform.position + new Vector3(0,-1,-1) * 0.2f, transform.rotation);
                d4.transform.parent = transform;
                Debug.Log(d4.transform.position);
            }
            else
            {
                gameManager.DestroyDestinations();
            }
            DetectBoxObjects();
            Debug.Log("Player method finished");
        }
    }

    public Vector3[] DetectBoxObjects()
    {

        Vector3[] Directions = new Vector3[4];
        int i = 0;
        // Detect box objects on the left
        RaycastHit leftHit;
        if (Physics.Raycast(transform.position, -transform.right, out leftHit, detectDistance))
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