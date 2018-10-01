using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour {

	private BoxCollider2D groundColi;
	private float groundHorizontalLeght;
	// Use this for initialization
	void Start () {
		groundColi = GetComponent<BoxCollider2D>();
		groundHorizontalLeght = groundColi.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -groundHorizontalLeght)
		{
			RepositionBackground();
		}
	}

	private void RepositionBackground()
	{
		Vector2 groundOffset = new Vector2(groundHorizontalLeght * 2, 0);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
