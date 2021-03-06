﻿using System;
using System.IO;
using log4net.Core;
using log4net.Layout;
using Microsoft.WindowsAzure.Storage.Table;

namespace log4net.Appender.AzureAsync
{
    internal sealed class AzureLayoutLoggingEventEntity : TableEntity
    {
        public AzureLayoutLoggingEventEntity(LoggingEvent e, PartitionKeyTypeEnum partitionKeyType, ILayout layout)
        {
            Level = e.Level.ToString();
            Message = e.RenderedMessage + Environment.NewLine + e.GetExceptionString();
            ThreadName = e.ThreadName;
            EventTimeStamp = e.TimeStamp;
            using (var w = new StringWriter())
            {
                layout.Format(w, e);
                Message = w.ToString();
            }

            PartitionKey = e.MakePartitionKey(partitionKeyType);
            RowKey = e.MakeRowKey();
            LoggerName = e.LoggerName;
            SequenceNumber = 0;
        }

        public AzureLayoutLoggingEventEntity(LoggingEvent e, PartitionKeyTypeEnum partitionKeyType, ILayout layout, string message, int sequenceNumber) : this(e, partitionKeyType, layout)
        {
            Message = message;
            SequenceNumber = sequenceNumber;
        }

        public DateTime EventTimeStamp { get; set; }

        public string ThreadName { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public string LoggerName { get; set; }

        public int SequenceNumber { get; set; }
    }
}
