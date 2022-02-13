using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
	[SerializeField]
	Rigidbody2D PlayerRigidbody2D;
	public float movementSpeed;
	Vector2 movement; 
	
	
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("UP AND RUNNING");
	}
	void Update()
	{
		
		movement.x = Input.GetAxisRaw("Horizontal"); //This is working
		Debug.Log("X");
		Debug.Log(movement.x); 
		movement.y = Input.GetAxisRaw("Vertical");
		Debug.Log("Y");
		Debug.Log(movement.y); 
		//CheckKeys();
	}
	

	void CheckKeys()
	{
		
		if (Input.GetKeyDown("space"))
		{
			print("space key was pressed");
			PlayerRigidbody2D.velocity = new Vector2(0,1);
			
		}
		if(Input.GetKey("a"))
		{
			print("A");
			print("LEFT");
		}
		if (Input.GetKey("s"))
		{
			print("DOWN");
		}
		if(Input.GetKey("d"))
		{
			print("Right");
			 
		}
		if (Input.GetKey("w"))
		{
			print("up");
		} 
		//Get Key fires continuously 
		//Get Key Down fires once
	}
	
	void FixedUpdate() //not working. 
	{
		//	PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position * movement * movementSpeed * Time.fixedDeltaTime);
		if (this.movement.x != 0){
			 
			PlayerRigidbody2D.velocity = new Vector2(this.movement.x * this.movementSpeed, this.movement.y);
	}
	
	
  
	}
}
