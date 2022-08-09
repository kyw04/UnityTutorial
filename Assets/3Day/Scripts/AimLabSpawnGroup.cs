using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLabSpawnGroup : MonoBehaviour
{
    public GameObject targetOriginalModel;
    public Transform[] targetPositions;
    public float spawnTime;
    private bool isSpawning = false;
    private int maxCount = 15;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(CreateTarget());
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            isSpawning = false;
        }
    }

    private IEnumerator CreateTarget()
    {
        while (isSpawning)
        {
            int targetCount = GameObject.FindGameObjectsWithTag("Target").Length;

            if (targetCount < maxCount)
            {
                int index = UnityEngine.Random.Range(0, targetPositions.Length);
                if (targetPositions[index].childCount == 0)
                {
                    Instantiate(targetOriginalModel, targetPositions[index]);
                    yield return new WaitForSeconds(spawnTime);
                }
                else
                {
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
