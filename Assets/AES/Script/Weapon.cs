using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int count = 6; // 총알 개수
    public float radius = 5.0f; // 회전 반지름
    public float rovSpeed = 30.0f; // 회전 속도
    public float destructionDelay = 5.0f; // 삭제 대기 시간
    public GameObject Player; // 중심이 되는 플레이어 (삭제하지 않음)
    public GameObject bulletPrefab; // 총알 프리팹

    private List<GameObject> bullets = new List<GameObject>(); // 생성된 총알들

    void Start()
    {
        StartCoroutine(RepeatWeaponRotation());
    }

    IEnumerator RepeatWeaponRotation()
    {
        while (true) // 무한 반복
        {
            Init(); // 총알 생성
            yield return RotateBullets(); // 회전 완료까지 대기
            yield return new WaitForSeconds(destructionDelay); // 대기 시간 추가
        }
    }

    void Init()
    {
        // 총알 초기 배치
        for (int i = 0; i < count; i++)
        {
            float angle = 360f / count * i; // 각 총알의 각도 계산
            float radian = angle * Mathf.Deg2Rad;

            // 총알의 초기 위치 계산
            float x = Player.transform.position.x + Mathf.Cos(radian) * radius;
            float z = Player.transform.position.z + Mathf.Sin(radian) * radius;
            Vector3 position = new Vector3(x, Player.transform.position.y, z);

            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            bullet.transform.LookAt(Player.transform); // 플레이어를 바라보도록 설정
            bullets.Add(bullet);

            // 일정 시간이 지나면 총알 삭제
            Destroy(bullet, destructionDelay);
        }

        
    }

    IEnumerator RotateBullets()
    {
        float elapsedTime = 0f;

        while (elapsedTime < destructionDelay)
        {
            elapsedTime += Time.deltaTime;

            // 총알들을 중심으로 회전
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null)
                {
                    float angle = 360f / count * i + rovSpeed * elapsedTime; // 진행률에 따라 회전
                    float radian = angle * Mathf.Deg2Rad;

                    float x = Player.transform.position.x + Mathf.Cos(radian) * radius;
                    float z = Player.transform.position.z + Mathf.Sin(radian) * radius;

                    bullets[i].transform.position = new Vector3(x, Player.transform.position.y, z);
                }
            }

            yield return null; // 다음 프레임까지 대기
        }
    }
}
