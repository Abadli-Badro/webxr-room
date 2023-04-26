using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{

    private PlayerMovement player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnMouseDown()
    {
        PushBox();
        player.StopColors();
    }

    private void Update()
    {
        if(!player.isColored &&
            GetComponent<MeshRenderer>().material.color == Color.blue)
            GetComponent<MeshRenderer>().material.color = new Color(0.254f, 0.169f, 0.063f, 1f);
    }


    public void PushBox()
    {
        Vector3[] directions = player.DetectBoxObjects();
        for (int i=0; i<4; i++)
        {
            if (CanMove(directions[i] * 0.2f) && transform.position*0.2f - player.transform.position*0.2f == directions[i]*0.2f)
            {
                transform.Translate(directions[i] * 0.2f);
                player.transform.Translate(directions[i] * 0.2f);
                player.isColored = false;
                if (player.isColored)
                    GetComponent<MeshRenderer>().material.color = Color.blue;
                else
                    GetComponent<MeshRenderer>().material.color = new Color(0.254f, 0.169f, 0.063f, 1f);
            }
        }
    }

    [SerializeField]
    float rayLength = 1f;
    [SerializeField]
    float rayOffsetX = 0.5f;
    [SerializeField]
    float rayOffsetY = 0.5f;
    [SerializeField]
    float rayOffsetZ = 0.5f;
    

    public bool CanMove(Vector3 direction)
    {
        RaycastHit hit;
        if ((Vector3.Equals(Vector3.forward * 0.2f , direction *0.2f) || Vector3.Equals(Vector3.back, direction* 0.2f)))
        {
            if (Physics.Raycast(transform.position + Vector3.up * 0.2f + Vector3.right * 0.2f, direction * 0.2f, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
            if (Physics.Raycast(transform.position + Vector3.up * 0.2f - Vector3.right * 0.2f, direction * 0.2f, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
        }
        else if (Vector3.Equals(Vector3.left * 0.2f, direction * 0.2f) || Vector3.Equals(Vector3.right * 0.2f, direction * 0.2f))
        {
            if (Physics.Raycast(transform.position + Vector3.up * 0.2f + Vector3.forward * 0.2f, direction * 0.2f, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
            if (Physics.Raycast(transform.position + Vector3.up * 0.2f - Vector3.forward * 0.2f, direction * 0.2f, out hit, rayLength) && (hit.transform.gameObject.CompareTag("Box") || hit.transform.gameObject.CompareTag("Wall"))) return false;
        }

        return true;
    }

}
