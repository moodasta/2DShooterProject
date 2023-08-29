using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for taking care of general information that the player has
//(Life, Position in the map, if is getting hurt, etc.)
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    private Transform playerTransform;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private int lifes = 3;
    [SerializeField] private float playerVelocity = 10;
    
    private bool isHurt;
    public bool isMoving;


    // Start is called before the first frame update
    private void Awake()
    {
        #region
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion


        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.Instance.SetPlayerLife(lifes);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
        LifeHandler();
                    }
    }

    private void LifeHandler()
    {
        isHurt = true;
        lifes--;
        print(lifes);
        if (lifes <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public Vector2 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    public float GetPlayerVelocity()
    {
        return playerVelocity;
    }

    public bool CheckPlayerVelocity()
    {
        return isMoving;
    }

    public bool CheckPlayerHurt()
    {
        return isHurt;
    }

    public void SetPlayerHurt(bool hurt)
    {
        isHurt= hurt;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

}


