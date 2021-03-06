﻿using AdfToArm.Core.Models.LinkedServices.LinkedServiceTypeProperties;
using Newtonsoft.Json;

namespace AdfToArm.Core.Models.LinkedServices
{
    [JsonObject]
    public class AzureDataLakeStore : LinkedService
    {
        public AzureDataLakeStore()
        {
            Properties = new LinkedServiceProperties
            {
                Type = LinkedServiceType.AzureDataLakeStore,
                TypeProperties = new AzureDataLakeStoreTypeProperties()
            };
        }

        public AzureDataLakeStore(string name) : this()
        {
            Name = name;
        }
    }
}
