**Week 4 SQL**
# Table of contents
- [Principles of RDBMS and NoSQL](#principles)
- [ACID vs CAP](#acidcap)
- [Difference between RDBMS & NoSQL](#dbvssql)
- [Need for schemaless database](#schemaless)
- [Where should NoSQL be used?](#nosqluse)
- [Where should RDBMS be used?](#dbuse)
- [Why NoSQL over RDBMS?](#nosqlodb)
- [Why new applications are shifting to NoSQL?](#apps)

<div id="principles">

# Principles of RDBMS & NoSQL
- Traditional DBMS follow ACID properties which focuses more on data integrity, consistency & durability of the data.
- NoSQL follows CAP properties which focuses on consistency, high availability of data & partitioning.
- Both serve different purposes and cater different type of user base.
- It is important for user to know which database should be used for his/her project.
</div>

<div id="acidcap">

# ACID vs CAP
|ACID| CAP |
|--|--|
| ACID stands for Atomicity, Consistency, Isolation & Durability | CAP stands for Consistency, Availability, Partition tolerance |
|ACID is more focused on relational databases| CAP is more focused on distributed systems|
|ACID ensures transactions maintain database in consistent state| CAP ensures all nodes see same data at same time|
|ACID emphasizes more on maintaining data integrity and ensure all transactions are completed| CAP theorem states that in event of network partition, one has to choose between consistency or availability|
</div>

<div id="dbvssql">

# Difference between RDBMS & NoSQL

|RDBMS|NoSQL  |
|--|--|
|It is used to handle low to medium velocity data  | It is used to handle high velocity data |
|It manages structured data | It manages all types of data|
|Data arrives from one or few locations|Data arrives from many locations|
|RDBMS is single point of failure|NoSQL does not have single point of failure|
|Supports ACID properties|Supports CAP properties|
</div>
<div id="schemaless">

# Need for schemaless database
- Greater flexibility over data types:
	- By functioning without a schema, schemaless databases can store, retreive and query any data type- perfect for big data analytics and similar operations that are powered by unstructured data.
- No pre-defined schemas:
	- The absence of schema means that our NoSQL database can accept input of any data type. This future proofs the database, allowing it to evolve as our data-driven operations change in the future.
- No data truncation
	- A schemaless database almost makes no changes to the data that has been inserted into database.
	- Each of the item is stored in its own document with partial schema, without modifying raw information.
- Suitable for real-time analytics functions
	- With the ability to process unstructured data, applications built on NoSQL databased are better able to process real-time data.
</div>
<div id="nosqluse">

# Where should NoSQL to be used?
- Fast-paced Agile development
	- Because NoSQL databased often allow developers to be in control of the structure of the data, they are a good fit with modern Agile development practices.
	- It avoids developer to ask database administrator to frequently change the schema of the database which will slow down the development of application.
- Storage of structured and semi-structured data
	- NoSQL databases often store data in form that is similar to the objects used in applications, reducing the need for translation from the form the data is stored to form which is required in program.
- Huge volumes of data
	- NoSQL databases are created to handle big data as part of their architecture.
	- NoSQL databases are designed in such a way that the scaling of the storages is very much easy than compared to scaling of storage in traditional databases.
</div>
<div id="dbuse">

# Where should RDBMS be used?
- Centralized Apps
	- RDBMS ensures that data remains consistent and adheres to predefined database schema rules.
	- RDBMS provides access controls, authentication and auditing features which increases security of data stored.
- Moderate velocity of data
	- RDBMS excel at managing structured data with predefined schema. In applications where data arrives at moderate pace, follows a consistent structure.
	- The relation model provides a straightforward & efficient way to organize and query the data.
- Highly structured data
	- RDBMS are ideally suited for managing highly structured data, where data organization and relationships between entities are clearly defined.
	- With pre-defined schema RDBMS ensure data consistency, accuracy and integrity, making them suitable for applications with well defined data models.
</div>
<div id="nosqlodb">

# Why NoSQL over RDBMS?
- Flexible Schema
	- NoSQL databases allow for schema flexibility, enabling developers to store, query unstructured or semi-structured data.
	- This flexibility is huge advantage in application where the data constantly evolves at high velocity.
- Scalability
	- NoSQL databases are designed for horizontal scalability, allowing them to handle large volumes of data and high traffic loads by distributing data across the nodes/clusters.
- High Availability:
	- NoSQL databases are built to provide high availability and fault tolerance.
	- They employ replication and partitioning techniques to ensure data redundancy and minimize the risk of data loss or downtime due to hardware failures.
</div>
<div id="apps">

# Why new applications are shifting to NoSQL?
In the recent times most of the applications are shifting towards NoSQL database than compared to RDBMS.
Some of reasons for this shift are:
- High velocity data
	- In the recent times, data has become new currency in the internet.
	- Each and every application we use always keep on collecting data about how we use their application.
	- These type of data are known as high velocity data as they are generated frequently and needs to be stored efficiently.
- Availability and fault tolerance
	- NoSQL systems can handle high traffic and data throughout, ensuring high availability.
	- Mission critical application benefit from constant uptime and minimal downtime.
- Cost effectiveness
	- NoSQL does not need high computational power like traditional RDBMS model.
	- They can run on commodity hardware, making them much more cost effective than RDBMS.
- Flexibility
	- NoSQL databases are schema-less accommodating unstructured, semi-structured & structured data.
	- Developers can store wide variety of data types, including documents, graphs and key-value paris.
</div>




