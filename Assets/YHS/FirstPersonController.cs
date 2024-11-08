using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 90f; // 이동 속도
    public float mouseSensitivity = 0.8f; // 마우스 민감도
    public float jumpForce = 4f; // 점프 힘
    public Transform playerBody; // 플레이어 몸체
    public Transform cameraTransform; // 카메라
    public float verticalLookLimit = 80f; // 카메라 상하 회전 제한
    public LayerMask groundLayer; // 바닥 레이어
    public float slopeLimit = 45f; // 경사면 최대 각도

    private Rigidbody rb;
    private bool isGrounded;
    private bool canDoubleJump;
    private bool isOnLadder; // 사다리 위에 있는지 여부
    private bool canClimbLadder = false; // F 키로 사다리 타기 가능 여부
    private float rotationX = 0f; // 카메라 상하 회전 값

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 회전 고정
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // F 키로 사다리 타기 가능 여부 설정
        if (Input.GetKeyDown(KeyCode.F) && isOnLadder)
        {
            canClimbLadder = true;
        }

        if (canClimbLadder)
        {
            float vertical = Input.GetAxis("Vertical"); // W/S 키
            MoveOnLadder(vertical); // 사다리 위에서 상하 이동
        }
        else
        {
            MovePlayer(); // 일반 이동
        }

        // 점프 처리
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            DoubleJump();
        }

        // 카메라 회전 처리
        RotateCamera();

        // 경사면 감지 및 이동
        CheckSlope();
    }

    void MovePlayer()
    {
        // 이동 처리 (WASD)
        float horizontal = Input.GetAxis("Horizontal"); // A/D, Left/Right
        float vertical = Input.GetAxis("Vertical"); // W/S, Up/Down

        // 이동 방향 계산
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = playerBody.right * horizontal + playerBody.forward * vertical;
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    void MoveOnLadder(float vertical)
    {
        // 사다리 위에서 상하 이동
        Vector3 ladderMove = new Vector3(0, vertical, 0).normalized;
        transform.Translate(ladderMove * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        canDoubleJump = true;
    }

    void DoubleJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Y축 속도 리셋
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        canDoubleJump = false;
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalLookLimit, verticalLookLimit);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void CheckSlope()
    {
        if (isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, groundLayer))
            {
                float angle = Vector3.Angle(hit.normal, Vector3.up);

                // 경사면 각도 체크
                if (angle > slopeLimit)
                {
                    // 경사면이 너무 기울어진 경우 수평 이동만 처리
                    Vector3 slopeDirection = Vector3.ProjectOnPlane(rb.velocity, hit.normal);
                    rb.velocity = new Vector3(slopeDirection.x, rb.velocity.y, slopeDirection.z);
                }
                else
                {
                    // 경사면에서 수직 이동 방지
                    Vector3 slopeDirection = Vector3.ProjectOnPlane(rb.velocity, hit.normal);
                    rb.velocity = new Vector3(slopeDirection.x, rb.velocity.y, slopeDirection.z);
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            canDoubleJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true; // 사다리 근처에 있을 때
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false; // 사다리에서 떨어졌을 때
            canClimbLadder = false; // 사다리 타기 종료
        }
    }
}
















