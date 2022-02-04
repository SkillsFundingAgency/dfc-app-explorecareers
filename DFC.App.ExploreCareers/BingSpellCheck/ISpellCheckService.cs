using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.BingSpellCheck
{
    public interface ISpellCheckService
    {
        Task<SpellCheckResult> CheckSpellingAsync(string term);
    }
}