﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    private GameObject timeText;
    private GameObject scoreText;
    private float time = 30.0f;
    private float score = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time");
        scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        score += Time.deltaTime;
        timeText.GetComponent<Text>().text = time.ToString("F1");
        scoreText.GetComponent<Text>().text = score.ToString("0000");

        if (time < 0.0f)
        {
            LoadGameOverScene();
        }
    }

    public void LoadGameOverScene()
    {
        SceneManager.sceneLoaded += GameOverSceneLoaded;
        SceneManager.LoadScene("GameOverScene");
    }


    // GameOverSceneを呼ぶ前に、scoreをGameOverDirectorクラスのscoreに保存
    private void GameOverSceneLoaded(Scene next, LoadSceneMode mode)
    {
        var gameOver = GameObject.FindWithTag("GameOverDirector").GetComponent<GameOverDirector>();
        gameOver.Score = score;
        SceneManager.sceneLoaded -= GameOverSceneLoaded;
    }


    public void GetFish()
    {
        score += 50.0f;
    }
}
