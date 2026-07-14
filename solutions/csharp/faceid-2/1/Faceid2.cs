public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object? obj)
    {
        if (obj is FacialFeatures other)
        {
            return EyeColor == other.EyeColor &&
                   PhiltrumWidth == other.PhiltrumWidth;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object? obj)
    {
        if (obj is Identity other)
        {
            return Email == other.Email &&
                   this.FacialFeatures.Equals(other.FacialFeatures);
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private HashSet<Identity> registered = new HashSet<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        Identity admin = new Identity(
            "admin@exerc.ism",
            new FacialFeatures("green", 0.9m)
        );
    
        return identity.Equals(admin);
    }

    public bool Register(Identity identity)
    {
        // Add() geeft true als het nieuw is, false als het al bestond
        return registered.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        // Contains() gebruikt jouw Equals() → perfect
        return registered.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
    }
}
