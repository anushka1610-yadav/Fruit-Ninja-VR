using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private int appleCount;
    [SerializeField]    
    private int bananaCount;
    [SerializeField]
    private int coconutCount;
    [SerializeField]
    private int greenAppleCount;
    //[SerializeField]
    private static int totalScore;

    public TMP_Text scoreUI;
    public TMP_Text appleUI;
    public TMP_Text bananaUI;
    public TMP_Text coconutUI;
    public TMP_Text greenAppleUI;

 
    
    void Update()
    {
        Debug.Log("Total Score: " + totalScore);
        Debug.Log("Total Apple: " + appleCount);
        Debug.Log("Total Score: " + bananaCount);
        Debug.Log("Total Score: " + coconutCount);
        Debug.Log("Total Score: " + greenAppleCount);

        scoreUI.text = $"Score : {totalScore}";
        appleUI.text = appleCount.ToString();
        bananaUI.text = $"{bananaCount}";
        coconutUI.text = $"{coconutCount}";
        greenAppleUI.text = $"{greenAppleCount}";

    }

    public void totalApple()
    {
        appleCount += 1;
        totalScore += 1;
    }

    public void totalBanana()
    {
        bananaCount += 1;
        totalScore += 2;
    }

    public void totalCoconut()
    {
        coconutCount += 1;
        totalScore += 3;
    }

    public void totalGreenApple()
    {
        greenAppleCount += 1;
        totalScore += 4;
    }
}
