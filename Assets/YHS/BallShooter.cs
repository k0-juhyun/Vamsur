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
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, spawnPoint.position.z));

        // 발사 방향 계산 (마우스 위치에서 발사 위치로의 방향)
        Vector3 direction = (mousePosition - spawnPoint.position).normalized;

        // 공을 생성하여 발사 위치에서 발사
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation); // 총구에서 발사

        // 발사 로직 (예: Rigidbody 사용하여 공에 힘을 주는 방식)
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * 10f, ForceMode.VelocityChange);  // 마우스 클릭 방향으로 힘을 추가
        }
    }
}

