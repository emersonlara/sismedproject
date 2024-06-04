﻿namespace Cooperchip.ITDeveloper.DomainCore.Validations;

public class Utils
{
    public static string ApenasNumeros(string valor)
    {
        var onlyNumber = "";
        foreach (var s in valor)
        {
            if (char.IsDigit(s))
            {
                onlyNumber += s;
            }
        }
        return onlyNumber.Trim();
    }
}
