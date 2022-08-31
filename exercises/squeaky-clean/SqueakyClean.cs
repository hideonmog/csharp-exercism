using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder(identifier);
        // replace spaces with underscore
        sb.Replace(' ', '_');
        // replace control characters with CTRL
        for (int i = 0; i < sb.Length; i++)
        {
            if (Char.IsControl(sb[i]))
            {
                sb.Replace(sb[i].ToString(), "CTRL");
            }
        }
        // convert kebab to camel case
        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] == '-'){
                if (i + 1 < sb.Length){
                    sb[i + 1] = Char.ToUpper(sb[i + 1]);
                }
                sb.Remove(i, 1);
            }
        }
        // remove characters that are not letters
        for (int i = 0; i < sb.Length;)
        {
            if (Char.IsLetter(sb[i]) || sb[i] == '_')
            {
                i++;
            }
            else
            {
                sb.Remove(i, 1);
            }
        }
        // remove lower case greek letters
        int alpha = 0x03B1;
        int omega = 0x03C9;
        for (int i = 0; i < sb.Length;)
        {
            int iC = (int)sb[i];
            if (iC >= alpha && iC <= omega)
            {
                sb.Replace(sb[i].ToString(), String.Empty);
            }
            else
            {
                i++;
            }
        }
        return sb.ToString();
    }
}
