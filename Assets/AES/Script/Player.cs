using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public float count;

    [SerializeField] //������ ����ȭ
    private float Speed; // �÷��̾� ���ǵ�

    [SerializeField]
    private float lookSensitivity; // ī�޶� �ΰ���

    [SerializeField]
    private float cameraRotationLimit; // ī�޶� ���� ����
    private float currentCameraRotationX = 0;


    [SerializeField]
    private Camera theCamera;
    //ī�޶� ������Ʈ�� ���

    private Rigidbody myRigid;
    void Start()
    {
        
        myRigid = GetComponent<Rigidbody>();
        Batch();
    }
    
    void Update()
    {
        Move();
        CameraRotation();
        CharacterRotation();
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHrizontal = transform.right * _moveDirX;
        //(1,0,0) * ����Ű (-1, 0, 1)
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHrizontal + _moveVertical).normalized * Speed;
        //(1,0,0) + (0,0,1) = (1,0,1) ��İ� ���
        //=> 2 -> normalized => (0.5, 0, 0.5) = 1 ����ϱ� ���ϰ�
        //�� ���� * Speed�� ��.

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        // Time.deltaTime 60fps�� 1�ʵ��� 60�� (�����̵��� �ƴ� �������� ��)


    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y"); //���Ʒ� 1 , -1
        float _cameraRotationX = _xRotation * lookSensitivity;//deltatime �� ���� ����
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        //currentCameraRotationX ���� -Limit ���� Limit �� �ȿ� ���α�
        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));

    }
    void Batch()
    {
        for (int i = 0; i < count; i++)
        {
            //Instantiate(bullet);
            //bullet.transform.position
        }
    }


}

