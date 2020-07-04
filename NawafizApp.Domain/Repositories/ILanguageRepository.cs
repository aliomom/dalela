using NawafizApp.Domain.Entities;
using NawafizApp.Domain.Repositories;

namespace BeautyCenter.Domain.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        //Role FindByName(string roleName);
        //Task<Role> FindByNameAsync(string roleName);
        //Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
        Language GetLanguageByCode(string code);
    }
}
