using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float dashSpeed, dashLength = 0.5f, dashCooldown = 1f;
	
	private float activeMoveSpeed;
	private float dashCounter, dashCoolCounter;
	
	private Rigidbody2D rb;
	private Vector2 moveInput; 

	private void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	private void Start() {	
		activeMoveSpeed = moveSpeed;	
	}

	private void Update () {		
		// Inputs
		Move();
		Dash();
	}	

	private void FixedUpdate() {
	}	
	
	private void Move()	{				
		moveInput.x = Input.GetAxisRaw("Horizontal");
		moveInput.y = Input.GetAxisRaw("Vertical");		
		moveInput.Normalize();
		rb.velocity = moveInput * activeMoveSpeed;
	}
	
	private void Dash()	{
		if (Input.GetButton("Fire1")) {
			if (dashCoolCounter <= 0 && dashCounter <= 0) {
				activeMoveSpeed = dashSpeed;
				dashCounter = dashLength;
			}
		}
		if (dashCounter > 0)	{
			dashCounter -= Time.deltaTime;
			if(dashCounter <= 0) {
				activeMoveSpeed = moveSpeed;
				dashCoolCounter = dashCooldown;
			}
		}
		if (dashCoolCounter > 0) { 
			dashCoolCounter -= Time.deltaTime;
		}
	}
}
