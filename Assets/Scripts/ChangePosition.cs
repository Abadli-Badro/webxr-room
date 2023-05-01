using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Pointer;

public class ChangePosition : MonoBehaviour
{

    public PlayerMovement player;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void OnMouseDown()
    {
        Debug.Log("Changing Position");
        
        player.transform.position = transform.position + Vector3.up * gameManager.Scale;
        player.ChangeColors();
   }
}
