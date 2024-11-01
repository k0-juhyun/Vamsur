using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 접근제어자
    public int abb; // 값을 초기화 해주지 않으면 0 (정수형, 실수형 같음)
    public int a = 10;
    public float b = 20;
    public double c = 30;
    public bool aa = true; // 값을 초기화 해주지 않으면 false
    public Transform bullet; // 총알의 위치

    // 게임 시작할때 단 한번 호출 (실행)
    // 게임 스타트 메세지 띄우기 or 플레이어 생성
    void Start()
    {
        
    }


    // 프레임 단위로 호출
    // 0.02s 
    // 주기적으로 체크해야할것 / 항상 입력 받아야할것 (움직임 , 총쏘기)
    // 개발할 기능
    void Update()
    {
        moveSphere();
        fireBullet();
    }

    

    private void moveSphere()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position += new Vector3 (1,0,0);
        }
    }

    private void fireBullet()
    {
        // 마우스 버튼을 딸깍한번
        if(Input.GetMouseButtonDown(0))
        {
            bullet.gameObject.transform.position += new Vector3 (1,0,0);
        }
    }
}
