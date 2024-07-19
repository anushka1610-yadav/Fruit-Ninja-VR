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
