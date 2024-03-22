using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    public Sprite itemSprite;
    public GameObject itemPrefab;
    public string[] dialogueStrings;
}
