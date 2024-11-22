using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;  // 공 프리팹
    public Transform spawnPoint;   // 총구 위치

    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0))
        {
            FireBall();
        }
    }

    void FireBall()
    {
        // 총알을 스폰 포인트 위치에서 발사
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation); // 총구에서 발사

        // 총알의 방향은 spawnPoint의 forward 방향으로 설정
        Bullet bulletScript = ball.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            // 총알이 spawnPoint의 forward 방향으로 발사되도록 설정
            bulletScript.SetDirection(spawnPoint.forward); // spawnPoint의 forward 방향을 설정
        }
    }
}



