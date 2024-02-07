# Readme

Run Debezium Kafka Connect using Docker, with Kafka, Zookeeper, Kowl.


1. Start all containers <br/>
`docker-compose up -d`
2. Use a SQL server client to connect to sql server as 'sa', and do the following: <br/>
- create a 'testdb'
- create a 'SampleTable' <br/>
`CREATE TABLE dbo.SampleTable (
    id INT PRIMARY KEY,
    name NVARCHAR(100),
    age INT
);`
- Insert some data<br/>
`INSERT INTO dbo.SampleTable (id, name, age) VALUES (1, 'John', 30);
INSERT INTO dbo.SampleTable (id, name, age) VALUES (2, 'Jane', 25);`
- Enable CDC<br/>
`EXEC sys.sp_cdc_enable_db`<br/>
`EXEC sys.sp_cdc_enable_table  
@source_schema = N'dbo',  
@source_name   = N'SampleTable',  
@role_name     = NULL,  
@supports_net_changes = 1`
3. Run post command to set up connector (in `query.http`)
4. Make some data changes in the sample table, and watch changes in Kowl.
5. Alternatively, run KafkaConsumerApp to see the Kafka messages


References:
1. https://medium.com/@cloud_geek/run-debezium-kafka-connect-using-docker-kafka-zookeeper-kafdrop-kafka-connect-docker-2e67760ef85d
2. https://debezium.io/documentation/reference/stable/connectors/sqlserver.html#debezium-connector-for-sql-server
3. https://redpanda.com/blog/change-data-capture-sql-server-debezium
