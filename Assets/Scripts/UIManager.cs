using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text bestScoreText;
    public TMP_Text currentScoreText;

    public GameObject scorePanle;
    public GameObject readyPanel;

    public float currentScore;
    public float bestScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentScore = 0;
        currentScoreText.text = "Score: " + (int)currentScore;
    }

    private void Update()
    {
        if(GameManager.Instance.isGameActive == true)
        {
            scorePanle.SetActive(true);
            readyPanel.SetActive(false);
            currentScore += Time.deltaTime * 10;
            ScoreCheck();
            bestScoreCheck();
        }
        else
        {
            currentScore = 0;
            scorePanle.SetActive(false);
            readyPanel.SetActive(true);
        }
    }

    private void ScoreCheck()
    {
        if (currentScore < 10)
        {
            currentScoreText.text = "0000" + (int)currentScore;
        }
        else if (currentScore < 100)
        {
            currentScoreText.text = "000" + (int)currentScore;
        }
        else if (currentScore < 1000)
        {
            currentScoreText.text = "00" + (int)currentScore;
        }
        else if (currentScore < 10000)
        {
            currentScoreText.text = "0" + (int)currentScore;
        }
        else
        {
            currentScoreText.text = "" + (int)currentScore;
        }
    }

    private void bestScoreCheck()
    {
        if (bestScore < 10)
        {
            bestScoreText.text = "HI: 0000" + (int)bestScore;
        }
        else if (bestScore < 100)
        {
            bestScoreText.text = "HI: 000" + (int)bestScore;
        }
        else if (bestScore < 1000)
        {
            bestScoreText.text = "HI: 00" + (int)bestScore;
        }
        else if (bestScore < 10000)
        {
            bestScoreText.text = "HI: 0" + (int)bestScore;
        }
        else
        {
            bestScoreText.text = "HI: " + (int)bestScore;
        }
    }

    public void EndGame()
    {
        AudioManager.Instance.musicSource.Stop();
        bestScore = PlayerPrefs.GetFloat("BestScore");

        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.GetFloat("BestScore", bestScore);
        }

        GameManager.Instance.isGameActive = false;
    }
}
