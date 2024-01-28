using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //each anim has a Idle, Flick, Terminate, and Smite trigger
    public string characterName;
    public Animator anim;
    public bool CanDie;
    public bool smited;
    public AudioSource flickSound;
    public AudioSource terminateSound;
    public AudioSource smiteSound;
    public bool waitForFlick;
    public int numForms;
    public int currentForm;
    // Start is called before the first frame update
    void Start()
    {
        smited = false;
        anim = gameObject.GetComponent<Animator>();
        //anim.SetTrigger("Idle");

    }

    public void KillOutsideofSmite()
    {
        smited = true;

        anim.SetBool("Idle", false);
    }

    virtual public void NextAppearance(int num)
    {

    }

}
