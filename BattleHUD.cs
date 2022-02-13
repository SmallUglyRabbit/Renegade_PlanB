using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

//Description: 
//This script helps setup the battle Heads Up Display that shows the unit names, and Hit Point sliders. 
public class BattleHUD : MonoBehaviour
{
	
	public TextMeshProUGUI nameText; 
	public Slider hpSlider;
    // Start is called before the first frame update
    
	public void SetHUD(UnitScript unit)
	{
		nameText.text = unit.UnitName;
		hpSlider.maxValue = unit.MaxHP;
		hpSlider.value = unit.CurrentHP;
	}
	
	public void SetHP(int hp)
	{
		hpSlider.value = hp; 
	} 
}
