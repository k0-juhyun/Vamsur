using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float health;
    public float maxHealth;

    bool isLive;

    Rigidbody rigid;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        if (!isLive)
            return;
    }

    void OnEnable()
    {
        isLive = true;
        health = maxHealth;
    }

    



    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet"))
            return;

        health -= other.GetComponent<Bullet>().damage;

        if(health > 0)
        {
            //Alive, hit action
        }
        else
        {
            //Dead
            Dead();
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
