using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerCheck : MonoBehaviour
{
    SpriteRenderer rend;
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bruh");
        if (collision.gameObject.CompareTag("innerCorner")) 
        {
            rend.enabled = true;
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
