using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



	public class StoryScriptMEDTEAM : MonoBehaviour
	{
		[SerializeField] 
		public	TextMeshProUGUI MedTeam1;
		public	TextMeshProUGUI MedTeam2;
		public	TextMeshProUGUI MedTeam3; 
		public	TextMeshProUGUI PlayerTalk; 
		public  TextMeshProUGUI ParasiteTalk;
		public GameObject TheTrigger;//This stores the trigger
		public GameObject TheMedTeamGraphics; 
		public Image EnemyPrefabGraphicSpecificImage;//This changes the prefabs graphics to reflect
		//A med team group.
	


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
				PlayerTalk.text = "What? Hello?";
				ParasiteTalk.text = "<shake>I'm here you FOOLS!</shake> ";
				this.Delay(2, ONDONE);
				
			
			}
		}
		private void WAIT()
		{
		
		}
		
		private void CLEARTEXT()
		{
			PlayerTalk.text = "";
			ParasiteTalk.text = "";
			MedTeam1.text = "";
			MedTeam2.text = "";
			MedTeam3.text = "";
		}
		
		private void ONDONE()
		{
			GlobalsScript.RandomEncounterCategory = 1;
			MedTeam1.text = "Put the bodies in here and liquify them.";
			this.Delay(3,WAIT);
			MedTeam2.text = "What, how are you still alive?";
			this.Delay(3,WAIT);
			MedTeam3.text = "Destroy it!";
			this.Delay(3,StopTalking);
		}
	
		private void StopTalking()
		{
			ParasiteTalk.text = "";
			
			SceneManager.LoadScene(GlobalsScript.BattleScene);
			if(GlobalsScript.PlayerEXP != 0)
			{ 
				GlobalsScript.StoryFlagsArray[1] = true; //Ends the first trigger. 
			}
			if(GlobalsScript.StoryFlagsArray[1] == true)
			{ 
				SceneManager.LoadScene("sewermaze");
				TheTrigger.SetActive(false);
			}
			 
			
		}
		void FixedUpdate()
		{
 	}
	
     
	}

