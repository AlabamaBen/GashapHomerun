using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameMaster : MonoBehaviour {


	public GameObject End_Canvas, Wintext, Loosetext; 

	public Target blue, red, green; 

	public AudioSource SFX_InsertCoin, SFX_WinCoin, SFX_Win, SFX_Loose; 

	public Text Coin_Diplay; 

	public Bat bat; 

	//public Animation Coin_animation;
	public int coins = 20; 

	bool Game_Ended = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	public void Use_Coin()
	{
		coins --; 
		SFX_InsertCoin.Play();
		//Coin_animation.Play();
	}

	public void Add_Coin(int nbr)
	{
		coins += nbr; 
		SFX_WinCoin.Play();
	}

	// Update is called once per frame
	void Update () {

		if(!Game_Ended)
		{
			Coin_Diplay.text = "" + coins ; 

			if(blue.count >= blue.target && green.count >= green.target && red.count >= red.target)
			{
				SFX_Win.Play(); 
				End_Canvas.SetActive(true);
				Wintext.SetActive(true);
				Game_Ended = true;
				bat.enabled = false; 
			}
			if(coins <= 0)
			{
				SFX_Loose.Play();
				End_Canvas.SetActive(true);
				Loosetext.SetActive(true);
				Game_Ended = true;
				bat.enabled = false; 
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Return))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}


		
	}
}
