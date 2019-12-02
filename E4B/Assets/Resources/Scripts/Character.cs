using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody2D rigidbody;

    public float health = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        if (MenuControl.instance.isPaused)
        {
            print(MenuControl.instance.isPaused);
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (health > 0)
            {
                rigidbody.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
            }
        }
    }

    void takeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        GetComponent<Rigidbody2D>().gravityScale = 5;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Toilet>())
        {
            takeDamage(1f);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ToiletPaper>())
        {
            print("increase score");
            Destroy(collision.gameObject);
            GameController.instance.EarnPoints(10);
        }
    }
}
