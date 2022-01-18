using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.ExploreCareers.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class IndexViewModel
    {
        public string? Path { get; set; }

        public List<IndexDocumentViewModel>? Documents { get; set; }
    }
}
