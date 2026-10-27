using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventorySlotItem : MonoBehaviour
{
    [SerializeField] public string itemText;
    [SerializeField] public string description;
    public int amount;
    [SerializeField] public Sprite itemImage;
    [SerializeField] public Image srcImg;
    [SerializeField] public TextMeshProUGUI displayText;
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

    public void useUp()
    {
        if (amount > 0)
        {
            amount--;
        }  
    }
    public bool checkEnough()
    {
        if (amount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

/*
 text - str says name
 x1+ - int keeps track
 use - function called when pressing button
 image - img component
 */