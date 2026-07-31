// TODO: define the 'AccountType' enum
public enum AccountType
{
    Guest,
    User,
    Moderator
}

// TODO: define the 'Permission' enum
[Flags]
public enum Permission : byte
{
    None   = 0,
    Read   = 1,
    Write  = 2,
    Delete = 4,
    All    = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        if (accountType == AccountType.Guest)
            return Permission.Read;

        if (accountType == AccountType.User)
            return Permission.Read | Permission.Write;

        if (accountType == AccountType.Moderator)
            return Permission.All;

        return Permission.None;
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;

    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);

    }
}
