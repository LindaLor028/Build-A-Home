using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectManager : MonoBehaviour
{

    public GameObject prefab;
    public GameObject animatedPrefab;
    public Canvas objCanvas;

    public GameObject spawn;

    public AnimationList aList;

    public ManipulateItem manipulator;

    public void GenerateObject(Sprite newSprite) {
        GameObject obj = Instantiate(prefab, spawn.GetComponent<Transform>().position, Quaternion.identity, this.transform);
        obj.GetComponent<DraggableWindowScript>().canvas = objCanvas;
        obj.GetComponent<ObjectButtonDetection>().manipulate = manipulator;

        obj.GetComponent<Image>().sprite = newSprite;
        obj.GetComponent<Image>().SetNativeSize();

        manipulator.SetItem(obj);
    }

    public void GeneratedAnimatedObject(string objectName) {
        GameObject obj = Instantiate(animatedPrefab, spawn.GetComponent<Transform>().position, Quaternion.identity, this.transform);
        obj.GetComponent<DraggableWindowScript>().canvas = objCanvas;
        obj.GetComponent<ObjectButtonDetection>().manipulate = manipulator;
        obj.GetComponent<AddAnimationToObject>().animationSheet = aList.GetAnimationSheet(objectName);

        manipulator.SetItem(obj);
    }
}
