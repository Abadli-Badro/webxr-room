using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{

    public PlayerMovement player;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnMouseDown()
    {
        Vector3 position = transform.position;
        Debug.Log("dest"+position);
        player.transform.position = transform.position + Vector3.up * gameManager.Scale;
        player.StopColors();
   }
}
