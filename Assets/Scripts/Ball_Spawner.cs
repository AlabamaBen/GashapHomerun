using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spawner : MonoBehaviour {

	public GameObject Ball_Prefab; 

	public Animation moulin_anim; 

	public GameMaster gameMaster; 

	// Use this for initialization
	void Start () {
		
	}
	

	bool canshoot = true;

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1) && canshoot && gameMaster.coins > 0 )
		{

			moulin_anim.Stop();
			moulin_anim.Play();

			canshoot = false; 

			gameMaster.Use_Coin();

			Invoke("Spawn", 1f);

			Invoke("CoolDown", 2f);

		}
	}

	void Spawn()
	{
			GameObject ball = Instantiate(Ball_Prefab, this.transform.position, this.transform.rotation);
			ball.GetComponent<Ball>().Init(Random.Range(0, 3));
	}

	void CoolDown()
	{
		canshoot = true; 
	}
}
