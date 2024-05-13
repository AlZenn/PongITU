using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public BallMovement ballmovement;
    public GameObject gameoverPanelP1;
    public GameObject gameoverPanelP2;
    public void Start()
    {
        Time.timeScale = 0f;
        ballmovement = GameObject.Find("Top").GetComponent<BallMovement>();
    }

    public void gameStart()
    {
        Time.timeScale = 1f;
    }

    public void gamePause()
    {
        Time.timeScale = 0f;
    }

    public void gameResume()
    {
        Time.timeScale = 1f;
    }

    public void gameRestart()
    {
        ballmovement.P1Health = 2;
        ballmovement.P2Health = 2;

        ballmovement.P1Can.SetActive(true);
        ballmovement.P1Kalkan.SetActive(true);
        ballmovement.P2Can.SetActive(true);
        ballmovement.P2Kalkan.SetActive(true);

        gameoverPanelP1.SetActive(false);
        gameoverPanelP2.SetActive(false);
        Time.timeScale = 1f;
    }

    public void gameQuit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (ballmovement.P1Health == 0)
        {
            Time.timeScale = 0f;
            gameoverPanelP2.SetActive(true);
        }
        if (ballmovement.P2Health == 0)
        {
            Time.timeScale = 0f;
            gameoverPanelP1.SetActive(true);
        }
    }


}
