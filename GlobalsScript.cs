using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalsScript : MonoBehaviour
{
	[SerializeField]
	//public GameObject Player; 
	public static Rigidbody2D Player_RigidBody;
	
	public static bool[] StoryFlagsArray = new bool[31]; //tracks the progression of key points in the story
	public static bool[] ItemFlagsArray = new bool[10]; //tracks the progression of key points in the story
	public static string[] Weapons  = new string[10];
	public static string[] Armour  = new string[10];
	public new string name; 
	int HitPoints,ArmourClass,DamagePower,Chance2Hit,Chance2Evade,ExperiencePoints;
	public static ArrayList Inventory  = new ArrayList();
	//Inventory.Add(1);
	string[] statusEffects = { "Alive", "Dead", "Asleep","Paralyzed","Hurt","FullHealth" };
	// string currentStatus = "Alive";  //To be added in Assignment 3
	public static int Heals = 5; //Number of Heals that the player has available
	//For Adjusting the Battle System to new enemies
	[SerializeField]
	[Header("BattleScene Settings")]
	public static string UnitName; 
	public static int UnitLevel; 
	public static int Damage;
	public static int MaxHP;
	public static int CurrentHP; 
	public static int EnemyEXP; //Experience Points
	public Image EnemyImage;//Enemy Image(not sprite) on the Enemy->EnemyImage Prefab.
	public Image CleanUpCrew1; 
	public Image CleanUpCrew2; 
	public Image CleanUpCrew3; 
	public Image CleanUpCrew4; 
	
	/// <summary>
	public static bool ONDONEFLAG = false;
	public static bool STOPTALKINGFLAG = false;

	/// </summary>
	//All added stats that stack onto the original stats for advanced levels.   
	//The battle system uses common stats for enemy and player, these enhance the stats specifically 
	//for the player.
	public static int PlayerLevel; 
	public static int PlayerDamageBonus; 
	public static int PlayerHPBonus; 
	public static int PlayerHealsBonus;
	public static int PlayerEXP; 
	public static int CurrentScene; //Returns the player to the previous scene after the battle is over.
	public static int PreviousScene; 
	public static int CurrentMapScene; //Set in the playercontroller script on the Player Object in the start()
	public const int BattleScene = 1; 
	public static bool StartSceneOverrideFlag = false; 
	public static int RandomEncounterCategory; 
	public static Vector3 lastposition;
	
	//For changing stats on the fly. 
	public void Addpoints(int points, int BattleStats)
	{
		BattleStats += points;
	}
	public void Subpoints(int points, int BattleStats)
	{
		BattleStats -= points;
	}
	public void Mulpoints(int points, int BattleStats)
	{
		BattleStats *= points;
	}
	public void Divpoints(int points, int BattleStats)
	{
		BattleStats /= points;
	}
	
	public void Awake()
	{
		//Player_RigidBody = GetComponent<Rigidbody2D>();//Player_RigidBody.GetComponent<Rigidbody2D>().po
		//public GameObject Freeze; 
		//GameObject.Find("Player_RigidBody").GetComponent<Rigidbody2D>().freezeRotation = Freeze; 
	}
	
 

		/*
		Battle Stats
		Hitpoints //Goes up after level reached / When 0 game is over
		Armour //Goes up when armour worn
		Chance2Hit //Goes up from certain weapons or armour
		Damage //Goes up from equipping certain weapons
		*/
		
	
	
	
	
	 // <-- 
    // Start is called before the first frame update
    void Start()
	{
		 
		//originalConstraints = Player_RigidBody.constraints;
    }

	//A static randomizer. 
	public static int Roll(int MinNum, int MaxNum)
	{
		int num = Random.Range(MinNum, MaxNum);
		return num;
	}
	
	//The ability to check for used heals. 
	public static bool CheckForHeals()
	{
		if(GlobalsScript.Heals > 0)
		{
			return true; //Enable HEAL Button 
		}
		else 
		{
			return false;
		}
	}
	
    // Update is called once per frame
    void Update()
    {
	    
    }
	void FixedUpdate()
	{
		
	}
	
	//Had to build this as a response to the SimpleMan Coroutine not working properly in WEBGL. 
	//I use this function in all 30 StoryScripts as a Delay Timer, so I have to adjust each 
	//Script now to match the timer in the old co-routine. 
	public static IEnumerator JustWait(float time2wait)
	{
		print(Time.time);
		Debug.Log("go Just Wait for seconds:" + time2wait);//Wait how long?
		yield return new WaitForSeconds(time2wait * Time.deltaTime); 
		
	}
	
	
	public static void presskey()
	{
		if(Input.anyKey)
		{ 	
			
			Debug.Log("PRESSED!");
	
		}
	
	}
	public static RigidbodyConstraints2D originalConstraints;
	
	
	public static void UnFreezeConstraints()
	{
		Player_RigidBody.constraints = originalConstraints;
	}
	
	public static void FreezeConstraints()
	{
		Player_RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
	}
	
}
