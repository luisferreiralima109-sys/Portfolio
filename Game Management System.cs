public enum ItemRarity
{
    Common,
    Rare,
    Epic,
    Legendary
}

public abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ItemRarity Rarity { get; set; }
    public int Value { get; set; }

    protected Item(string name, ItemRarity rarity, int value)
    {
        Name = name;
        Rarity = rarity;
        Value = value;
    }

    public abstract void Use(Character character);
}

public class Weapon : Item
{
    public int Damage { get; set; }

    public Weapon(string name, int damage, ItemRarity rarity)
        : base(name, rarity, 100)
    {
        Damage = damage;
    }

    public override void Use(Character character)
    {
        character.EquipWeapon(this);
    }
}

public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public Weapon? EquippedWeapon { get; private set; }

    public Character(string name)
    {
        Name = name;
        Health = 100;
        Level = 1;
    }

    public void EquipWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
    }

    public int CalculateDamage()
    {
        return EquippedWeapon?.Damage ?? 5;
    }
}