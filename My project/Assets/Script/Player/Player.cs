using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity = 10;
    private Animator animator;
    private Transform playerTransform; 
    public static Player instance;
    [SerializeField] private int lives = 3;
    private bool isMoving;
    private bool isHurt;


    private void Awake()
    {
        #region Singleton
        if (instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion

        playerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        moveHandler();
        LifeHandler();
        AnimationHandler();
        
    }



    #region Handlers

    private void moveHandler()
        
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float movey = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        playerTransform.Translate(moveX, movey, 0);
        if (moveX !=0 || movey != 0)
        {
            isMoving = true;
        }
        else
        {
            isHurt = false;
        }

        //isMoving = moveX !=0 || movey !=0; (OUTRA ALTERNATIVA PARA POUPAR LINHAS)
     }

    private void LifeHandler()
    {
        if (lives <= 0)
        {
            Destroy(gameObject);
        }


    }

    private void AnimationHandler()
    {
        bool isMovingAnimation = animator.GetBool("isMoving");
        bool isHurtAnimation = animator.GetBool("isHurt");

        if (isMoving && isMovingAnimation == false)
        {
            animator.SetBool("isMoving", true);
        }
        else if (!isMoving && isMovingAnimation == true)
        {
            animator.SetBool("isMoving", false);
        }

        if (isHurt && isHurtAnimation == false) 
        {
            animator.SetBool("isHurt", true);
        } 
        else if (!isHurt &&isHurtAnimation ==true)
        {
            animator.SetBool("isHurt", false);
        }

        
       
    }
    #endregion
    public Vector3 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
        isHurt = true;
        print(lives);
    }

}
