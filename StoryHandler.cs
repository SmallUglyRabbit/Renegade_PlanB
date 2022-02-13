using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace SimpleMan.CoroutineExtensions
{ 

	public class StoryHandler : MonoBehaviour
	{
		[SerializeField] 
		TextMeshProUGUI m_Object;
		public GameObject Story1;
		public GameObject ParasiteTextObject;

	
	 //Assignment #3 build a system that handles all of this in global scripts and arrays. 
	 
		void Start()
		{
			Story1.SetActive(true);
		}
	
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				m_Object.text = "Where Am I? <wave>  <shake>What have they done?</shake> </wave>";
				this.Delay(5, ONDONE);
			}
		}
		private void ONDONE()
		{
			m_Object.text = "Why are you alive?";
			this.Delay(5,StopTalking);
		}
	
		private void StopTalking()
		{
			m_Object.text = "";
			Story1.SetActive(false);
		}
		void FixedUpdate()
		{
 	}
	
     
	}
}