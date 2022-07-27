using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject IceObj;
    public float popTime;
    public Penguin _penguin;

    public bool isPenguinDie { get; set; }


    private void Start()
    {
        isPenguinDie = false;
        _penguin = GameObject.Find("Penguin").GetComponent<Penguin>();
        StartCoroutine(CreateIceSystem());
    }

    public void Spawn()
    {
        Instantiate(IceObj, this.transform.position, Quaternion.Euler(0f, 180f, 0));
    }

    IEnumerator CreateIceSystem()
    {
        do
        {
            Spawn();
            yield return new WaitForSeconds(popTime);
        } while (!isPenguinDie);
    }
}
