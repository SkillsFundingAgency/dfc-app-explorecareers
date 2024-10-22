using System;
using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.SectorLandingPage
{
    public class BodyViewModel
    {
        public IList<SectorLandingPage>? SectorLandingPage { get; set; } = new List<SectorLandingPage>();
        public List<SharedContent>? SharedContents { get; set; } = new List<SharedContent>();
    }
}
