using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject fishPrefab;
    private int ratio = 3;
    private float itemRange = 4.5f;
    private float delta = 0.0f;
    private float span = 0.5f;

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            GameObject item;

            int dice = Random.Range(1, 11);
            if (dice <= ratio)
            {
                item = Instantiate(fishPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            float y = Random.Range(-itemRange, itemRange);
            item.transform.position = new Vector3(10, y, 0);
        }
    }
}
