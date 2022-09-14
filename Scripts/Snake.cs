using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float moveSpeed=3;
    [SerializeField] GameObject body,Spider,Shadow;
    List<Transform> list1;
    GameObject shadowTemp;
    // Start is called before the first frame update
    void Start()
    {
        list1 = new List<Transform>();
        list1.Add(gameObject.transform);
        shadowTemp=Instantiate(Shadow, Spider.transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shadowTemp.transform.SetParent(Spider.transform);
        


        for (int i = list1.Count-1; i > 0; i--)
        {
            list1[i].position = list1[i - 1].position;
        }
        MoveSnake();
    }

    void MoveSnake()
    {
        if (Input.GetKey(KeyCode.W) && direction != Vector2.down)
        {
            direction = Vector2.up;
            Spider.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) && direction != Vector2.right)
        {
            direction = Vector2.left;
            Spider.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.S) && direction != Vector2.up)
        {
            direction = Vector2.down;
            Spider.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.D) && direction != Vector2.left)
        {
            direction = Vector2.right;
            Spider.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }

        transform.Translate(direction * moveSpeed*Time.deltaTime);
    }

    void Grow()
    {
        GameObject segment=Instantiate(body);
        segment.transform.position = list1[list1.Count - 1].position;
        list1.Add(segment.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bounds")
        {
            direction = Vector2.zero;
            transform.position = new Vector3(-8.82f, -0.19f, 0f);
        }

        if (collision.gameObject.tag == "Food")
        {
            Grow();            
        }
            
    }
}
