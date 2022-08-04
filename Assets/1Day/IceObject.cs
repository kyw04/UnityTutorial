using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceObject : MonoBehaviour
{
    [Range(1f, 10f)] public float moveSpeed;

    void Start()
    {

    }

    void Update()
    {
        IceMove();
    }

    private void IceMove()
    {
        this.transform.Translate(new Vector3(0f, 0f, moveSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Penguin")
        {
            Destroy(other.gameObject);
        }
    }
}
