using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
 
 //This script deals with the prefab stats and also handles taking 
 //damage and healing. 
 public string UnitName;
 public int UnitLevel; 
 public int Damage;
 public  int MaxHP;
 public  int CurrentHP; 
 public int EnemyEXP; 
 public int PlayerEXP;
 

	void start()
	{
		
	}
	
 public bool TakeDamage(int dmg)
 {
 	CurrentHP -= dmg;
 	if(CurrentHP <= 0)
 	{
	 	return true; 		
 	}
 	else
 	{
 		return false;
 	}
 }
 public void Heal(int amount)
 {
 	CurrentHP += amount;
 	if(CurrentHP > MaxHP)
	 	CurrentHP = MaxHP;
 }
}
