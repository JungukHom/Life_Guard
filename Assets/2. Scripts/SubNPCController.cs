using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNPCController : MonoBehaviour
{
    public enum CharaterState {Idel, Hit}
    public CharaterState state = CharaterState.Idel;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SetHitAnim());
    }
    
    IEnumerator SetHitAnim()
    {
        while (true)
        {
            switch (state)
            {
                case CharaterState.Idel:
                    animator.SetBool("isHit", false);
                    break;
                case CharaterState.Hit:
                    animator.SetBool("isHit", true);
                    StartCoroutine(SetState(CharaterState.Idel));
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator SetState(CharaterState state)
	{
        yield return new WaitForSeconds(1f);
        this.state = state;
    }
	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "GrabableObject")
		{
            state = CharaterState.Hit;
		}
	}
}
