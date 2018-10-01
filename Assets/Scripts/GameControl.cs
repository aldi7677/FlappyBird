using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl Instance;
	public float scrollSpeed = -1.5f;
	public bool isGameOver = false;
	private int score = 0;
	public AudioSource points;
	public Text scoreText;
	public GameObject gameOverText;
	public GameObject Tap;

	// Use this for initialization
	void Awake () {
		if(Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		if (firstRun)
		{			
			Time.timeScale = 0;
		}
	}
	
	static bool firstRun = true;
	
	// Update is called once per frame
	void Update () {
		if(isGameOver && Input.GetMouseButtonDown(0) )
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Tap.SetActive(false);
		}
		if (Input.GetMouseButtonDown(0))
		{
			Time.timeScale = 1;
			Tap.SetActive(false);
		}
	}

	public void Score()
	{
		if (isGameOver) { return; }
		points.Play();
		score++;
		Debug.Log(score);
		scoreText.text = "" + score;
	}
	
	

	public void Die()
	{
		isGameOver = true;
		gameOverText.SetActive(true);
	}
}
