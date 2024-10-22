using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels.JobProfileSector
{
    public class BodyViewModel
    {
        public IList<JobProfileSector> JobProfileSectors { get; set; } = new List<JobProfileSector>();

        public List<SharedContent>? SharedContents { get; set; }
    }
}
