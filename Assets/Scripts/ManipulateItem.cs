using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManipulateItem : MonoBehaviour
{

    public GameObject item; 
    public Image currentlySelected;
    public TMP_Text layerLabel;

    public Image background;
    public Sprite resetBgSprite;

    public GameObject objects;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetItem(GameObject newItem) {
        item = newItem;

        currentlySelected.sprite = item.GetComponent<Image>().sprite;
    }

    // Layers
    public void BringUp() {
        int newOrder = item.GetComponent<Transform>().GetSiblingIndex() + 1;
        item.GetComponent<Transform>().SetSiblingIndex (newOrder);

        layerLabel.text = newOrder.ToString();
    }

    public void BringBack() {
        int newOrder = item.GetComponent<Transform>().GetSiblingIndex() - 1;
        item.GetComponent<Transform>().SetSiblingIndex (newOrder);

        layerLabel.text = newOrder.ToString();
    }

    // Deleting Items

    public void DeleteItem() {
        currentlySelected.sprite = null;
        Destroy(item);
    }

    public void DeleteAll() {
        currentlySelected.sprite = null;

        background.GetComponent<Image>().sprite = resetBgSprite;

        while (transform.childCount > 1) {
            DestroyImmediate(objects.GetComponent<Transform>().GetChild(0).gameObject);
        }

        // set background to delete too
       
    }
    // Flip Manipluation
    public void Flip() {
        float xScale = item.GetComponent<Transform>().localScale.x;
        item.GetComponent<Transform>().localScale = new Vector2(xScale * -1, 0.6f);
    }

    // Move Manipulations
    public void MoveUp() {
        RectTransform position = item.GetComponent<RectTransform>();
        position.anchoredPosition = new Vector2(position.anchoredPosition.x, position.anchoredPosition.y + 2);
    }
    public void MoveDown() {
        RectTransform position = item.GetComponent<RectTransform>();
        position.anchoredPosition = new Vector2(position.anchoredPosition.x, position.anchoredPosition.y - 2);
    }
    public void MoveRight() {
        RectTransform position = item.GetComponent<RectTransform>();
        position.anchoredPosition = new Vector2(position.anchoredPosition.x + 2, position.anchoredPosition.y);
    }
    public void MoveLeft() {
        RectTransform position = item.GetComponent<RectTransform>();
        position.anchoredPosition = new Vector2(position.anchoredPosition.x - 2, position.anchoredPosition.y);
    }
}
