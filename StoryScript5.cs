using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace SimpleMan.CoroutineExtensions
{ 

	public class StoryScript5 : MonoBehaviour
	{
		[SerializeField] 
		public TextMeshProUGUI PlayerTalk;
		public TextMeshProUGUI ParasiteTalk;
		public GameObject TheTrigger;//This stores the trigger
	


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
	
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" & GlobalsScript.StoryFlagsArray[1] == false)
			{
				PlayerTalk.text = "Where is that coming from?";
				ParasiteTalk.text = "  <wave>  <shake>You've wasted your chance stupid stupid fools!  </shake> </wave>";
				this.Delay(5, ONDONE);
			}
		}
		private void ONDONE()
		{
			ParasiteTalk.text = "...";
			this.Delay(5,StopTalking);
		}
	
		private void StopTalking()
		{
			PlayerTalk.text = "Where are you?"; 
			ParasiteTalk.text = "Just a <shake>WASTE NOW YOU FOOLS!</shake>";
			TheTrigger.SetActive(false);
			GlobalsScript.StoryFlagsArray[1] = false; //Changes the first story flag to false.
		}
		void FixedUpdate()
		{
 	}
	
     
	}
}