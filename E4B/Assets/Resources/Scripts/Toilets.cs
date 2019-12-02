using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilets : MonoBehaviour
{
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector3(Random.Range(-1, -3), Mathf.Sin(GameController.instance.timeElapsed) * 1f, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
