using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public enum CharaterState {Idel, Typing, Greet, Give, Onemore, Walk, Check}
    
    public CharaterState state = CharaterState.Idel;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SetCharacterAnim());
    }
    
    IEnumerator SetCharacterAnim()
    {
        while (true)
        {
            switch (state)
            {
                case CharaterState.Idel:
                    animator.SetBool("isTyping", false);
                    animator.SetBool("isGreet", false);
                    animator.SetBool("isGive", false);
                    animator.SetBool("isOnemore", false);
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isCheck", false);
                    break;

                case CharaterState.Typing:
                    animator.SetBool("isTyping", true);
                    animator.SetBool("isGreet", false);
                    animator.SetBool("isGive", false);
                    animator.SetBool("isWalk", false);
                    break;

                case CharaterState.Greet:
                    animator.SetBool("isGreet", true);
                    animator.SetBool("isTyping", false);
                    animator.SetBool("isGive", false);
                    animator.SetBool("isWalk", false);
                    break;

                case CharaterState.Give:
                    animator.SetBool("isGive", true);
                    animator.SetBool("isGreet", false);
                    animator.SetBool("isTyping", false);
                    animator.SetBool("isWalk", false);
                    break;

                case CharaterState.Onemore:
                    animator.SetBool("isOnemore", true);
                    break;

                case CharaterState.Walk:
                    animator.SetBool("isWalk", true);
                    break;

                case CharaterState.Check:
                    animator.SetBool("isCheck", true);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void SetCharaterState(CharaterState charaterState)
    {
        this.state = charaterState;
    }

    public IEnumerator SetOneMoreState(CharaterState state)
	{
        yield return new WaitForSeconds(0.5f);
        this.state = state;
    }
}
