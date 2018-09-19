using System;
using System.Collections.Generic;
using System.Linq;

// These extensions translate the descriptions (which are in memory representations
// of the sample yaml file) to Digital Twins models.

namespace Microsoft.Azure.DigitalTwins.Samples
{
    public static class DescriptionExtensions
    {
        public static Models.DeviceCreate ToDeviceCreate(this DeviceDescription description, Guid spaceId)
            => new Models.DeviceCreate()
            {
                HardwareId = description.hardwareId,
                Name = description.name,
                SpaceId = spaceId.ToString(),
            };

        public static Models.MatcherCreate ToMatcherCreate(this MatcherDescription description, Guid spaceId)
            => new Models.MatcherCreate()
            {
                Name = description.name,
                SpaceId = spaceId.ToString(),
                Conditions = new [] {
                    new Models.ConditionCreate()
                    {
                        Target = "Sensor",
                        Path = "$.dataType",
                        Value = description.dataTypeValue,
                        Comparison = "Equals",
                    }
                }
            };

        public static Models.ResourceCreate ToResourceCreate(this ResourceDescription description, Guid spaceId)
            => new Models.ResourceCreate()
            {
                SpaceId = spaceId.ToString(),
                Type = description.type,
            };

        public static Models.SensorCreate ToSensorCreate(this SensorDescription description, Guid deviceId)
            => new Models.SensorCreate()
            {
                DataType = description.dataType,
                DeviceId = deviceId.ToString(),
            };

        public static Models.SpaceCreate ToSpaceCreate(this SpaceDescription description, Guid parentId)
            => new Models.SpaceCreate()
            {
                Name = description.name,
                ParentSpaceId = parentId != Guid.Empty ? parentId.ToString() : "",
            };

        public static Models.UserDefinedFunctionCreate ToUserDefinedFunctionCreate(this UserDefinedFunctionDescription description, Guid spaceId, IEnumerable<string> matcherIds)
            => new Models.UserDefinedFunctionCreate()
            {
                Name = description.name,
                SpaceId = spaceId.ToString(),
                Matchers = matcherIds,
            };
    }
}