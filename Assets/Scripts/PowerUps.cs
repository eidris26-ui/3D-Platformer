using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUps : MonoBehaviour

{
	public float multiplier = 0.2f;
	public float duration = 4f;
	public GameObject pickupEffect;
	void OnTriggerEnter(Collider other) // Checks For Collider
	{
		if (other.CompareTag("Player")) // If Collider Is Player Item Can Be Picked Up
		{
			StartCoroutine( Pickup(other) );
		}

	}
	IEnumerator Pickup(Collider player)
	{	
		Instantiate(pickupEffect, transform.position, transform.rotation); // Creates An Effect When Object Is Picked Up
		ClayMovement speed = player.GetComponent<ClayMovement>();  //Apply Effect To Player, GetComponents Gets Actual Components For The Player OR Gambe Object In Question
		ClayMovement jump = player.GetComponent<ClayMovement>();
		speed.movementSpeed *= multiplier;
		jump.jumpForce *= multiplier;

		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		yield return new WaitForSeconds(duration); // Keeps It For X Seconds
		speed.movementSpeed /= multiplier; // Reverses Effect
		jump.jumpForce /= multiplier; // Reverses Effect
		Destroy(gameObject); // Removes Power up from the scene
		
		

	}

}


