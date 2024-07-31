using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private ScoreSystem score;
    [SerializeField]
    private GameObject ScoreUI;
    [SerializeField]
    private GameObject GameOverUI;

    public TMP_Text scoreUI;
    public TMP_Text lifeUI;
    public TMP_Text timeUI;

    private int totalscore;

}
