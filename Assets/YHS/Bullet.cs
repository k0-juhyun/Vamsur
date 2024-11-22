using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f; // 총알의 이동 속도
    public float lifetime = 5f; // 총알이 사라질 시간 (초)
    public float damage = 10f; // 총알의 데미지
    private Vector3 direction; // 총알의 이동 방향

    void Start()
    {
        // 일정 시간이 지나면 총알 오브젝트 삭제
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // 총알이 설정된 방향으로 직선 이동
        transform.Translate(direction * speed * Time.deltaTime, Space.World); // 월드 좌표계 기준으로 이동
    }

    // 총알의 이동 방향을 설정하는 메서드
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; // 방향을 정규화하여 설정
    }

    // 총알이 다른 오브젝트와 충돌했을 때
     private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체에서 HealthBarController를 찾음
        HealthBarController healthBarController = collision.gameObject.GetComponent<HealthBarController>();
        if (healthBarController != null)
        {
            healthBarController.TakeDamage(damage); // 데미지 적용
        }

        // 총알을 삭제
        Destroy(gameObject);
    }
}













