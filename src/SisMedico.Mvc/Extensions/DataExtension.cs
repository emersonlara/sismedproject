﻿namespace SisMedico.Mvc.Extensions;

public static class DataExtension
{
    public static string ToBrazilianDate(this DateTime valor)
    {
        return valor.ToString("dd/MM/yyyy");
    }

    public static string ToBrazianDateTime(this DateTime valor)
    {
        return valor.ToString("dd/MM/yyyy HH:mm:ss");
    }

}
