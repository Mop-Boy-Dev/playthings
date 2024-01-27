using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character[] characters;
    private Character curCharacter;
    private bool smited;
    private int index;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        smited = false;
        curCharacter = characters[0];
        curCharacter.gameObject.SetActive(true);
        text.text = curCharacter.characterName;
        index = 0;
    }

    
    public void Flick()
    {
        if (!curCharacter.CanDie || !smited)
        {
            curCharacter.anim.SetTrigger("Flick");
        }
    }

    public void Terminate()
    {
        if (!curCharacter.CanDie || !smited)
        {
            curCharacter.anim.SetTrigger("Terminate");
        }
    }

    public void Smite()
    {
        smited = true;
        curCharacter.anim.SetTrigger("Smite");
    }

    public void NextCharacter()
    {
        curCharacter.gameObject.SetActive(false);
        index++;
        if (index == characters.Length)
        {
            index = 0;
        }
        curCharacter = characters[index];
        text.text = curCharacter.characterName;
        curCharacter.gameObject.SetActive(true);
        curCharacter.anim.SetTrigger("Idle");
        smited = false;
    }

    public void PreviousCharacter()
    {
        curCharacter.gameObject.SetActive(false);
        index--;
        if (index == -1)
        {
            index = characters.Length - 1;
        }
        curCharacter = characters[index];
        text.text = curCharacter.characterName;
        curCharacter.gameObject.SetActive(true);
        curCharacter.anim.SetTrigger("Idle");
        smited = false;
    }
}
