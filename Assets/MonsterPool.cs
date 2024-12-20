using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    [Header("Pool Settings")]
    public GameObject monsterPrefab; // ���� ������
    public int poolSize = 10;        // ������Ʈ Ǯ ũ��
    public float spawnInterval = 2f; // ���� ���� ���� (��)

    private Queue<GameObject> pool = new Queue<GameObject>(); // ���� ������Ʈ Ǯ

    private void Start()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
        for (int i = 0; i < poolSize; i++)
        {
            GameObject monster = Instantiate(monsterPrefab);
            monster.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ
            pool.Enqueue(monster);
        }

        // �ֱ������� ���� ����
        InvokeRepeating(nameof(SpawnMonster), 0f, spawnInterval);
    }

    private void SpawnMonster()
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Pool is empty! Consider increasing pool size.");
            return;
        }

        // Ǯ���� ���� ��������
        GameObject monster = pool.Dequeue();
        monster.SetActive(true);

        // ���� ��ġ�� ���� ������Ʈ Ǯ ��ġ�� ����
        monster.transform.position = transform.position;
    }

    public void ReturnToPool(GameObject monster)
    {
        monster.SetActive(false); // ��Ȱ��ȭ
        pool.Enqueue(monster);   // Ǯ�� �ٽ� �߰�
    }
}
