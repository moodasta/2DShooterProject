using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity = 10;
    private Animator animator;
    private Transform playerTransform; 
    public static Player instance;
    [SerializeField] private int lives = 3;

    private void Awake()
    {

        if (instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
    }



    
    private void Move()
        
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float movey = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        playerTransform.Translate(moveX, movey, 0);
        print(lives);
        if (lives <=0)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
    }
}
