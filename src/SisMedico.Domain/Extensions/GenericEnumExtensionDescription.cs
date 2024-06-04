using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SisMedico.Domain.Extensions;

public static class GenericEnumExtensionDescription
{
    public static string ObterDescricao(this Enum _enum)
    {
        var generEnumType = _enum.GetType();
        var memberInfo = generEnumType.GetMember(_enum.ToString());
        if (memberInfo.Length <= 0) return _enum.ToString();

        var attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attribs.Any() ? ((DescriptionAttribute)attribs
            .ElementAt(0)).Description : _enum.ToString();
    }
}

public static class EnumExtensions
{
    public static IEnumerable<SelectListItem> GetSelectList<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum))
                   .Cast<TEnum>()
                   .Select(e => new SelectListItem
                   {
                       Text = e.GetDescription(),
                       Value = e.ToString()
                   });
    }

    public static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        var fi = enumValue.GetType().GetField(enumValue.ToString());

        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return enumValue.ToString();
    }
}
