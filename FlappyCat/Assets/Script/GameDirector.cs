using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject timeText;
    private GameObject scoreText;
    private float time = 30.0f;
    private float point = 0.0f;

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
        point += Time.deltaTime;
        timeText.GetComponent<Text>().text = time.ToString("F1");
        scoreText.GetComponent<Text>().text = point.ToString("0000");
    }

    public void GetFish()
    {
        point += 50.0f;
    }
}
