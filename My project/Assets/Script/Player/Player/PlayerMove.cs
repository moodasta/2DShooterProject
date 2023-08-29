using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsiblr for taking care of player movement based om user's input
public class PlayerMove : MonoBehaviour
{
    private float velocity;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        velocity = PlayerInfo.instance.GetPlayerVelocity();
        spriteRenderer = PlayerInfo.instance.GetSpriteRenderer();
    }

    void Update()
    {
        MoveHandler();

    }

    private void MoveHandler()

    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float movey = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        transform.Translate(new Vector2(moveX,movey).normalized * velocity * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX !=0 || movey !=0;
        FlipSprite(moveX);
            }

    private void FlipSprite(float moveX)
    {
        if(moveX < 0)
        {
            PlayerInfo.instance.GetSpriteRenderer().flipX = true;

        }
        else if(moveX > 0) 
        {
            PlayerInfo.instance.GetSpriteRenderer().flipX = false;
        }
        
    }

}
