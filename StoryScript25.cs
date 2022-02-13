using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace SimpleMan.CoroutineExtensions
{ 

	public class StoryScript25 : MonoBehaviour
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
	
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player" & GlobalsScript.StoryFlagsArray[25] == false)
			{
				PlayerTalk.text = "Ok if you want to live here, first rule, you do not give me orders.";
				ParasiteTalk.text = "Eh... Do you know who I am?   I... fine.";
				Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePosition;//Freeze till dialog is done	
		
				this.Delay(5, ONDONE);
			}
		}
		private void ONDONE()
		{
			PlayerTalk.text = "Second rule, you do not own my body and you will be leaving, how do I get you out, don't lie to me.";
			ParasiteTalk.text = "Hmmm... I don't like this, this is my rightful property, I paid for it.";
			this.Delay(20,WAIT);
			PlayerTalk.text = "SHUT UP! [smacks self in face] You get out or else I swear [smacks face again]";
			ParasiteTalk.text = "AGH! STOP IT HUMAN! There is a way... its on our... ship but you.. er we will never make it.";
	
		}
	
		private void WAIT()
		{
			
		}
		private void StopTalking()
		{ 
			Player_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;//Unfreeze
			
			GlobalsScript.StoryFlagsArray[25] = false; //Changes the first story flag to false.
		}
		void FixedUpdate()
		{
 	}
	
     
	}
}

