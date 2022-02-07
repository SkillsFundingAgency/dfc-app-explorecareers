namespace DFC.App.ExploreCareers.BingSpellCheck
{
    public class SpellCheckResult
    {
        public string OriginalTerm { get; set; } = string.Empty;

        public string CorrectedTerm { get; set; } = string.Empty;

        public bool HasCorrected { get; set; }
    }
}
