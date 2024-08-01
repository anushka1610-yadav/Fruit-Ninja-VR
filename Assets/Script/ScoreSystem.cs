using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
    [SerializeField]
    private GameObject danger;
    //[SerializeField]
    private static int life = 03;
    private static int totalScore = 0;
    //UI Elements Input
    public RawImage scorePanel;
    public RawImage gameOverPanel;
    public TMP_Text gameOverScoreUI;
    public TMP_Text scoreUI;
    public TMP_Text lifeUI;
    public TMP_Text timeUI;
    //Scripts Input
    public GameObject gameScript;
    public GameObject fruitDestroy;

 
    
    void Update()
    {
        Debug.Log("Total Life: " + life);

        scoreUI.text = $"Score : {totalScore:D2}";
        gameOverScoreUI.text = $"Score : {totalScore:D2}";
        lifeUI.text = $"Life Left : {life.ToString("D2")}";

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

    public void totalBomb()
    {
        Volume volume = danger.GetComponent<Volume>();
        Debug.Log(volume);
        if (volume != null && volume.profile != null)
        {
            if (volume.profile.TryGet<Vignette>(out Vignette vignette))
            {
                Debug.Log("Vignette component is present in the VolumeProfile.");
                vignette.active = true;
                Debug.Log("Vignette component is now enabled.");
                StartCoroutine(DisableVignetteAfterDelay(vignette, 1.0f));
            }
            else
            {
                Debug.LogWarning("Vignette component is not present in the VolumeProfile.");
            }
        }
        else
        {
            Debug.LogError("Volume or VolumeProfile is missing.");
        }

        //checked for score deduction
        if (totalScore > 0)
        {
            totalScore -= 1;
        }

        //checked for life left
        if (life > 0)
        {
            life -= 1;
        }
        else
        {
            Debug.Log("Game Over");
            scorePanel.gameObject.SetActive(false);
            gameOverPanel.gameObject.SetActive(true);
            gameScript.SetActive(false);
            fruitDestroy.SetActive(false);

        }
    }

    private IEnumerator DisableVignetteAfterDelay(Vignette vignette, float delay)
    {
        yield return new WaitForSeconds(delay);
        vignette.active = false;
        Debug.Log("Vignette component is now disabled.");
    }
}
