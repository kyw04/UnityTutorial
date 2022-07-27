using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    private PenguinInput _penguinInput;
    private Rigidbody _myRigidbody;
    private SpawnSystem _spawnSystem;

    [Range(0f, 10f)] public float moveSpeed;
    [Range(0f, 25f)] public float jumpPower;

    private void Start()
    {
        _penguinInput = GetComponent<PenguinInput>();
        _myRigidbody = GetComponent<Rigidbody>();
        _spawnSystem = GameObject.Find("Spawn").GetComponent<SpawnSystem>();
    }

    private void OnDisable()
    {
        _spawnSystem.isPenguinDie = true;
        StopCoroutine(_spawnSystem.CreateIceSystem());
    }

    private void Update()
    {
        Move(_penguinInput.HorizontalMoveDirection);

        if (_penguinInput.JumpInput)
        {
            Jump();
        }
    }

    private void Move(Vector3 _direction)
    {
        this.transform.Translate(_direction * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _myRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
