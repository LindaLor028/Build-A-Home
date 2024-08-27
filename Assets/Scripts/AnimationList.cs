using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AnimationList : MonoBehaviour
{
    public Sprite[] ppl_01, ppl_02, ppl_04, ppl_07, ppl_08, ppl_10, ppl_11, ppl_12, ppl_13, ppl_14, ppl_15, ppl_16, ppl_17, ppl_18, ppl_23, ppl_24, ppl_25;
    public Sprite[] pet_02, pet_03, pet_04, pet_05, pet_06, pet_07, pet_08;
    public Sprite [] pool_06, pool_09;
    private Sprite[][] peopleAnimations, petAnimations, poolAnimations;

    public void Start() {
        peopleAnimations = new Sprite[17][] {ppl_01, ppl_02, ppl_04, ppl_07, ppl_08, ppl_10, ppl_11, ppl_12, ppl_13, ppl_14, ppl_15, ppl_16, ppl_17, ppl_18,ppl_23, ppl_24, ppl_25};
        petAnimations = new Sprite[7][] {pet_02, pet_03, pet_04, pet_05, pet_06, pet_07, pet_08};
        poolAnimations = new Sprite[2][] {pool_06, pool_09};
    }


    public Sprite[] GetAnimationSheet(string name) {
        if (name.Contains("people")) {
            return SortThroughArray(name, peopleAnimations);
        }
        else if (name.Contains("pet")) {
            return SortThroughArray(name, petAnimations);
        }

        else {
            return SortThroughArray(name, poolAnimations);
        }

    }

    private Sprite[] SortThroughArray(string name, Sprite[][] array) {
        int index = 0; 

        for (int i = 0; i <= array.Length; i++) {

            Sprite[] currentArray = (Sprite[]) array.GetValue(i);
            Sprite currentSprite = (Sprite) currentArray.GetValue(0);
            string currentStr = currentSprite.name;
            Debug.Log(currentStr);

            if (currentStr.Contains(name)) {
                index = i;
                return currentArray;
            }
        }
        return ppl_01;
    }
}
