abstract class Character
{
    public string CharacterType { get; }

    protected Character(string characterType)
    {
        CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {CharacterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
            return 10;
        else
            return 6;
    }

    public override bool Vulnerable() => false;
}

class Wizard : Character
{
    private bool spellPrepared;
    
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (spellPrepared)
            return 12;
        else
            return 3;
    }

    public void PrepareSpell()
    {
        spellPrepared = true;
    }

    public override bool Vulnerable() => !spellPrepared;
}
