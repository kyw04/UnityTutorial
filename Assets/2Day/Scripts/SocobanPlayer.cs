using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocobanPlayer : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public GameManager _gameManager;
    public float moveSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_gameManager.isGameOver) return;
     
        PlayerMove();
    }

    public void PlayerMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float fallSpeed = myRigidbody.velocity.y;

        //myRigidbody.AddForce(new Vector3(inputX, 0, inputZ) * moveSpeed);
        Vector3 _velocity = new Vector3(inputX, 0, inputZ) * moveSpeed;
        _velocity.y = fallSpeed;
        myRigidbody.velocity = _velocity;
    }
}
