using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float bulletLifeTime;

    void Update()
    {
        transform.Translate(Vector3.up * bulletVelocity * Time.deltaTime);  
    }
}
