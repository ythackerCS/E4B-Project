using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
	public static GameController instance;
    // Start is called before the first frame update

    //Outlets
    public Transform[] spawnPoints;
    public GameObject[] dodgeObjects;
    public Text textScore; 

    //Configeration
    public float minTPDelay = 0.1f;
    public float maxTPDelay = 5f;


	//State tracking
	public float timeElapsed;
	public float TPdelay;
    public int score;
    

	void Start()
	{
		StartCoroutine("TPSpawnTimer");
        score = 0;
        InvokeRepeating("UpdateScore", 2.0f, 1.0f);
    }

	// Update is called once per frame
	void Update()
	{
        if (MenuControl.instance.isPaused) {
            return; 
        }
		timeElapsed += Time.deltaTime;

		float decreaseDelayOverTime = maxTPDelay - ((maxTPDelay - minTPDelay) / 1000 * timeElapsed);
		TPdelay = Mathf.Clamp(decreaseDelayOverTime, minTPDelay, maxTPDelay);
        UpdateDisplay();
	}
	void Awake()
	{
		instance = this;
	}

	void SpawnTP()
	{
        if (MenuControl.instance.isPaused)
        {
            return;
        }
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		GameObject randomdogeObject = dodgeObjects[Random.Range(0, dodgeObjects.Length)];

		Instantiate(randomdogeObject, randomSpawnPoint.position, Quaternion.identity);
	}

	IEnumerator TPSpawnTimer()
	{
		yield return new WaitForSeconds(TPdelay * 2);

		SpawnTP();

		StartCoroutine("TPSpawnTimer");
	}

    public void EarnPoints(int pointAmount)
    {
        score += pointAmount; 
    }

    void UpdateDisplay()
    {
        textScore.text = score.ToString(); 
    }
    void UpdateScore()
    {
        score += 1; 
    }
}
