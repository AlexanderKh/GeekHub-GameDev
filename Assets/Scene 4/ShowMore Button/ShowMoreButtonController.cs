using UnityEngine;
using System.Collections;

public class ShowMoreButtonController : MonoBehaviour
{
    private Animator animator;

    public void Start () 
    {
        animator = GetComponent<Animator> ();
    }

    public void Highlighted()
    {
        print("hh");
        animator.SetBool ("Highlighted", true);
    }

    public void Unhighlighted()
    {
        print("uuhh");
        animator.SetBool ("Highlighted", false);
    }
}
