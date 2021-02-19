using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
	float second = 0;
	public float playSecond = 4.5f;
	Transform playerTr;
	
	private void Start()
	{
		StartCoroutine("Move");
		playerTr = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	IEnumerator Move()
	{
		while (second < playSecond)
		{
			transform.Translate(Vector3.forward * Time.deltaTime);
			second += Time.deltaTime;
			
			yield return null;
		}
		StartCoroutine("LookPlayer");
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Action();

		StopCoroutine("Move");
	}

	IEnumerator LookPlayer()
	{
		while (true)
		{
			Vector3 targetPostition = new Vector3(playerTr.position.x, this.transform.position.y, playerTr.position.z);
			transform.LookAt(targetPostition);
			yield return null;
		}
	}
}


