using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int gameScore = 0;
    private int playerLifes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

    public int SetGameScore(int score)
    {
        return gameScore;
    }

    public void SetPlayerLifes(int life)
    {
        playerLifes = life;
        UIManager.instance.SetLifesText (playerLifes);
    }

    public void SetNewXPInfo (int currentLevel, int currentXP, int toLevelUpXP)
    {
        UIManager.instance.SetXPInfoText(currentXP, toLevelUpXP);
        UIManager.instance.SetPlayerLevelText(currentLevel);
    }
}
