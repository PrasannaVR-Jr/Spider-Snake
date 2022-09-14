using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    [SerializeField] BoxCollider2D Wall;
    Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        bounds = Wall.bounds;
        GenerateFood();

    }

    
    void GenerateFood()
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        
        transform.position = new Vector3(x * 1f, y * 1f,0f);
        Debug.Log(x+","+y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "head")
            GenerateFood();
    }
}
