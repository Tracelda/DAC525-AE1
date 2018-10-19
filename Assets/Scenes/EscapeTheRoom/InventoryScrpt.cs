using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryScrpt : MonoBehaviour {

    public int NumOfInvenSlots;
    public GameObject[] Items;
    public Sprite[] Image;

    // Use this for initialization
    void Start () {
        NumOfInvenSlots = 8;
        Image = new Sprite[NumOfInvenSlots];
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            // Debug to test if if statement works
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

            if (hit && hit.collider.CompareTag("Item")) // Checking tag of hit sprite
            {
                Debug.Log("Item Hit");
                AddItem(hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite);
            }
        }
    }

    public void AddItem(Sprite itemToAdd)
    {
            foreach(GameObject myItem in Items)
            {
            if (myItem.GetComponent<Image>().enabled ||myItem.GetComponent<Image>().sprite != null)
                continue;

            myItem.GetComponent<Image>().enabled = true;
            myItem.GetComponent<Image>().sprite = itemToAdd;
            //myItem.GetComponent<Image>().tag = "InvenItem";
            Debug.Log("Add");
            break;
            }
    }

    public void RemoveItem()
    {
        EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Image>().sprite = null;
    }

}
