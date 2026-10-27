using UnityEngine;

public class HealPotion : InventorySlotItem
{
    public int healAmt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayText.text = "Healing Potion";
        srcImg.sprite = itemImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void use()
        {
            if (checkEnough() == true)
            {
                playerItem = GameState.Instance.PlayerPrefab;
                healAmt = Random.Range(1, 6);
                playerItem.GetComponent<PlayerUnit>().getHealthValue().healHp(healAmt);
                useUp();
            }
            else 
            {
                return;
            }
        }
}


