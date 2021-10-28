using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public enum GameStates
    {
        Playing, GameOver, Won
    }

    public GameObject player;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject wonCanvas;
    public GameStates gameState = GameStates.Playing;
    private Health healthPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");

        healthPlayer = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("FinishCoin"))
        {
            gameState = GameStates.Won;
            player.GetComponent<Health>().healthPoints = 99999;
        }

        switch (gameState)
        {
            case GameStates.Playing:
                if (!healthPlayer.isAlive)
                {
                    gameState = GameStates.GameOver;
                    mainCanvas.SetActive(false);
                    wonCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                break;
            case GameStates.GameOver:
                break;
            case GameStates.Won:
                mainCanvas.SetActive(false);
                wonCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                break;
            default:
                break;
        }
    }
}
