using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreNum;
    public int totalScore;

    public void UpdateScore(int addScore)
    {
        totalScore += addScore;
        scoreNum.text = "score : " + totalScore.ToString();
    }
}
