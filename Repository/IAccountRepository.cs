using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ToDoWebAPI.Models;

namespace ToDoWebAPI.Repository
{
    public interface IAccountRepository
    {
        
            Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
            Task<string> LoginAsync(SignInModel signInModel);
        
    }
}
    