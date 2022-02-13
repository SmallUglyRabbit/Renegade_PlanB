using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
//namespace SimpleMan.CoroutineExtensions

//Each story script is used to take advantage of the TEXT ANIMATOR ASSET which 
//doesn't exactly work like it should. The instructions say to just add 
//certain tags but then including the namespace or whatever doesn't give access 
//to the objects required to utilize the co-routines. 



public class StoryScript : MonoBehaviour
{
	[SerializeField] 
	public TextMeshProUGUI PlayerTalk;
	public TextMeshProUGUI ParasiteTalk;
	
	public GameObject TheTrigger;//This stores the trigger
	public Rigidbody2D Player_RigidBody; 
	

	
	//This script will be a template. Everytime the player steps on a trigger for dialog, a version of this 
	//script will execute. It will init the trigger, check if the player has entered on to it and 
	//in order to check a condition, will check a global flag to see if it needs to fire or will 
	//set a flag.
	
	//This is the first story script.
	 
	void Start()//Turns on this trigger
	{
		TheTrigger.SetActive(true);
		
	}
	//This is independent of the trigger game object so each story script.cs would need to be different 
	//ala storyscript1 for this one storyscript2 for another. 
	
	
	//if presskey, then ONDONE(); but how to make a global solution or is it even possible. 
	//but the trigger has to be really big. 
	

	 void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[0] == false)
		{
			PlayerTalk.text = "{fade}Ugh my head...{/fade} ";
			ParasiteTalk.text = "Where Am I?   <shake>What have they done?<shake/>";
			//this.Delay(4,ONDONE);
			TheTrigger.SetActive(false);
		}
		 
	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
 
	private void ONDONE()
	{
		Debug.Log("ONDONE");
		GlobalsScript.StoryFlagsArray[0] = true; 
		PlayerTalk.text = "Hello? Who said that? ";
		ParasiteTalk.text = "You stupid creature, why are you stll alive?";
	}
	
	private void StopTalking()
	{
		PlayerTalk.text = "";
		ParasiteTalk.text = "";
		//TheTrigger.SetActive(false);
		GlobalsScript.Inventory.Add("CrackedVial");//Used in Assignment 3	
	}

	/*Interferes with Text Animator for some reason. 
	public void PressPause()
	{
		if(Input.GetKeyDown(KeyCode.Space) && GlobalsScript.StoryFlagsArray[0] == false)
		{
			Debug.Log("Space Pressed");
			//Player_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;//Unfreeze
			ONDONE();
		}
		else
		{ 
			StopTalking(); 
			//Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;//Freeze till dialog is done	
				
		}
	}
	*/


}
	
