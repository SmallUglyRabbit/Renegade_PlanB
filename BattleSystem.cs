using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

//Description: 

//This script controls the battlesystem, leveling and enemy prefabs. 
//It works in tandem with the Randomization script utilizing Global Variables. It also applies sound effects to the different actions 
//in the battle scene. 

//This enum tracks the current step of the battle. 
public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
	//The audio effects and soundtrack for the battle are kept here and on the Hierarchy. 
	public AudioSource[] BattleSongArray;
	public AudioSource[] BattleSoundEffectArray;
	
	//This variable returns the player to the specified area of the previous scene where they left off. 
	public Transform PlayerMAPTransform;
	
	//These variables hold the prefab objects that spawn into the battle scene. 
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	
	//This holds several Enemy Prefabs
	public GameObject[] EnemyArray;
	
	//These are the areas where the player/enemy graphics appear at .
	public Transform playerBattleStation;
	public Transform enemyBattleStation;
	
	//These help interface with the HUD
	UnitScript playerUnit; 
	UnitScript enemyUnit;
	
	//These host the HUD settings.
	public BattleHUD playerHUD; 
	public BattleHUD enemyHUD; 
	
	//This variable is used to display battle status/updates. 
	public TextMeshProUGUI dialogueText; 
 
 
	
	
	
	
	
	public BattleState state;
    // Start is called before the first frame update
    void Start()
	{
		
	    state = BattleState.START;
	    StartCoroutine(SetupBattle());
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
    
	
	//Random Number Generator that takes two values and rolls a random number between them.
	int Roll(int MinNum, int MaxNum) //This is a script local roll system
	{
		
		int num = Random.Range(MinNum, MaxNum);
		return num;
	}
	
	/*
	void EnemySelector()//Currrent Enemies, more added later in Assignment 3
	//Will be re-used in assignment 3 for spell effect additives.
	{
		if(GlobalsScript.RandomEncounterCategory == 2 )
		{
			enemyUnit.UnitName = GlobalsScript.UnitName = "LVL2 MedTeam";
			enemyUnit.UnitLevel = GlobalsScript.UnitLevel = 2; 
			enemyUnit.Damage = GlobalsScript.Damage = 15; 
			enemyUnit.MaxHP = GlobalsScript.MaxHP = 35; 
			enemyUnit.CurrentHP = GlobalsScript.CurrentHP = 35; 
			enemyUnit.EnemyEXP = GlobalsScript.EnemyEXP = 25;
			//	GlobalsScript.EnemyImage = GlobalsScript.CleanUpCrew1;
			//Tough guys
			
		}
		else if(GlobalsScript.RandomEncounterCategory == 1)
		{
			enemyUnit.UnitName = GlobalsScript.UnitName = "LVL1 MedTeam";
			enemyUnit.UnitLevel = GlobalsScript.UnitLevel = 1; 
			enemyUnit.Damage = GlobalsScript.Damage = 10; 
			enemyUnit.MaxHP = GlobalsScript.MaxHP = 25; 
			enemyUnit.CurrentHP = GlobalsScript.CurrentHP = 25;
			enemyUnit.EnemyEXP = GlobalsScript.EnemyEXP = 15;
			//GlobalsScript.EnemyImage = GlobalsScript.CleanUpCrew2;
			//MedTeam 
			//Get Globals and load them into the prefab. 
			//Weak Guys
		}
		//Select an enemy based on Random choice and also based on player experience level 
		//Stop giving out enemy battles that are too weak for the player
		//Decrease encounter frequency if player HP is low 
		//Select from a list of enemies 
	}
	*/
	
	//Selects the appropriate Enemy Prefab based on the random number assigned.  Optimize with switch
	//for assignment3 
	void EnemyPrefabSelector()
	{
		if(GlobalsScript.RandomEncounterCategory == 0 )
		{
			//
		}
		if(GlobalsScript.RandomEncounterCategory == 1 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[1], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 2 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[2], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		
		if(GlobalsScript.RandomEncounterCategory == 3 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[3], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 4 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[4], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 5 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[5], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 6 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[6], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 7 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[7], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();

		}
		if(GlobalsScript.RandomEncounterCategory == 8 )
		{
			GameObject enemyGO= Instantiate(EnemyArray[8], enemyBattleStation);
			enemyUnit = enemyGO.GetComponent<UnitScript>();
		}
	}
		


	//This function is called to setup the battle and instantiate 
	//the player and enemy prefabs. 
	IEnumerator SetupBattle()
	{
	
		
		GameObject playerGO = Instantiate(playerPrefab,playerBattleStation);
		playerUnit = playerGO.GetComponent<UnitScript>();
		EnemyPrefabSelector();
		//GameObject enemyGO= Instantiate(EnemyArray[1], enemyBattleStation);

	
		//EnemySelector();
		BattleSongArray[0].Play();
		dialogueText.text = enemyUnit.UnitName + " appears!";
		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit); 
		
		yield return new WaitForSeconds(2f);
		
		state = BattleState.PLAYERTURN;
		PlayerTurn();
		
	}
	
	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}
	
	//This function randomizes the enemy and player's chance to hit each other.  
	public bool DidIHit(int Low, int High)
	{
		float Med = High/2; 
		float RollNumber = Roll(Low,High);
		if (RollNumber > Med)
		{
			//Hit
			return true; 
		}
		else
		{
			//Miss
			return false; 
		}
	}
	
	//This function takes care of the player's attack
	IEnumerator PlayerAttack()
	{
		bool DidIHitIt = DidIHit(1,6);//Returns a random true or false
		Debug.Log("DidIHitIt = " + DidIHitIt);
		if(DidIHitIt == true)
		{
			BattleSoundEffectArray[0].Play();
			dialogueText.text = "Player's attack successful.";
			enemyUnit.TakeDamage(playerUnit.Damage);//Do I need this? 
			enemyHUD.SetHP(enemyUnit.CurrentHP);//HUD Updates
			
			//Player's attack hits
			//bool isDead = enemyUnit.TakeDamage(playerUnit.Damage); //enemy takes damage
			//Status bar notifies player
			yield return new WaitForSeconds(2f);
			
			//Checks if the player killed the enemy
			if(enemyUnit.CurrentHP <= 0)
			{
				BattleSoundEffectArray[4].Play();
				state = BattleState.WON;
				EndBattle();
				//End the battle, player has won
			}
			else //This line switches the turn, the other is redundant and not used
			{
				Debug.Log("Keep Fighting");
				state = BattleState.ENEMYTURN;
				StartCoroutine(EnemyTurn());
				//Enemy Turn, still fighting
			}
		
		}
		else if(DidIHitIt == false)
		{
			BattleSoundEffectArray[2].Play();
			dialogueText.text = "I missed!";
			yield return new WaitForSeconds(2f);
		
			//Missed the attack, switch to enemy turn
			
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
		
	}
	
	//This functions takes care of the enemies turn. 
	IEnumerator EnemyTurn()
	{
		//AI
		//if player is near death, then don't attack
		//if player is full health attack
		//if enemy is near death, heal or use special attack 
		bool DidIHitIt = DidIHit(0,6);
		if(DidIHitIt == true)
		{
			//Enemy Hit
			BattleSoundEffectArray[1].Play();
			dialogueText.text = enemyUnit.UnitName + " attacks and hit the target";
			yield return new WaitForSeconds(1f);
			bool isDead = playerUnit.TakeDamage(enemyUnit.Damage);
			dialogueText.text = "The player took damage";
			playerHUD.SetHP(playerUnit.CurrentHP);
			yield return new WaitForSeconds(1f);
			if(isDead)//Find out if the player is dead or not
			       {
			     		state = BattleState.LOST;
				EndBattle();
				
		         	}
			else
			{// player still alive, switch to players turn
				dialogueText.text = "The player's turn!";
				yield return new WaitForSeconds(1f);
			     		state = BattleState.PLAYERTURN;
		     			PlayerTurn();
			         }
		}
		else
		{
			//Enemy missed, switch to player's turn
			BattleSoundEffectArray[2].Play();
			dialogueText.text = "Enemy missed!";
			yield return new WaitForSeconds(1f);
		    state = BattleState.PLAYERTURN;
	     	PlayerTurn();
		}
	}
	
	//Player Level UP: Checks to see if the player has gained a new level. Simplistic system at the moment. Assignment 3 will see different levels of exp to attain higher levels and new perks at 
	//certain levels.
	void CheckForLevelUp()
	{
		if(GlobalsScript.PlayerEXP == 100)
		{
			BattleSoundEffectArray[6].Play();
			dialogueText.text = "You gained a level.";
			GlobalsScript.PlayerLevel += 1; 
			GlobalsScript.MaxHP += 5; 
			GlobalsScript.Damage += 1; 
			GlobalsScript.PlayerEXP -= 100; //Reset the Level gains, assignment 3 will have different tiers
			//GlobalsScript.Armour += 1;
		}
	}
	
	//Still required?
	//Applies all gains made from previous levels. 
	void ApplyLevelGains()
	{
		if ( playerUnit.UnitLevel == GlobalsScript.PlayerLevel)
		{
			Debug.Log("No gains required!");
			return;
		}
		else
		{ 
			playerUnit.UnitLevel += 1; 
			playerUnit.Damage += GlobalsScript.PlayerDamageBonus; 
			playerUnit.MaxHP += GlobalsScript.PlayerHPBonus; 
			Debug.Log("All gains loaded");
		}
	 
	}
	
	//Adds player EXP to the total at the end of a battle. 
	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle.";
			//yield return new WaitForSeconds(1f);
			dialogueText.text = "You gained " + enemyUnit.EnemyEXP + " experience points.";
			GlobalsScript.PlayerEXP += enemyUnit.EnemyEXP;
			CheckForLevelUp();
			ReturnToScene(); 
	
		}
		else if(state == BattleState.LOST)
		{
			BattleSoundEffectArray[5].Play();
			dialogueText.text = "You were defeated. Game Over!";
			Application.Quit();
			//Will give option to return to last save point. 
			//Reload Save Point
		}
	}
	
	//Returns the player to the area specified from the previous scene.
	void ReturnToScene()
	{
		PlayerMAPTransform.position = GlobalsScript.lastposition;//saves the last position at regular intervals
	
		SceneManager.LoadScene(GlobalsScript.CurrentMapScene);
 
		Debug.Log("Return to scene");
	}
	
	//Used when ATTACK is pressed during a battle. 
	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			
			return;
		StartCoroutine(PlayerAttack());
		
	}
	
	//Used when HEAL is pressed during a battle. 
	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			
			return;
		StartCoroutine(PlayerHeal());
	}
	
	//This functions takes care of the player heals when they are 
	//triggered during the Battle Scene.
	IEnumerator PlayerHeal()
	{
		bool CanIHeal = GlobalsScript.CheckForHeals(); //Determines if there are enough HEALS left 
		if(CanIHeal)
		{ 
			playerUnit.Heal(10);
			GlobalsScript.Heals -= 1;//1 Heal used up
			dialogueText.text = "you feel better! You have " + GlobalsScript.Heals + " left!";
			yield return new WaitForSeconds(1f);
		
		}
		else 
		{
			dialogueText.text = "You are out of Heals!";
			yield return new WaitForSeconds(1f);
		}
		dialogueText.text = "It's the enemies turn now!";
		playerHUD.SetHP(playerUnit.CurrentHP);
		yield return new WaitForSeconds(2f);
		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}
	
}

