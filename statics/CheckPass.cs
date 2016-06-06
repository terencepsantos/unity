
public static class CheckPass
{
    public static bool Check(string pass, int minLength)
    {
        //Checks the length of the password string
        if (pass.Length < minLength)
            return false;

        //Checks if there's at least one letter
        for (int i = 0; i < pass.Length; i++)
        {
            if (System.Char.IsLetter(pass[i]))
                break;

            if (i == pass.Length - 1)
                return false;
        }

        //Checks if there's at least one number
        for (int i = 0; i < pass.Length; i++)
        {
            if (System.Char.IsNumber(pass[i]))
                break;

            if (i == pass.Length - 1)
                return false;
        }

        return true;
    }
}
