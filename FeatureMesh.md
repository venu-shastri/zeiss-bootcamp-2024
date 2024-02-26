# Case Study 
The Feature Mesh software system will be a Cloud native feature store . This system will be designed to maximize the Data Scientists productivity by providing a platform to assist in feature engineering where the push and the pull of features from the platform is provided as a service along with other value-added functionality described later in the document. By maximizing the data scientist’s and Data Engineer’s work efficiency and production the system will meet their needs while remaining easy to understand and use.

### UseCases

The Data Scientist accesses the platform and publishes the built feature on the platform

The user specifies metadata for the features that would be used while searching.
The user leverages the GUI or the library to push the developed feature onto the platform.
The system displays the status message of the push operation to the user.
The Data Scientist accesses the platform and searches for the intended feature from the platform.

The user chooses to search by feature name, keyword, timestamp etc.
The system displays the choices to the user.
The user selects the desired feature from the search results.
The system presents the abstract of the feature to the user.
The user chooses to re-use the feature.
The system provides the requested feature.
The Data Scientist accesses the platform and uses the published feature for model training using the offline store within the platform.

The user leverages the built library from featuremesh to get the values of a feature for training the analytical model in his environment (i.e: Jupyter-Notebook etc)

The query parameters for the library call would include the feature Name and any other associated meta-data of the feature.

The system responds back with either a success status with associated feature value or an Error

The user has to program to catch any exceptions/errors thrown by the platform.

The workload for Offline store typically would involve Batch processing.

Platform that facilitates real time feature consumption for inferencing done by the analytical model deployed in production.

Develop a Library and/or use GUI is built in to the platform for Data Scientists to use.
