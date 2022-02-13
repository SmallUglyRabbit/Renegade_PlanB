using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This script is the exit for the 'Stage 1' that leads into the sewer system. 
public class StoryScriptExit : MonoBehaviour
{
	/*
	void FixedUpdate()
	{
		//	if(GlobalsScript.StoryFlagsArray[3]== true)
		//	{
		//		Destroy(this);//Disable the trigger
		//	}
		
	}
	*/
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" & GlobalsScript.StoryFlagsArray[3] == false)
		{
			Debug.Log("Next Scene Loaded");
			//SceneManager.LoadScene(GlobalsScript.BattleScene);
			//GlobalsScript.StoryFlagsArray[3] = true;
		}
	}
}
