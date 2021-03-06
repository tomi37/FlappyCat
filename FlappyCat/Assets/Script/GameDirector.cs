using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    private GameObject timeText;
    private GameObject scoreText;
    private GameObject itemGenerator;

    private float time = 30.0f;
    private float score = 0.0f;
    private float addScoreGetFish = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("Time");
        scoreText = GameObject.Find("Score");
        itemGenerator = GameObject.Find("ItemGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        score += Time.deltaTime;
        timeText.GetComponent<Text>().text = time.ToString("F1");
        scoreText.GetComponent<Text>().text = score.ToString("0000");

        // Try level design
        if (10.0f <= time && time < 20.0f)
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(0.4f, -5.0f);
        }
        else if (5.0f <= time && time < 10.0f)
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(0.35f, -7.0f);
        }
        else if (0.0f <= time && time < 5.0f)
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(0.4f, -6.0f);
        }
        else if (time < 0.0f)
        {
            LoadGameOverScene();
        }
    }


    /// <summary>
    /// transition to GameOverScene
    /// </summary>
    public void LoadGameOverScene()
    {
        SceneManager.sceneLoaded += GameOverSceneLoaded;
        SceneManager.LoadScene("GameOverScene");
    }


    /// <summary>
    /// Save the current score to the score of the GameOverDirector class before calling GameOverScene
    /// </summary>
    /// <param name="next">Refer to SceneManager definition</param>
    /// <param name="mode">Refer to SceneManager definition</param>
    private void GameOverSceneLoaded(Scene next, LoadSceneMode mode)
    {
        var gameOver = GameObject.FindWithTag("GameOverDirector").GetComponent<GameOverDirector>();
        gameOver.Score = score;
        SceneManager.sceneLoaded -= GameOverSceneLoaded;
    }


    /// <summary>
    /// Increase score when get a fish
    /// </summary>
    public void GetFish()
    {
        score += addScoreGetFish;
    }
}
