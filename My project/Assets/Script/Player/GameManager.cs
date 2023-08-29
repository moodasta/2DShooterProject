using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int gameScore = 0;
    private int playerLifes;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
  
    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    public int GetGameScore()
    {
        return gameScore;
    }

    public void SetGameScore(int score)
    {
        gameScore += score;
        UIManager.Instance.SetScoreText(gameScore);
    }

    public void SetPlayerLife(int Life)
    {
        playerLifes = Life;
        UIManager.Instance.SetLifesText(playerLifes);
    }
}
