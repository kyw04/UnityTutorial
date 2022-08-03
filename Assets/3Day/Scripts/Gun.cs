using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private LineRenderer bulletLine;
    public Transform gunFirePosition;
    public float distance;
    private Vector3 hitPoint;

    private void Start()
    {
        bulletLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(gunFirePosition.position, gunFirePosition.forward * distance, out hit))
            {
                Debug.Log(hit.collider.name);
                hitPoint = hit.point;
            }
            //Debug.DrawRay(gunFirePosition.position, gunFirePosition.forward * distance, Color.red);

            StartCoroutine(ShotEffect(hitPoint));
        }
    }

    public IEnumerator ShotEffect(Vector3 hitPosition)
    {
        bulletLine.enabled = true;
        bulletLine.SetPosition(0, gunFirePosition.position);
        bulletLine.SetPosition(1, hitPosition);
        yield return new WaitForSeconds(0.03f);

        bulletLine.enabled = false;
    }
}
