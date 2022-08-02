using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Debug.Log("UpArrow");

        if (Input.GetKey(KeyCode.DownArrow))
            Debug.Log("DownArrow");

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            Debug.Log("LeftArrow");

        if (Input.GetMouseButtonDown(0))
            Debug.Log("LeftButton Click");

        if (Input.GetMouseButtonUp(1))
            Debug.Log("RightButton Click");

        if (Input.GetMouseButton(2))
            Debug.Log("Mouse Wheel Click");

        if (Input.GetButtonDown("Horizontal"))
            Debug.Log("수평");

        if (Input.GetButton("Fire1"))
            Debug.Log("발사");

        if (Input.GetButtonUp("Jump"))
            Debug.Log("점프");
    }
}
