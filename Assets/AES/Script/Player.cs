using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public float count;

    [SerializeField] //데이터 직렬화
    private float Speed; // 플레이어 스피드

    [SerializeField]
    private float lookSensitivity; // 카메라 민감도

    [SerializeField]
    private float cameraRotationLimit; // 카메라 각도 제한
    private float currentCameraRotationX = 0;


    [SerializeField]
    private Camera theCamera;
    //카메라를 컴포넌트에 상속

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
        //(1,0,0) * 방향키 (-1, 0, 1)
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHrizontal + _moveVertical).normalized * Speed;
        //(1,0,0) + (0,0,1) = (1,0,1) 행렬과 비슷
        //=> 2 -> normalized => (0.5, 0, 0.5) = 1 계산하기 편하게
        //즉 방향 * Speed가 됨.

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        // Time.deltaTime 60fps면 1초동안 60번 (순간이동이 아닌 움직임이 됨)


    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y"); //위아래 1 , -1
        float _cameraRotationX = _xRotation * lookSensitivity;//deltatime 과 같은 느낌
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        //currentCameraRotationX 값을 -Limit 값과 Limit 값 안에 가두기
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

