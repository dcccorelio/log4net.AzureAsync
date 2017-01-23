Fork of [https://github.com/stemarie/log4net.Azure](https://github.com/stemarie/log4net.Azure) to add async support for table appenders.


## Configuration
### Table Storage 
Additional configuration options for AsyncAzureTableAppender (all optional):

* <b>BatchSize:</b>  
  Maximum number of items in a single batch submitted to table storage
* <b>RetryCount:</b>  
  Maximum number of times to retry failures before giving up
* <b>RetryWait:</b>  
  (Timespan) base time to wait between retry attempts (goes up for successive retries)
* <b>FlushInterval:</b>  
  (Timespan) time between automatic 'flush' calls (which pushes pending events up to table storage).
* <b>MaxMessageSize:</b>  
  Messages larger than this will be split into multiple messages with a sequence number.
