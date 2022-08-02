using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinInput : MonoBehaviour
{
    public string HorizontalName = "Horizontal";
    public string JumpInputName = "Jump";

    public Vector3 HorizontalMoveDirection { get; private set; }
    public bool JumpInput;

    private void Update()
    {
        MoveSystem();
    }

    private void MoveSystem()
    {
        // 좌우 움직임
        HorizontalMoveDirection = new Vector3(Input.GetAxis(HorizontalName), 0f, 0f);
        //Debug.Log(HorizontalMoveDirection);

        JumpInput = Input.GetButtonDown(JumpInputName);
    }
}
