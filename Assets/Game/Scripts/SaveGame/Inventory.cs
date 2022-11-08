
public class Inventory
{
    public int CurrentInventory { get; private set; } = 0;
    public int MaxInventory { get; } = 10;
    public int HealPotion { get; private set; } = 0;
    public int InventoryCount { get; private set; } = 0;


    private Inventory() { }
    private static Inventory instance;
    public static Inventory Instance
    {
        get
        {
            if (instance == null) instance = new Inventory();
            return instance;
        }
    }


    public void InventoryPlusCounter()
    {
        ++InventoryCount;
    }


    public void InventoryMinusCounter()
    {
        --InventoryCount;
    }


    public void AddHealPotionToInventory()
    {
        ++HealPotion;
        InventoryPlusCounter();
    }


    public void RemoveHealPotionFromInventory()
    {
        --HealPotion;
        InventoryMinusCounter();
    }
}
