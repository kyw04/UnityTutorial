using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public UIController uiController;
    public int CurrentHealth = 20;

    private void Start()
    {
        uiController = GameObject.Find("ScoreNum").GetComponent<UIController>(); 
    }
    public void Damage(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            uiController.UpdateScore(10);
            Destroy(this.gameObject);
        }
    }
}
