using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class CustomUserValidator<TUser> : IIdentityValidator<TUser> where TUser : class, Microsoft.AspNet.Identity.IUser
{
    private readonly UserManager<TUser> _userManager;

    public CustomUserValidator(UserManager<TUser> manager)
    {
        _userManager = manager;
    }

    public async Task<IdentityResult> ValidateAsync(TUser user)
    {
        var errors = new List<string>();

        if (_userManager != null)
        {
            //check username availability. and add a custom error message to the returned errors list.
            var existingAccount = await _userManager.FindByNameAsync(user.UserName);

            if (existingAccount != null && existingAccount.Id != user.Id)
                errors.Add("O Nome de Usuário já existe.");
        }

        //set the returned result (pass/fail) which can be read via the Identity Result returned from the CreateUserAsync
        return errors.Any()
            ? IdentityResult.Failed(errors.ToArray())
            : IdentityResult.Success;
    }
}