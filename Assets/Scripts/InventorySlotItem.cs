using UnityEngine;
using UnityEngine.UI;

public abstract class InventorySlotItem : MonoBehaviour
{
    public string itemText;
    public int amount;
    public Image itemImage;
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

public class HealthPotion : InventorySlotItem
{
    public override void use()
    {
        throw new System.NotImplementedException();
    }
}

/*
 text - str says name
 x1+ - int keeps track
 use - function called when pressing button
 image - img component
 */