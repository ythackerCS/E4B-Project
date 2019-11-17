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
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (health > 0)
            {
                rigidbody.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
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
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ToiletPaper>())
        {
            takeDamage(1f);
        }
    }

}
