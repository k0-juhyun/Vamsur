using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // ���� ������ �� �� �ѹ��� ȣ��(����)
    //���� ��ŸƮ �޼��� ���� or �÷��̾� ����
    //���������� public , private
    //���� �����Ҷ� public ���� �����ϸ�, ������Ʈ���� ���� ����
    /* �������� 
     * int a = 10; (+ �� �ʱ�ȭ ���ϸ� 0���� �ʱ�ȭ
     * float b = 20;
     * double c = 30;
     * bool aa = true; (+ �ʱ�ȭ ���ϸ� �⺻ false
     * Transform bullet; (Ʈ������ ������Ʈ �� �������� => ��ġ ��������)
     */
    void Start()
    {
        
    }

    // ������ ������ ȣ��
    // 0.02�ʿ� �ѹ��� ȣ��
    // �ֱ������� üũ�ؾ��Ұ� / �׻� �Է¹޾ƾ� �Ұ� ( ������, �ѽ�� )
    // ������ ��� �޸��ϱ�
    
    void Update()
    {
        //MoveSphere()
        //firebullet()
    }
    

    /* private void moveSphere()
     {
    Getkye (������ ����)
    GetkyeDown  (������ ��)
    GetkyeUp (������
    if (Input.GetKeyDown(KeyCode.W)
    {
    this.gameObject.transform.position += new Vector3 (1,0,0);*/

    /*private void fireBullet()
     * {
     *  if(Input.GetMouseButtonDown(0)) 0��Ŭ�� 1 ��Ŭ��
     *  {
     *      bullet.gameObject.transform.position +=new Vector (1,0,0);
     *      }}
     */
}
