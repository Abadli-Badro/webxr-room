using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Pointer;


public class Menu : MonoBehaviour
{
    [SerializeField] GameObject Reset;
    [SerializeField] GameObject About_Menu;
    [SerializeField] GameObject Start;
    [SerializeField] GameObject About;
    [SerializeField] GameObject Main_menu;
    [SerializeField] GameObject win;
    [SerializeField] GameManager gm;

    GameManager gameManager;

    public void StartGame(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Start Button")
        {
            gm.gameObject.SetActive(true);

            gameObject.SetActive(false);
            Reset.SetActive(true);
            About.SetActive(false);
            
        }
    }

    public void ResetGame(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Reset Button")
        {
            GameManager.Instance.RestartLevel();
        }
    }

    public void AboutOpen(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "About Button")
        {
            gameObject.SetActive(false);
            Start.SetActive(false);
            About_Menu.SetActive(true);

        }
    }

    public void AboutClose(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "About (close)")
        {
            About_Menu.SetActive(false);
            About.SetActive(true);
            Start.SetActive(true);
        }
    }

    public void WinClose(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Win (close)")
        {
            gm.level = 0;
            gm.DestroyLevel();
            gm.RestartLevel();
            gm.gameObject.SetActive(true);


            win.SetActive(false);
            Reset.SetActive(true);
            Main_menu.SetActive(true);
            Start.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        gm.level = 0;
        gm.DestroyLevel();
        gm.RestartLevel();
        gm.gameObject.SetActive(true);
   

        win.SetActive(false);
        Reset.SetActive(true);
        Main_menu.SetActive(true);
        Start.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
