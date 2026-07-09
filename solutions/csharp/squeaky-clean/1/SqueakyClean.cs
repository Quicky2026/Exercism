public static class Identifier
{
    public static string Clean(string identifier)
    {
        string result = identifier;
    
        // Taak 1
        if (!string.IsNullOrWhiteSpace(result))
        {
            result = result.Replace(" ", "_");
        }
        //result = result.Replace(" ", "_");
    
        // Taak 2
        string ctrlFixed = "";
        foreach (var c in result)
        {
            if (Char.IsControl(c))
                ctrlFixed += "CTRL";
            else
                ctrlFixed += c;
        }
        result = ctrlFixed;
    
        // Taak 3
        string camel = "";
        bool capitalizeNext = false;
        
        foreach (var c in result)
        {
            if (c == '-')
            {
                capitalizeNext = true;
                continue;
            }
        
            if (capitalizeNext)
            {
                camel += char.ToUpper(c);
                capitalizeNext = false;
            }
            else
            {
                camel += c;
            }
        }
        
        result = camel;

        // Taak 4
        string omitted = "";
        foreach (var c in result)
        {
            if (char.IsLetter(c) == true || c == '_')
            {
                omitted += c;
            }
            else
            {
                continue;
            }
        }
        result = omitted;
        
        // Taak 5
        string greekLowercase = "αβγδεζηθικλμνξοπρστυφχψω";
        string withoutGreek = "";
        
        foreach (var c in result)
        {
            if (!greekLowercase.Contains(c))
            {
                withoutGreek += c;
            }
        }
        
        result = withoutGreek;

    return result;
}
}
