using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script removes the title screen. 
//On any key press turn this off or destroy object. 
public class TitleOff : MonoBehaviour
{
	[SerializeField]
	GameObject titleScreen; 
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.anyKey)
	    {
	    	Destroy(titleScreen);
		    Debug.Log("A key or mouse click has been detected");
	    }
    }
}
