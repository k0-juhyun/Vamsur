using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    [Header("Pool Settings")]
    public GameObject monsterPrefab; // 몬스터 프리팹
    public int poolSize = 10;        // 오브젝트 풀 크기
    public float spawnInterval = 2f; // 몬스터 생성 간격 (초)

    private Queue<GameObject> pool = new Queue<GameObject>(); // 몬스터 오브젝트 풀

    private void Start()
    {
        // 오브젝트 풀 초기화
        for (int i = 0; i < poolSize; i++)
        {
            GameObject monster = Instantiate(monsterPrefab);
            monster.SetActive(false); // 초기에는 비활성화
            pool.Enqueue(monster);
        }

        // 주기적으로 몬스터 생성
        InvokeRepeating(nameof(SpawnMonster), 0f, spawnInterval);
    }

    private void SpawnMonster()
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Pool is empty! Consider increasing pool size.");
            return;
        }

        // 풀에서 몬스터 가져오기
        GameObject monster = pool.Dequeue();
        monster.SetActive(true);

        // 생성 위치를 현재 오브젝트 풀 위치로 설정
        monster.transform.position = transform.position;
    }

    public void ReturnToPool(GameObject monster)
    {
        monster.SetActive(false); // 비활성화
        pool.Enqueue(monster);   // 풀에 다시 추가
    }
}
