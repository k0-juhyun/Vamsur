using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // ����������
    public int abb; // ���� �ʱ�ȭ ������ ������ 0 (������, �Ǽ��� ����)
    public int a = 10;
    public float b = 20;
    public double c = 30;
    public bool aa = true; // ���� �ʱ�ȭ ������ ������ false
    public Transform bullet; // �Ѿ��� ��ġ

    // ���� �����Ҷ� �� �ѹ� ȣ�� (����)
    // ���� ��ŸƮ �޼��� ���� or �÷��̾� ����
    void Start()
    {
        
    }


    // ������ ������ ȣ��
    // 0.02s 
    // �ֱ������� üũ�ؾ��Ұ� / �׻� �Է� �޾ƾ��Ұ� (������ , �ѽ��)
    // ������ ���
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
        // ���콺 ��ư�� �����ѹ�
        if(Input.GetMouseButtonDown(0))
        {
            bullet.gameObject.transform.position += new Vector3 (1,0,0);
        }
    }
}
