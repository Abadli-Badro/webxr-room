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

    public void StartGame(ObjectPointer.EventData data)
    {
        if (data.CollisionData.transform.tag == "Start Button")
        {
            GameManager.Instance.gameObject.SetActive(true);
            Reset.SetActive(true);
            gameObject.SetActive(false);
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

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
