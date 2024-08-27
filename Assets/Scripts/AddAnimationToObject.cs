using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddAnimationToObject : MonoBehaviour
{
    public string spriteName; 

    public Sprite[] animationSheet;

    private Image image;
    private int index = 0;
    private float timer = 0;
    private float duration = 1;


    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = animationSheet[0];
        image.SetNativeSize();
    }
    private void Update()
    {
        if (animationSheet.Length > 0) {
            if((timer+=Time.deltaTime) >= (duration / animationSheet.Length))
            {
                timer = 0;
                image.sprite = animationSheet[index];
                image.SetNativeSize();
                index = (index + 1) % animationSheet.Length;
            }
        }
        
    }
  
}


