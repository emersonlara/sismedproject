﻿
using SisMedico.Mvc.Extensions.Filters;

namespace SisMedico.Mvc.Configuration;

public static class MvcAndRazorConfig
{
    public static IServiceCollection AddMvcAndRazor(this IServiceCollection services)
    {

        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(AuditoriaIloggerFilter));
            // Todo: add >> AutoValidateAntiforgeryTokenAttribute
            options.Filters.Add(typeof(AutoValidateAntiforgeryTokenAttribute));

        });

        services.AddControllersWithViews(o =>
        {
            o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor preenchido é inválido para este campo.");
            o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "Este campo precisa ser preenchido.");
            o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Este campo precisa ser preenchido.");
            o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "É necessário que o body na requisição não esteja vazio.");
            o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => "O valor preenchido é inválido para este campo.");
            o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor preenchido é inválido para este campo.");
            o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser numérico");
            o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(x => "O valor preenchido é inválido para este campo.");
            o.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "O valor preenchido é inválido para este campo.");
            o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo deve ser numérico.");
            o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Este campo precisa ser preenchido.");

            o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        }).AddJsonOptions(opt => {
            opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            opt.JsonSerializerOptions.PropertyNamingPolicy = null;
        }).AddRazorRuntimeCompilation();

        services.AddRazorPages();

        return services;
    }
}
