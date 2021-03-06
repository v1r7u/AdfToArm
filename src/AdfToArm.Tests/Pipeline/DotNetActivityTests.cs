﻿using AdfToArm.Core;
using AdfToArm.Core.Models;
using AdfToArm.Core.Models.Pipelines;
using AdfToArm.Core.Models.Pipelines.ActivityProperties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace AdfToArm.Tests.Dataset
{
    [TestClass]
    public class DotNetActivityTests
    {
        private const string FullFilePath = @"./samples/pipelines/activity_dotnet_full.json";
        private const string MinFilePath = @"./samples/pipelines/activity_dotnet_min.json";

        [TestMethod]
        public void AdfItemType_ShouldBe_Pipeline()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);

            // Assert
            result.type.ShouldBe(AdfItemType.Pipeline);
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_AllProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(FullFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.DotNetActivity);
            activity.Inputs.ShouldNotBeEmpty();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<DotNetActivityTypeProperties>();
            props.AssemblyName.ShouldNotBeNullOrWhiteSpace();
            props.EntryPoint.ShouldNotBeNullOrWhiteSpace();
            props.PackageLinkedService.ShouldNotBeNullOrWhiteSpace();
            props.PackageFile.ShouldNotBeNullOrWhiteSpace();

            props.ExtendedProperties.ShouldNotBeEmpty();

            foreach (var param in props.ExtendedProperties)
            {
                param.Key.ShouldNotBeNullOrWhiteSpace();
                param.Value.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void AdfSerializer_ShouldParse_MinSetOfProperties()
        {
            // Arrange
            // Act
            var result = AdfSerializer.Deserialize(MinFilePath);
            var activity = (result.value as Pipeline).Properties.Activities[0];

            // Assert
            activity.Name.ShouldNotBeNullOrWhiteSpace();
            activity.Type.ShouldBe(ActivityType.DotNetActivity);
            activity.Inputs.ShouldBeNull();
            activity.Outputs.ShouldNotBeEmpty();
            activity.LinkedServiceName.ShouldNotBeNullOrWhiteSpace();

            var props = activity.TypeProperties.ShouldBeAssignableTo<DotNetActivityTypeProperties>();
            props.AssemblyName.ShouldNotBeNullOrWhiteSpace();
            props.EntryPoint.ShouldNotBeNullOrWhiteSpace();
            props.PackageLinkedService.ShouldNotBeNullOrWhiteSpace();
            props.PackageFile.ShouldNotBeNullOrWhiteSpace();
            props.ExtendedProperties.ShouldBeNull();
        }
    }
}
