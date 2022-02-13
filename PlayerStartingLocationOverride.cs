using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script overrides the starting position from the last map and places the player at the beginning of 
//the Sewer Maze. 
public class PlayerStartingLocationOverride : MonoBehaviour
{
	[SerializeField]
	public Transform startinglocation; 
    // Start is called before the first frame update
	void Awake()
	{
		if(GlobalsScript.StartSceneOverrideFlag == false)
		{
			GlobalsScript.lastposition.Set(startinglocation.position.x,startinglocation.position.y,startinglocation.position.z);
			GlobalsScript.StartSceneOverrideFlag = true;
		}
		 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
