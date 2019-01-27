using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

	public int id; 
	public Text counter ; 
	public int count = 0;

	public int target;

	public AudioSource SFX_collect; 

	GameMaster gameMaster; 
	void Start () {

		gameMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameMaster>(); 

	}

	public void Hit()
	{
		count ++ ; 
		SFX_collect.Play();
	}

	// Update is called once per frame
	void Update () {

		counter.text = count.ToString() +  "\n" + "-\n" + target.ToString(); 
	}

		private void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("HIT TARGET : " + other.gameObject.name );

		if(other.gameObject.tag == "Ball")
		{
			Ball hit_ball = other.gameObject.GetComponent<Ball>();
			//Debug.Log("HIT TARGET : " + hit_ball.id );
			if(hit_ball.id == id && count < target)
			{
				Hit(); 
			}
			else
			{
				Destroy(other.gameObject, 2f);

				Invoke("Reward", 2f);
				
			}
		}
	}

	void Reward()
	{
		switch(id)
		{
			case 0 :
				gameMaster.Add_Coin(1);
				break; 
			case 1 : 
				gameMaster.Add_Coin(2);
				break; 
			case 2 : 
				gameMaster.Add_Coin(4);
				break; 
		}
	}
}
