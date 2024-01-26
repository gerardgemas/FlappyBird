using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int force = 5;
    public GameManager gameManager;
    public Animator flap;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.start == true)
        {
            flap.SetBool("start", true);
            rb.gravityScale = 1;
        } else
        {
            flap.SetBool("start", false);
        }
        if (Input.GetMouseButtonDown(0)&&gameManager.start || Input.GetKeyDown(KeyCode.Space) && gameManager.start)
        {
            flap.SetBool("flap", !flap.GetBool("flap"));
            FreezeMovement();
            AddForce();
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void AddForce()
    {
        Vector2 upwardForce = new Vector2(0, force);
        rb.AddForce(upwardForce, ForceMode2D.Impulse);
    }

    public void FreezeMovement()
    {
        rb.velocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        flap.SetBool("start", false);
        gameManager.endGame();
    }
}
