using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int count;
    public float rovSpeed;
    
    public float destructionDelay = 5.0f;
    public GameObject Player;
 
   

    void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        //RotateAround(기준으로 삼을 대상, 회전축, 속도)
        transform.RotateAround(Player.transform.position,Vector3.up,Time.deltaTime*rovSpeed*5.0f);
        
    }
    public void Init()
    {
        Destroy(gameObject, destructionDelay);
    }
    
}