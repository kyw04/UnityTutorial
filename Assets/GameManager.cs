using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ItemBox[] itemBoxs;
    public Image ENDGame;
    public bool isGameOver = false;
    private float restart = 0;
    private int count = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            restart += Time.deltaTime;
        }
        if (restart >= 1)
        {
            SceneManager.LoadScene("Socoban");
        }

        if (isGameOver == true) 
        {
            ENDGame.gameObject.SetActive(true);
            return;
        }

        for (int i = 0; i < itemBoxs.Length; i++)
        {
            if (itemBoxs[i].isOverLap && !itemBoxs[i].check)
            {
                count++;
                itemBoxs[i].check = true;
                itemBoxs[i].gameObject.SetActive(false);
            }
        }

        if (count >= itemBoxs.Length)
        {
            isGameOver = true;
            Debug.Log("∞‘¿” ≥°");
        }
    }
}
