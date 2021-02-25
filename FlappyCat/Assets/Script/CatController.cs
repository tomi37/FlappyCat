using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private float jumpForce = 680.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            Debug.Log("Tag=Bomb");
        }
        if (collision.gameObject.tag == "Fish")
        {
            Debug.Log("Tag=Fish");
        }

        Destroy(collision.gameObject);
    }
}
