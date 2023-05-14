using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject[] boxes;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ArrivalPoint;
    [SerializeField] private GameObject ArrivalTrigger;
    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject menu;

    int boxNum = 0;
    public float Scale = 0.4f;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 1f;

    private int level = 0;

    public static GameManager Instance;

    private async void Start()
    {
        
        StartGame();
        Instance = this;
    }



    void Update()
    {
        CheckWin();
    }

    void CreateLevel(int[,] level)
    {
        float x = offsetX, y;
        for (int i = 0; i <= level.GetUpperBound(0); i++)
        {
            y = offsetY;
            for (int j = 0; j <= level.GetUpperBound(1); j++)
            {
                GetBlock(level[i, j], x, y);
                y += Scale;
            }
            x += Scale;
        }
    }
    void DestroyLevel()
    {
        player.transform.position = new Vector3(2000, 2000, 2000);
        for (int i = 0; i < 6; i++)
        {
            boxes[i].transform.position = new Vector3(2000, 2000, 2000);
        }
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < blocks.Length; i++)
        {
            Destroy(blocks[i]);
        }
        for (int i = 0; i < walls.Length; i++)
        {
            Destroy(walls[i]);
        }
        // GameObject level = GameObject.Find("Level");
        //    level.SetActive(false);

    }
    void GetBlock(int block, float x, float z)
    {

        switch (block)
        {
            case 4:
                var wallChild = Instantiate(wall, new Vector3(x, offsetZ, z), wall.transform.rotation);
                wallChild.transform.parent = gameObject.transform;
                var floorChild = Instantiate(floor, new Vector3(x, offsetZ - Scale, z), floor.transform.rotation);
                floorChild.transform.parent = gameObject.transform;
                break;
            case 2:
                boxes[boxNum].transform.position = new Vector3(x, offsetZ, z);
                floorChild = Instantiate(floor, new Vector3(x, offsetZ - Scale, z), floor.transform.rotation);
                floorChild.transform.parent = gameObject.transform;
                boxNum++;
                break;
            case 0:
                floorChild = Instantiate(floor, new Vector3(x, offsetZ - Scale, z), floor.transform.rotation);
                floorChild.transform.parent = gameObject.transform;
                break;
            case 1:
                var ArrivalTriggerChild = Instantiate(ArrivalTrigger, new Vector3(x, offsetZ, z), floor.transform.rotation);
                ArrivalTriggerChild.transform.parent = gameObject.transform;
                var ArrivalPointChild = Instantiate(ArrivalPoint, new Vector3(x, offsetZ - Scale, z), floor.transform.rotation);
                ArrivalPointChild.transform.parent = gameObject.transform;
                break;
            case 3:
                player.transform.position = new Vector3(x, offsetZ, z);
                floorChild = Instantiate(floor, new Vector3(x, offsetZ - Scale, z), floor.transform.rotation);
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
            NextLevel();
            return true;
        }
        return false;
    }
    public void RestartLevel()
    {
        boxNum = 0;
        DestroyLevel();
        //   youWin.SetActive(false);
        CreateLevel(Levels.levels[level]);
    }
    public void NextLevel()
    {
        DestroyLevel();
        boxNum = 0;
        // youWin.SetActive(false);
        level++;
        CreateLevel(Levels.levels[level]);
    }
    public void StartGame()
    {
        //  menu.gameObject.SetActive(false);
        //DestroyLevel();

        CreateLevel(Levels.levels.First());
    }



}
