using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarPool : MonoBehaviour {
	public float spawnRate = 4f;
	public int columnPoolSize = 5;
	public float columnYMin = -2f;
	public float columnYMax = 2f;

	private float timeSinceLastSpawn;
	private float spawnXpos = 10f;
	private int currentColumn = 0;

	public GameObject prefabs;
	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);

	private void Start()
	{
		columns = new GameObject[columnPoolSize];
		for(int i = 0; i < columnPoolSize; i++)
		{
			columns[i] = (GameObject)Instantiate(prefabs, objectPoolPosition, Quaternion.identity);
		}
	}

	private void Update()
	{
		timeSinceLastSpawn += Time.deltaTime;
		if (!GameControl.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
		{
			timeSinceLastSpawn = 0;

			float spawnYPos = Random.Range(columnYMin, columnYMax);
			columns[currentColumn].transform.position = new Vector2(spawnXpos, spawnYPos);

			currentColumn++;

			if (currentColumn >= columnPoolSize) { currentColumn = 0; }
		}
	}
}
