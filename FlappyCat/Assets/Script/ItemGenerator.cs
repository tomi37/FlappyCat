using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject fishPrefab;
    private float span = 1.0f;
    private float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item = Instantiate(bombPrefab) as GameObject;
            float y = Random.Range(-4.5f, 4.5f);
            item.transform.position = new Vector3(10, y, 0);
        }
    }
}
