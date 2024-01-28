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
    // Start is called before the first frame update
    void Start()
    {
        curCharacter = characters[0];
        curCharacter.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        text.text = curCharacter.characterName;
        index = 0;
    }

    
    public void Flick()
    {
        if (!curCharacter.CanDie || !curCharacter.smited)
        {
            curCharacter.anim.SetTrigger("Flick");
        }
    }

    public void Terminate()
    {
        if (!curCharacter.CanDie || !curCharacter.smited)
        {
            curCharacter.anim.SetTrigger("Terminate");
        }
    }

    public void Smite()
    {
        curCharacter.smited = true;
        smiteSound.Play();
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

    public void KillOutsideofSmite()
    {
        curCharacter.smited = true;
        
        curCharacter.anim.SetBool("Idle", false);
    }
}
