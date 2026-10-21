using UnityEngine;
using UnityEngine.UI;

public abstract class InventorySlotItem : MonoBehaviour
{
    [SerializeField] public string itemText;
    [SerializeField] public string description;
    public int amount;
    [SerializeField] public Sprite itemImage;
    public GameObject playerItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void use();
}

/*
 text - str says name
 x1+ - int keeps track
 use - function called when pressing button
 image - img component
 */

//HW - find where to update count of an item, check if you have eough to use
//both can be checked in same place