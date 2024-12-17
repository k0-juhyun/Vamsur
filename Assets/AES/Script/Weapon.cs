using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int count = 6; // �Ѿ� ����
    public float radius = 5.0f; // ȸ�� ������
    public float rovSpeed = 30.0f; // ȸ�� �ӵ�
    public float destructionDelay = 5.0f; // ���� ��� �ð�
    public GameObject Player; // �߽��� �Ǵ� �÷��̾� (�������� ����)
    public GameObject bulletPrefab; // �Ѿ� ������

    private List<GameObject> bullets = new List<GameObject>(); // ������ �Ѿ˵�

    void Start()
    {
        StartCoroutine(RepeatWeaponRotation());
    }

    IEnumerator RepeatWeaponRotation()
    {
        while (true) // ���� �ݺ�
        {
            Init(); // �Ѿ� ����
            yield return RotateBullets(); // ȸ�� �Ϸ���� ���
            yield return new WaitForSeconds(destructionDelay); // ��� �ð� �߰�
        }
    }

    void Init()
    {
        // �Ѿ� �ʱ� ��ġ
        for (int i = 0; i < count; i++)
        {
            float angle = 360f / count * i; // �� �Ѿ��� ���� ���
            float radian = angle * Mathf.Deg2Rad;

            // �Ѿ��� �ʱ� ��ġ ���
            float x = Player.transform.position.x + Mathf.Cos(radian) * radius;
            float z = Player.transform.position.z + Mathf.Sin(radian) * radius;
            Vector3 position = new Vector3(x, Player.transform.position.y, z);

            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            bullet.transform.LookAt(Player.transform); // �÷��̾ �ٶ󺸵��� ����
            bullets.Add(bullet);

            // ���� �ð��� ������ �Ѿ� ����
            Destroy(bullet, destructionDelay);
        }

        
    }

    IEnumerator RotateBullets()
    {
        float elapsedTime = 0f;

        while (elapsedTime < destructionDelay)
        {
            elapsedTime += Time.deltaTime;

            // �Ѿ˵��� �߽����� ȸ��
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] != null)
                {
                    float angle = 360f / count * i + rovSpeed * elapsedTime; // ������� ���� ȸ��
                    float radian = angle * Mathf.Deg2Rad;

                    float x = Player.transform.position.x + Mathf.Cos(radian) * radius;
                    float z = Player.transform.position.z + Mathf.Sin(radian) * radius;

                    bullets[i].transform.position = new Vector3(x, Player.transform.position.y, z);
                }
            }

            yield return null; // ���� �����ӱ��� ���
        }
    }
}
