﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private ValueSort valueSort;
    private UserInput userInput;


    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = ValueSort.GenerateDeck();
        valueSort = FindObjectOfType<ValueSort>();
        userInput = FindObjectOfType<UserInput>();

        int i = 0;
        foreach(string card in deck)
        {
            if(this.name == card)
            {
                cardFace = valueSort.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }


        if(userInput.slot1)
        { 
            if (name == userInput.slot1.name)
            {
                spriteRenderer.color = Color.gray;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
        }
    }
}
