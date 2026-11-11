using JetBrains.Annotations;
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

    public int CalculatePercent(int dmg)
    {
        public int percent = (int)System.MathF.Ceiling(dmg * 0.2);
        return percent;
    }

    public override void use()
    {
        if (checkEnough() == true)
        {
            CalculatePercent(dmgAmt);
            buffAmt = (int)System.MathF.Ceiling(dmgAmt + percent);
            playerU.isDmgModified = true;
            useUp();
        }
        else
        {
            return;
        }
    }
}

