using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Animator animator;
    private Transform playerTransform;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }


    void Update()
    {
        Move();
    }



    
    private void Move()
        
    {
        float moveX = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        float movey = Input.GetAxis("Vertical") * velocity * Time.deltaTime;
        playerTransform.Translate(moveX, movey, 0);
    }
}
