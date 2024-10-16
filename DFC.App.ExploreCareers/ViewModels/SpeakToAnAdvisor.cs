using System.Collections.Generic;

namespace DFC.App.ExploreCareers.ViewModels
{
    public class Content
    {
        public string Html { get; set; }
    }

    public class SharedContent
    {
        public string DisplayText { get; set; }
        public Content Content { get; set; }
    }

    public class SpeakToAndvisor
    {
        public List<SharedContent> SharedContent { get; set; }
    }

    //public class SpeakToAndvisorResponse
    //{
    //    public SpeakToAndvisor SpeakToAndvisor { get; set; }
    //}

}
