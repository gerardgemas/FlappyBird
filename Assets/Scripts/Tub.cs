using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tub : MonoBehaviour
{
    public float speed = 3; 

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    
}
