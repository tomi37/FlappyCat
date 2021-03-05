using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float Speed { get; set; } = -4.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -9.0f)
        {
            Destroy(gameObject);
        }
    }
}
