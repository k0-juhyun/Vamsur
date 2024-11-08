using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f; // 이동 속도

    void Update()
    {
        // 입력을 받음
        float horizontal = Input.GetAxis("Horizontal"); // A, D 또는 화살표 좌우 입력
        float vertical = Input.GetAxis("Vertical");     // W, S 또는 화살표 상하 입력

        // 이동 방향 설정
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // 캐릭터 이동
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}

