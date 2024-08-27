using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour
{

    public Image img;
    public Sprite newSprite;

    public void change() {
        img.sprite = newSprite;
        img.SetNativeSize();
    }
}
