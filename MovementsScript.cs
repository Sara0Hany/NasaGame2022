using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsScript : MonoBehaviour
{
	private Animator anim;
	//private CharacterController controller;

	public float speed = 600.0f;
	public float turnSpeed = 400.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	GameObject gameObjectToMove;
	public void MoveGameObject()
	{
		gameObjectToMove.transform.position = new Vector3(0, 1, -30);
	}
	void Start()
	{
		//controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if (Input.GetKey("w"))
		{
			anim.SetBool("Move", true);
		}
		else
		{
			anim.SetBool("Move", false);
		}

		/*if (controller.isGrounded)
		{
			moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
		}*/

		float turn = Input.GetAxis("Horizontal");
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		//controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}
}

