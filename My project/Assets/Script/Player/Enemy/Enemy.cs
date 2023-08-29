using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocity = 5;
    private int lives;
    private Vector2 targetPosition;
    private Transform enemyTransform;

    private void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }

    void Start()
    {
    }

   
    void Update()
    {
        
        targetPosition = PlayerInfo.instance.GetPlayerPosition();
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            GameManager.Instance.SetGameScore(1);
            Destroy(this.gameObject);
        }
    }
}
