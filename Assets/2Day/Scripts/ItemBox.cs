using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool check = false;
    public bool isOverLap = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOverLap = true;
            Debug.Log("충돌!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EndPoint")
        {
            isOverLap = false;
            Debug.Log("충돌 해제");
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "EndPoint")
    //    {
    //        Debug.Log("충돌 중");
    //    }
    //}
}
