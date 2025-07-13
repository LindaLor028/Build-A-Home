using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;


public class ManipulateItem : MonoBehaviour
{

    public GameObject item; 
    public Image currentlySelected;
    public TMP_Text layerLabel;

    public Image background;
    public Sprite resetBgSprite;

    public GameObject objects;

    public TMP_InputField updateLayerText;

    public GameObject deleteAllPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetItem(GameObject newItem)
    {
        item = newItem;

        currentlySelected.sprite = item.GetComponent<Image>().sprite;
        int newOrder = item.GetComponent<Transform>().GetSiblingIndex();
        layerLabel.text = newOrder.ToString();
    }

    // Layers
    public void BringUp() {
        int newOrder = item.GetComponent<Transform>().GetSiblingIndex() + 1;
        item.GetComponent<Transform>().SetSiblingIndex (newOrder);
        Debug.Log("Bringing Up To: " +newOrder);
        layerLabel.text = newOrder.ToString();
    }

    public void BringBack() {
        int newOrder = item.GetComponent<Transform>().GetSiblingIndex() - 1;
        item.GetComponent<Transform>().SetSiblingIndex (newOrder);
        Debug.Log("Bringing Back To: " + newOrder);
        layerLabel.text = newOrder.ToString();
    }

    public void UpdateLayer()
    {
        if (Regex.IsMatch(updateLayerText.text, @"^\d+$"))
        { 
            int newOrder = int.Parse(updateLayerText.text);
            item.GetComponent<Transform>().SetSiblingIndex (newOrder);
        }
        updateLayerText.text = "";
    }

    // Deleting Items

    public void DeleteItem()
    {
        currentlySelected.sprite = null;
        Destroy(item);
    }

    public void DeleteAll() {
        currentlySelected.sprite = null;

        background.GetComponent<Image>().sprite = resetBgSprite;
        deleteAllPanel.SetActive(false);
        
        while (objects.GetComponent<Transform>().childCount > 0)
        {
            DestroyImmediate(objects.GetComponent<Transform>().GetChild(0).gameObject);
        }
        
        // set background to delete too
       
    }

    public void CheckDeleteAll()
    {
        deleteAllPanel.SetActive(true);
    }

    public void UndoDeleteAll()
    {
        deleteAllPanel.SetActive(false);
    }

    // Flip Manipluation
    public void Flip()
    {
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
