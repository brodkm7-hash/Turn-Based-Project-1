using UnityEngine;

public class BuffPotion : InventorySlotItem
{
    public int buffAmt;
    public PlayerUnit playerU;
    public int dmgAmt
    {
        get { return playerU.damageAmount; }
        set { playerU.damageAmount = value; }
    }

    void Start()
    {
        displayText.text = "Damage Potion - " + amount.ToString();
        srcImg.sprite = itemImage;
    }

    public override void use()
    {
        if (checkEnough() == true)
        {
            
        }
        else
        {
            return;
        }
    }
}
