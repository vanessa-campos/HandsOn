using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float moveSpeed, dashSpeed;
	[SerializeField] private LayerMask dashLayerMask;
	private bool isdashing;
	
	private Rigidbody2D rb;
	private Vector3 moveDir; 
	// private PlayerAnimator playerAnim;

	private void Awake(){
		rb = GetComponent<Rigidbody2D>();
		// playerAnim = GetComponent<PlayerAnimator>();
	}

	private void Update () {		
		
		// Inputs
		Move();
		Dash();
	}	

	private void FixedUpdate() {
		
		// Move
		rb.velocity = moveDir * moveSpeed;
		// Dash
		if(isdashing) {	
			Vector3 dashPos = transform.position + moveDir * dashSpeed;
			RaycastHit2D ray = Physics2D.Raycast(transform.position, moveDir, dashSpeed, dashLayerMask);
			if(ray.collider != null){ 
				dashPos = ray.point;
			}
			rb.MovePosition(dashPos);
			isdashing = false;		
		}
	}	
	
	private void Move()	{				
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");		
		moveDir = new Vector3(moveX, moveY).normalized;	
		// playerAnim.PlayMoveAnim(moveDir);
	}
	
	private void Dash()	{
		if (Input.GetButton("Fire1")) {
			isdashing = true;
		}
	}
}
