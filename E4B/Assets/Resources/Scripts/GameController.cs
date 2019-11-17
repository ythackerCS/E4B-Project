using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController instance;
    // Start is called before the first frame update

    //Outlets
    public Transform[] spawnPoints;
    public GameObject tp;

    //Configeration
    public float minTPDelay = 0.1f;
    public float maxTPDelay = 5f;


    //State tracking
    public float timeElapsed;
    public float TPdelay; 

    void Start()
    {
        StartCoroutine("TPSpawnTimer");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        float decreaseDelayOverTime = maxTPDelay - ((maxTPDelay - minTPDelay) / 100000 * timeElapsed);
        TPdelay = Mathf.Clamp(decreaseDelayOverTime, minTPDelay, maxTPDelay);
    }
    void Awake()
	{
		instance = this; 
	}

    void SpawnTP()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(tp, randomSpawnPoint.position, Quaternion.identity);
    }

    IEnumerator TPSpawnTimer()
    {
        yield return new WaitForSeconds(TPdelay*2);

        SpawnTP();

        StartCoroutine("TPSpawnTimer");
    }
}
