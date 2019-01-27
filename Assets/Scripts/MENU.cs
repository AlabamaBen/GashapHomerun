using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
		}
		
	}
}
