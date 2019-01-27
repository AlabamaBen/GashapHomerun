using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_Bar : MonoBehaviour {

	public Animation animation ; 

	[HideInInspector]
	public float stop_force = 0f; 

	public Transform mask; 
	
	bool playing = false; 

	// Update is called once per frame
	void Update () {
		
		if( !playing && Input.GetMouseButtonDown(0))
		{
			animation.Stop(); 
			animation.Play();
			animation["mask"].speed = 1f; 
			playing = true; 

		}
		if( playing && Input.GetMouseButtonUp(0))
		{
			stop_force = 1 - mask.localScale.x; 
			//Debug.Log("Force : " + stop_force ); 
			animation["mask"].speed = 0f; 
			playing = false;
		}

	}
}
