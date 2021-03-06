using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private GameObject director;
    private Vector3 defaultScale;
    private Vector3 scale;
    private float defaultMass;

    private float jumpForce = 700.0f;

    private float scaleRatio = 1.3f;
    private float massRatio = 1.2f;

    private float maxScale = 1.0f;
    private float maxMass = 10.0f;

    private float resetTimer = 3.0f;
    private Coroutine resetScaleAndMass;
    private bool isRunningResetScaleAndMass = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        director = GameObject.Find("GameDirector");
        defaultScale = gameObject.transform.localScale;
        scale = gameObject.transform.localScale;
        defaultMass = rigid2D.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }

    /// <summary>
    /// What to do when a cat collides with a bomb or fish
    /// </summary>
    /// <param name="collision">bomb or fish object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<ParticleSystem>().Play();

        if (collision.gameObject.tag == "Bomb")
        {
            // Go to GameOverScene
            director.GetComponent<GameDirector>().LoadGameOverScene();
        }

        if (collision.gameObject.tag == "Fish")
        {
            // Add score
            director.GetComponent<GameDirector>().GetFish();

            // Change the scale and mass of the cat
            EnlargeScale();
            MakeHeavier();

            // Reset cat scale and mass after the specified time
            if (isRunningResetScaleAndMass)
            {
                StopCoroutine(resetScaleAndMass);
            }
            resetScaleAndMass = StartCoroutine(ResetScaleAndMass(resetTimer));
        }

        Destroy(collision.gameObject);
    }


    /// <summary>
    /// Enlarge the scale of the cat
    /// </summary>
    private void EnlargeScale()
    {
        scale.x *= scaleRatio;
        scale.y *= scaleRatio;
        if (scale.x > maxScale)
        {
            scale.x = maxScale;
            scale.y = maxScale;
        }
        transform.localScale = scale;
    }


    /// <summary>
    /// Make the cat heavier
    /// </summary>
    private void MakeHeavier()
    {
        rigid2D.mass *= massRatio;
        if (rigid2D.mass > maxMass)
        {
            rigid2D.mass = maxMass;
        }
    }


    /// <summary>
    /// Coroutine that resets the scale and mass of the cat after a specified time
    /// </summary>
    /// <param name="resetTimer">reset timer</param>
    /// <returns>yield is causing wait time to pause resetTimer seconds</returns>
    private IEnumerator ResetScaleAndMass(float resetTimer)
    {
        isRunningResetScaleAndMass = true;
        yield return new WaitForSeconds(resetTimer);
        transform.localScale = defaultScale;
        scale = defaultScale;
        rigid2D.mass = defaultMass;
        isRunningResetScaleAndMass = false;
    }
}
