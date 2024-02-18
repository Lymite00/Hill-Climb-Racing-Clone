using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public CircleCollider2D mycollider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if  (mycollider.gameObject.CompareTag("Ground"))
        {
            FindObjectOfType<Controller>().ground = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (mycollider.gameObject.CompareTag("Ground"))
        {
            FindObjectOfType<Controller>().ground = false;
        }
    }
}
