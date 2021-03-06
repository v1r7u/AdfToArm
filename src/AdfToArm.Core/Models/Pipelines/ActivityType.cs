﻿using System.Runtime.Serialization;

namespace AdfToArm.Core.Models.Pipelines
{
    public enum ActivityType
    {
        [EnumMember(Value = "Copy")]
        Copy,
        [EnumMember(Value = "SqlServerStoredProcedure")]
        SqlServerStoredProcedure,
        [EnumMember(Value = "HDInsightSpark")]
        HDInsightSpark,
        [EnumMember(Value = "HDInsightHive")]
        HDInsightHive,
        [EnumMember(Value = "HDInsightPig")]
        HDInsightPig,
        [EnumMember(Value = "HDInsightMapReduce")]
        HDInsightMapReduce,
        [EnumMember(Value = "HDInsightStreaming")]
        HDInsightStreaming,
        [EnumMember(Value = "DataLakeAnalyticsU-SQL")]
        DataLakeAnalyticsUSQL,
        [EnumMember(Value = "DotNetActivity")]
        DotNetActivity,
        [EnumMember(Value = "AzureMLBatchExecution")]
        AzureMLBatchExecution
    }
}
