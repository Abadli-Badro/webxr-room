using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ArrivalPoint;
    [SerializeField] private GameObject ArrivalTrigger;
    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject menu;

    public float Scale = 0.4f;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 1f;

    private int level = 0;

    public static GameManager Instance;

    private void Start()
    {
        StartGame();
        Instance = this;
    }

    public void DestroyDestinations()
    {
        GameObject[] destinations = GameObject.FindGameObjectsWithTag("Destination");
        for (int i = 0; i < destinations.Length; i++)
        {
            Destroy(destinations[i]);
        }
    }

    void Update()
    {
        CheckWin();
    }

    void CreateLevel(int[,] level)
    {
        float x=offsetX , y;
        for (int i = 0; i <= level.GetUpperBound(0); i++)
        {
            y = offsetY;
            for (int j = 0; j <= level.GetUpperBound(1); j++)
            {
                GetBlock(level[i, j], x ,y);
                y += Scale;
            }
            x += Scale;
        }
    }
    void DestroyLevel()
    {
        GameObject level = GameObject.Find("Level");
        level.SetActive(false);

    }
    void GetBlock(int block, float x, float z)
    {
        
        switch (block)
        {
            case 4:
                var wallChild = Instantiate(wall, new Vector3(x, offsetZ, z), wall.transform.rotation);
                wallChild.transform.parent = gameObject.transform;
                var floorChild = Instantiate(floor, new Vector3(x, offsetZ-Scale, z), floor.transform.rotation);
                floorChild.transform.parent = gameObject.transform;
                break;
            case 2:
                var boxChild = Instantiate(box, new Vector3(x, offsetZ, z), box.transform.rotation);
                boxChild.transform.parent = gameObject.transform;
                floorChild = Instantiate(floor, new Vector3(x, offsetZ-Scale, z), floor.transform.rotation);
                floorChild.transform.parent = gameObject.transform;
                break;
            case 0:
                  floorChild = Instantiate(floor, new Vector3(x, offsetZ-Scale, z), floor.transform.rotation);
                  floorChild.transform.parent = gameObject.transform;
                break;
            case 1:
                var ArrivalTriggerChild =  Instantiate(ArrivalTrigger, new Vector3(x, offsetZ, z), floor.transform.rotation);
                ArrivalTriggerChild.transform.parent = gameObject.transform;
                var ArrivalPointChild = Instantiate(ArrivalPoint, new Vector3(x, offsetZ-Scale, z), floor.transform.rotation);
                ArrivalPointChild.transform.parent = gameObject.transform;
                break;
            case 3:
                var playerChild = Instantiate(player, new Vector3(x, offsetZ, z), wall.transform.rotation);
                playerChild.transform.parent = gameObject.transform;
                floorChild = Instantiate(floor, new Vector3(x, offsetZ-Scale, z), floor.transform.rotation);
                floorChild.transform.parent = gameObject.transform;
                break;
        }
    }
    bool CheckWin()                                                             //compare the number of boxes that are on the winning positions with the number of the positions, if it is equal then the level has ended
    {
        WinningTrigger[] WinningScript = FindObjectsOfType<WinningTrigger>();

        int len = WinningScript.Length, i = 0, checkedTrigger = 0;
        if (len == 0) return false;
        for (i = 0; i < len; i++)
        {
            if (WinningScript[i].triggerChecked == true) checkedTrigger++;
        }
        if (checkedTrigger == len)
        {
            DestroyLevel();
            return true;
        }
        return false;
    }
    public void RestartLevel()
    {
        DestroyLevel();
     //   youWin.SetActive(false);
        CreateLevel(Levels.levels[level]);
    }
    public void NextLevel()
    {
        DestroyLevel();
        youWin.SetActive(false);
        level++;
        CreateLevel(Levels.levels[level]);
    }
    public void StartGame()
    {
      //  menu.gameObject.SetActive(false);
        //DestroyLevel();
        level = 1;
        CreateLevel(Levels.levels[level]);
    }

    

}
