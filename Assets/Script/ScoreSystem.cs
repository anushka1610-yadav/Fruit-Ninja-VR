using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (totalScore > 0)
        {
            totalScore -= 1;
        }
    }

    private IEnumerator DisableVignetteAfterDelay(Vignette vignette, float delay)
    {
        yield return new WaitForSeconds(delay);
        vignette.active = false;
        Debug.Log("Vignette component is now disabled.");
    }
}
