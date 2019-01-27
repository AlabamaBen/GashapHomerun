using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {


	public AudioSource SFX_Swing, SFX_Hit; 

	public Force_Bar force_Bar; 
	public float Hit_Strenght = 300f;
	public float Hit_Strenght_Offset = 100f; 

	GameObject Touching_Ball; 

	bool holding = false; 

	bool smashing = false; 

	public Animation smash_animation ; 

	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.gameObject.tag == "Ball")
		{
			Touching_Ball = other.gameObject; 
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		
		if(other.gameObject.tag == "Ball")
		{
			other.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
			Touching_Ball = null; 
		}
	}

	float rot_z; 
	void Update () {

		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		
		float angle = rot_z - 90;

		transform.rotation = Quaternion.Euler(0f, 0f, angle);


		if(Input.GetMouseButtonUp(0) && holding)
		{
			if(Touching_Ball != null) 
			{
				Invoke("Hit", 0.1f); 
			}
			smash_animation.Stop("Bat_HoldBack");
			SFX_Swing.Play();
			smash_animation.Play("Bat_Smash");
			holding = false;
		}
		if(Input.GetMouseButtonDown(0) && !holding )
		{
			smash_animation.Play("Bat_HoldBack");
			holding = true; 
		}
		
	}

	void Hit()
	{
		if(Touching_Ball != null)
		{
			Touching_Ball.GetComponent<Ball>().Hit(rot_z - 90, Hit_Strenght_Offset  +  Hit_Strenght * force_Bar.stop_force );
			Touching_Ball = null;
			SFX_Hit.Play();
		}
	}
}
