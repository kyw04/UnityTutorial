using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLabPlayer : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Camera playerCamera;
    private Vector3 moveInput;
    [Range(1, 10)] public float moveSpeed;
    public float sensitivity;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        PlayerMove();
        PlayerRotate();
        PlayerCameraRotate();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void PlayerMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 _moveHorizontal = transform.right * inputX;
        Vector3 _moveVertical = transform.forward * inputY;

        moveInput = _moveHorizontal + _moveVertical;

        myRigidbody.MovePosition(myRigidbody.position + moveInput * moveSpeed * Time.deltaTime);
    }

    private void PlayerRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Quaternion rot = Quaternion.Euler(0, mouseX * sensitivity, 0);

        myRigidbody.MoveRotation(myRigidbody.rotation * rot);
    }

    private void PlayerCameraRotate()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rot = new Vector3(-mouseY * sensitivity, 0, 0);

        playerCamera.transform.localEulerAngles += rot;
    }
}
