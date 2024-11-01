using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // 게임 시작할 때 단 한번만 호출(실행)
    //게임 스타트 메세지 띄우기 or 플레이어 생성
    //접근제어자 public , private
    //변수 선언할때 public 으로 선언하면, 컴포넌트에서 수정 가능
    /* 전역변수 
     * int a = 10; (+ 값 초기화 안하면 0으로 초기화
     * float b = 20;
     * double c = 30;
     * bool aa = true; (+ 초기화 안하면 기본 false
     * Transform bullet; (트랜스폼 컴포넌트 값 가져오기 => 위치 가져와짐)
     */
    void Start()
    {
        
    }

    // 프레임 단위로 호출
    // 0.02초에 한번씩 호출
    // 주기적으로 체크해야할것 / 항상 입력받아야 할것 ( 움직임, 총쏘기 )
    // 개발할 기능 메모하기
    
    void Update()
    {
        //MoveSphere()
        //firebullet()
    }
    

    /* private void moveSphere()
     {
    Getkye (누르는 동안)
    GetkyeDown  (눌렀을 때)
    GetkyeUp (땟을때
    if (Input.GetKeyDown(KeyCode.W)
    {
    this.gameObject.transform.position += new Vector3 (1,0,0);*/

    /*private void fireBullet()
     * {
     *  if(Input.GetMouseButtonDown(0)) 0좌클릭 1 우클릭
     *  {
     *      bullet.gameObject.transform.position +=new Vector (1,0,0);
     *      }}
     */
}
