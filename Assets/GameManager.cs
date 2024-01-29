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
    public AudioSource terminateSound;
    Animator effectAnim;
    private bool flicking;
    public Animator cameraAnim;
    // Start is called before the first frame update
    void Start()
    {
        flicking = false;
        effectAnim = gameObject.GetComponent<Animator>();
        foreach (Character character in characters)
        {
            character.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
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
        if (curCharacter.gameObject.name == "sweet king")
        {
            effectAnim.SetTrigger("DogFlick");
        }
        else
        {
            effectAnim.SetTrigger("Flick");
        }
    }
    public void Flick()
    {
        if (!flicking)
        {
            if (!curCharacter.CanDie || !curCharacter.smited)
            {

                if (curCharacter.idleSound && curCharacter.idleSound.isPlaying)
                {
                    curCharacter.idleSound.Stop();
                }
                if (curCharacter.flickSound && curCharacter.gameObject.name != "sweet king")
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
            if (curCharacter.idleSound && curCharacter.idleSound.isPlaying)
            {
                curCharacter.idleSound.Stop();
            }
            if (curCharacter.terminateSound)
            {
                curCharacter.terminateSound.Play();
            }
            effectAnim.ResetTrigger("Flick");
            terminateSound.Play();
            curCharacter.anim.SetTrigger("Terminate");
        }
    }

    public void Smite()
    {
        curCharacter.smited = true;
        if (curCharacter.idleSound && curCharacter.idleSound.isPlaying)
        {
            curCharacter.idleSound.Stop();
        }
        smiteSound.Play();
        if(curCharacter.smiteSound)
        {
            curCharacter.smiteSound.Play();
        }
        effectAnim.ResetTrigger("Flick");
        if (curCharacter.gameObject.name != "spinbo scrumpants")
        {
            cameraAnim.SetTrigger("Shake");
        }
        if (curCharacter.gameObject.name == "sweet king")
        {
            var prevScale = curCharacter.gameObject.GetComponent<Transform>().localScale;
            curCharacter.gameObject.GetComponent<Transform>().localScale = new Vector3(prevScale.x * 1.4f, prevScale.y * 1.4f, prevScale.z * 1.4f);
        }
        curCharacter.anim.SetBool("Smite", true);
        curCharacter.anim.SetBool("Idle", false);
    }

    public void NextCharacter()
    {
        if(curCharacter.numForms != 0 && curCharacter.currentForm < curCharacter.numForms)
        {
            curCharacter.currentForm++;
            curCharacter.NextAppearance(curCharacter.currentForm);
        }
        if (curCharacter.idleSound && curCharacter.idleSound.isPlaying)
        {
            curCharacter.idleSound.Stop();
        }
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        index++;
        if (index == characters.Length)
        {
            index = 0;
        }
        curCharacter = characters[index];
        text.text = curCharacter.characterName;
        curCharacter.gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        curCharacter.anim.ResetTrigger("Flick");
        curCharacter.anim.ResetTrigger("Terminate");
        curCharacter.anim.SetBool("Smite", false);
        curCharacter.anim.SetBool("Idle",true);
        curCharacter.smited = false;
        if(curCharacter.idleSound)
        {
            curCharacter.idleSound.Play();
        }
    }

    public void PreviousCharacter()
    {
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        index--;
        if (index == -1)
        {
            index = characters.Length - 1;
        }
        if (curCharacter.idleSound && curCharacter.idleSound.isPlaying)
        {
            curCharacter.idleSound.Stop();
        }
        curCharacter = characters[index];
        text.text = curCharacter.characterName;
        curCharacter.gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        curCharacter.anim.ResetTrigger("Flick");
        curCharacter.anim.ResetTrigger("Terminate");
        curCharacter.anim.SetBool("Smite", false);
        curCharacter.anim.SetBool("Idle", true);
        curCharacter.smited = false;
        if (curCharacter.idleSound)
        {
            curCharacter.idleSound.Play();
        }
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
