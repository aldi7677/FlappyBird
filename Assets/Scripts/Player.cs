using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float up = 200f;
	public bool isDead = false;

	private Rigidbody2D rb2d;
	private Animator anim;
	public AudioSource hit;
	public AudioSource wing;

	private bool isAlreadyPlay = false;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (isDead) { return; }

		if (Input.GetMouseButtonDown(0))
		{
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(new Vector2(0, up));
			wing.Play();
		}
		
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		isDead = true;
		rb2d.velocity = Vector2.zero;
		anim.SetTrigger("Die");
		GameControl.Instance.Die();
		hit.Play();
	}

}
