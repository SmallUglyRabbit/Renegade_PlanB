using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Doesnt WORK

public class CheckFlag : MonoBehaviour
{
	public GameObject TheMedTeamGraphics;
	
    // Start is called before the first frame update
	void Update()
    {
    	if (GlobalsScript.StoryFlagsArray[3] == true)
    	{
	    	Destroy(TheMedTeamGraphics); 
    	}
    }
     
}
