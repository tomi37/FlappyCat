using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float moveLeft = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveLeft * Time.deltaTime, 0, 0);

        if (transform.position.x < -9.0f)
        {
            Destroy(gameObject);
        }
    }
}
