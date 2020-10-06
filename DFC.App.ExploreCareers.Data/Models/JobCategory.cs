using DFC.Compui.Cosmos.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace DFC.App.ExploreCareers.Data.Models
{
    [ExcludeFromCodeCoverage]
    public class JobCategory : DocumentModel, IDocumentModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string? Etag { get; set; }

        public override string? PartitionKey
        {
            get => "jobcategory";
            set => value = "jobcategory";
        }

        public string Html { get; set; }
        
        public Guid? Version { get; set; }

        public void AddParentId(string parentId)
        {
        }

        public void AddTraceId(string traceId)
        {
        }

        public string? TraceId { get; }

        public string? ParentId { get; }
    }
}
