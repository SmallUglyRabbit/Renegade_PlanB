using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




	public class StoryScript6 : MonoBehaviour
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
	
		public void press()
		{
			if(Input.anyKey)
			{
				Player_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;//Unfreeze

			}
			else
			{
				Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;//Freeze till dialog is done	
				
			}
		}
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" && GlobalsScript.StoryFlagsArray[6] == false)
			{
				PlayerTalk.text = "{fade}How did I get here?{/fade} ";
				ParasiteTalk.text = "Listen stupid human, I'll level with you, you are supposed to be dead";
				press();
				//	Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;//Freeze till dialog is done	
				this.Delay(3, ONDONE);
			}
		}
		private void ONDONE()
		{
			
			
			//Player_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;//Unfreeze
			
			PlayerTalk.text = "Who are those people?";
			ParasiteTalk.text = "My minions.";
			this.Delay(5,StopTalking);
		}
	
		private void StopTalking()
		{
			//Player_RigidBody.constraints = RigidbodyConstraints2D.None;
			//TheTrigger.SetActive(false);
			GlobalsScript.StoryFlagsArray[6] = true; //Changes the first story flag to false.
			
			PlayerTalk.text = "";
			ParasiteTalk.text = "";
		
		}
		public void WAIT()
		{
			
		}
		 
 	}
	
     
	
