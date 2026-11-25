using JetBrains.Annotations;
using UnityEngine;

public class BuffPotion : InventorySlotItem
{
    public int buffAmt;
    public GameObject playerU;
    public int dmgAmt
    {
        get { return playerU.GetComponent<PlayerUnit>().damageAmount; }
        set { playerU.GetComponent<PlayerUnit>().damageAmount = value; }
    }

    void Start()
    {
        displayText.text = "Damage Potion - " + amount.ToString();
        srcImg.sprite = itemImage;
        playerU = GameObject.FindWithTag("Player");
    }

    public int CalculatePercent(int dmg)
    {
        int percent = (int)System.MathF.Ceiling(dmg * 0.2F);
        return percent; 
    }

    public override void use()
    {
        Debug.Log("Dmg amount: " + dmgAmt);
        if (checkEnough() == true)
        {
            int buffPercent = CalculatePercent(dmgAmt);
            buffAmt = (int)System.MathF.Ceiling(dmgAmt + buffPercent);
            playerU.GetComponent<PlayerUnit>().isDmgModified = true;
            playerU.GetComponent<PlayerUnit>().BuffDamage = buffAmt;
            Debug.Log("Amount dealing: " + playerU.GetComponent<PlayerUnit>().BuffDamage);
            useUp();
            Debug.Log("Amount Left: " + amount.ToString());
        }
        else
        {
            return;
        }
    }
}

