using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


	public Sprite[] sprites ; 
	Vector3 Start_Position; 
	Rigidbody2D rb; 

	[HideInInspector]
	public int id; 

	public ParticleSystem blue; 
	public ParticleSystem red; 
	public ParticleSystem green; 



	// Use this for initialization
	void Start () {
		Start_Position = transform.position; 
		rb = this.GetComponent<Rigidbody2D>();

	}

	public void Init(int _id)
	{
		id = _id; 

		switch(id)
		{
			case 0 :
				red.Play();
				break; 
			case 1 : 
				blue.Play();
				break; 
			case 2 : 
				green.Play();
				break; 
		}

		GetComponent<SpriteRenderer>().sprite = sprites[id]; 
	}
	
	// Update is called once per frame
	void Update () {

		if(this.transform.position.y < -10f)
		{
			Destroy(this.gameObject, 3f); 
		}

	}

	public void Hit(float angle, float strenght)
	{
		Vector2 force =  Quaternion.AngleAxis(angle, Vector3.forward ) * new Vector2(0, strenght) ;
		//Debug.Log("Force : " + force);
		rb.AddForce(force);
	}


}
