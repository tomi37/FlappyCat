using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rigid2D;

    private Vector3 defaultScale;
    private Vector3 scale;
    private float scaleRatio = 1.3f;
    private float maxScale = 1.0f;

    private float jumpForce = 700.0f;

    private float defaultMass;
    private float massRatio = 1.2f;
    private float maxMass = 10.0f;
    private float catTimer = 3.0f;

    private Coroutine resetScaleAndMass;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        defaultScale = gameObject.transform.localScale;
        scale = gameObject.transform.localScale;
        defaultMass = rigid2D.mass;
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid2D.AddForce(transform.up * this.jumpForce);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            Debug.Log("Tag=Bomb");
            // TODO:
            // gameoverシーンへ遷移
        }
        if (collision.gameObject.tag == "Fish")
        {
            // 猫の大きさを変更
            scale.x *= scaleRatio;
            scale.y *= scaleRatio;
            if (scale.x > maxScale)
            {
                scale.x = maxScale;
                scale.y = maxScale;
            }
            transform.localScale = scale;

            // 猫の重さを変更
            rigid2D.mass *= massRatio;
            if (rigid2D.mass > maxMass)
            {
                rigid2D.mass = maxMass;
            }

            // 指定時間後に猫の大きさと重さをリセット
            if (isRunning)
            {
                StopCoroutine(resetScaleAndMass);
            }


            resetScaleAndMass = StartCoroutine(ResetScaleAndMass(catTimer));
        }

        Destroy(collision.gameObject);
    }

    private IEnumerator ResetScaleAndMass(float catTimer)
    {
        isRunning = true;
        yield return new WaitForSeconds(catTimer);
        transform.localScale = defaultScale;
        scale = defaultScale;
        rigid2D.mass = defaultMass;
        isRunning = false;
    }
}
