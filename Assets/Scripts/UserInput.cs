using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public GameObject slot1;
    private ValueSort valueSort;

    // Start is called before the first frame update
    void Start()
    {
        valueSort = FindObjectOfType<ValueSort>();
        slot1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit)
            {
                if (hit.collider.CompareTag("Deck"))
                {
                    Deck();
                }
                else if (hit.collider.CompareTag("Card"))
                {
                    Card(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Top"))
                {
                    Top();
                }
                else if (hit.collider.CompareTag("Bottom"))
                {
                    Bottom();
                }
            }    
        }
    }

    void Deck()
    {
        print("Clicked on deck");
        valueSort.GetFromDeck();
    }

    void Card(GameObject selected)
    {
        print("Clicked on card");

        if(slot1 == this.gameObject)
        {
            slot1 = selected;
        }
        else if(slot1 != selected)
        {
            slot1 = selected;
        }
    }


    void Top()
    {
        print("Clicked on top");
    }

    void Bottom()
    {
        print("Clicked on bottom");
    }

    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();

        return false;

    }
}
