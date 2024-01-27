using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //each anim has a Idle, Flick, Terminate, and Smite trigger
    public string characterName;
    public Animator anim;
    public bool CanDie;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //anim.SetTrigger("Idle");

    }


}
