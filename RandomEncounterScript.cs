using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounterScript : MonoBehaviour //This is for the sewer maze ZONE 1. It deals with the types of monsters and frequency that they appear in ZONE 1. 
{
	public static int Randoms=0;
	public Transform PlayerPosition;
	
	int RandomEncounterRoll;
	
	public GameObject Player;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			RandomEncounterRoll = GlobalsScript.Roll(1, 100);//Rolls to see which type of encounter if any
			if(RandomEncounterRoll >= 98)
			{
				GlobalsScript.RandomEncounterCategory = 2;//EvilDoctor 
				GlobalsScript.lastposition.x = PlayerPosition.position.x;
				
				GlobalsScript.lastposition.y = PlayerPosition.position.y;
				SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
			}
			else if(RandomEncounterRoll <= 3)
			{
				GlobalsScript.RandomEncounterCategory = 1; //EvilNurse
				GlobalsScript.lastposition.x = PlayerPosition.position.x;
				
				GlobalsScript.lastposition.y = PlayerPosition.position.y;
				SceneManager.LoadSceneAsync(GlobalsScript.BattleScene);
			}
	
			Debug.Log(RandomEncounterRoll);
		}
	}
	
	
	//This function exists to give a timer to this zone. Random numbers are rolled every interval 
	//and weighed against the zone requirements. If the requirements for an encounter are met
	//The Battle Scene is engaged. 
	int timer = 0;
	int interval = 500;
	
	void Update()
	{
		if(timer%interval == 0)
		{
			TestForRandomEncounter();
		}
		timer++;
	}
	
	//This tests for a random encounter at each interval
	void TestForRandomEncounter()
	{
		OnTriggerEnter2D(Player.GetComponent<Collider2D>());
	}
	 
}
