using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverDirector : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    public float Score { get; set; } = 0.0f;

    void Start()
    {
        // GameSceneから取得したスコアを表示
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "Your Score: " + Score.ToString("0000");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
