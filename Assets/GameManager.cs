using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character[] characters;
    private Character curCharacter;
    private int index;
    public Text text;
    public AudioSource smiteSound;
    public AudioSource flickSound;
    Animator effectAnim;
    private bool flicking;
    // Start is called before the first frame update
    void Start()
    {
        flicking = false;
        effectAnim = gameObject.GetComponent<Animator>();
        curCharacter = characters[0];
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        text.text = curCharacter.characterName;
        index = 0;
    }

    public void PlayFlickAnim()
    {
        if(!curCharacter.waitForFlick)
        {
            
            Flick();
            flicking = true;

        }
        effectAnim.SetTrigger("Flick");
    }
    public void Flick()
    {
        if (!flicking)
        {
            if (!curCharacter.CanDie || !curCharacter.smited)
            {
                if (curCharacter.flickSound)
                {
                    curCharacter.flickSound.Play();
                }
                curCharacter.anim.SetTrigger("Flick");
            }
        }
    }

    public void Terminate()
    {
        if (!curCharacter.CanDie || !curCharacter.smited)
        {
            if (curCharacter.terminateSound.clip != null)
            {
                curCharacter.terminateSound.Play();
            }
            curCharacter.anim.SetTrigger("Terminate");
        }
    }

    public void Smite()
    {
        curCharacter.smited = true;
        smiteSound.Play();
        if(curCharacter.smiteSound.clip!=null)
        {
            curCharacter.smiteSound.Play();
        }
        curCharacter.anim.SetBool("Smite", true);
        curCharacter.anim.SetBool("Idle", false);
    }

    public void NextCharacter()
    {
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        index++;
        if (index == characters.Length)
        {
            index = 0;
        }
        curCharacter = characters[index];
        text.text = curCharacter.characterName;
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        curCharacter.anim.ResetTrigger("Flick");
        curCharacter.anim.ResetTrigger("Terminate");
        curCharacter.anim.SetBool("Smite", false);
        curCharacter.anim.SetBool("Idle",true);
        curCharacter.smited = false;
    }

    public void PreviousCharacter()
    {
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        index--;
        if (index == -1)
        {
            index = characters.Length - 1;
        }
        curCharacter = characters[index];
        text.text = curCharacter.characterName;
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        curCharacter.anim.ResetTrigger("Flick");
        curCharacter.anim.ResetTrigger("Terminate");
        curCharacter.anim.SetBool("Smite", false);
        curCharacter.anim.SetBool("Idle", true);
        curCharacter.smited = false;
    }
    public void PlayFlickSound()
    {
        flickSound.Play();
    }

    public void EndFlick()
    {
        flicking = false;
    }
    
}
