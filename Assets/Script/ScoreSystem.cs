using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
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

    public float timeRemaining = 60f;
    public bool timerIsRunning = false;
    //[SerializeField]
    private int life = 03;
    private int totalScore = 0;
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

    public void timeStart()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                gameOverFunc();
            }
        }

        Debug.Log("Total Life: " + life);

        scoreUI.text = $"Score : {totalScore:D2}";
        gameOverScoreUI.text = $"Score : {totalScore:D2}";
        lifeUI.text = $"Life Left : {life.ToString("D2")}";

        if(life == 0)
        {
            Debug.Log("Game Over");
            gameOverFunc();
        }

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

    public void restartFunc(string name)
    {
        //string sceneName = SceneManager.GetActiveScene().name;
        //Debug.Log(sceneName);
        SceneManager.LoadScene(name);
    }

    public void gameOverFunc()
    {
        scorePanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        gameScript.SetActive(false);
        fruitDestroy.SetActive(false);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeUI.text = "Time Left : "+string.Format("{0:00}:{1:00}", minutes, seconds);
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
    }

    private IEnumerator DisableVignetteAfterDelay(Vignette vignette, float delay)
    {
        yield return new WaitForSeconds(delay);
        vignette.active = false;
        Debug.Log("Vignette component is now disabled.");
    }
}
