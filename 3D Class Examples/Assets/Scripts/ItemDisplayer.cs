using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayer : MonoBehaviour
{
    public Image image;
    public ItemSO itemSO;

    // Start is called before the first frame update
    void Start()
    {
        image.sprite = itemSO.itemSprite;
    }

}
