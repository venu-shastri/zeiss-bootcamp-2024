# Docker


## Community Edition

### Free

## Enterprise Edition 

## Commands

### images

- docker images

- docker rmi imageName

	- />docker rmi $(docker images -aq)

- docker pull imageName

	-  docker pull imageName:tagValue

### container

- docker ps

- docker stop containerName

- docker rm containerName

- docker exec containerName command

- docker run imageName

	- docker run -it image name terminal

		- Start container in interactive mode and attach terminal

	- docker run -d —name <ContainerName> image

	- docker run -p hostPort:containerPort image name

		- docker run -p 80:5000 testWebApp

	- docker run -v hostDir:ContainerDir imagename

	-  docker run -e ENV=value imagename

- docker run -d imageName

	- Runs in background

- docker attach <containerId>

	- To attach

- Inspect Container

	- docker inspect <container Name>

- View logs

	- docker logs containerId

### Compose

- docker compose up

	- docker-compose.yml

## Orchestration

### Docker  Swarm

- DockerHub 

### Kubernetes

- From Google

	- Components

		- Api Server

			- Ui Interface

		- etcd

			- Distributed Key Value Store

			- Stores all data used to manage cluster

		- kubelet

			- Agent Runs in each node in the cluster

		- Container Runtime

			- docker

		- Controller

			- Monitoring and noticing when nodes, containers goes down

			- Creates new container

		- Scheduler

			- Distributing Requests Across cluster nodes

		- kubectl

			- Command line interface tool

- Cluster

	- Node

		- Master node

			- Host kube-apiserver,etcd,controller,schedular and kubelet

		- Worker node

			- Host pods and kubelet

				- Pod

					- host container(docker or CRIO or Rocket

					- A pod is a single instance of application

					- Smallest object in the k8s world

					- One to one Relationship with container

					- How to create ?

						- kubectl run podName - -image <imageName>

							- kubctl describe pod <podname>

						- Using YAML files

							- apiVesrion

								- Pod

									- v1

								- Service

									- v1

								- ReplicaSet

									- apps/v1

								- Deployment

									- apps/v1

							- kind

								- Type of object we are trying to create

									- Pod

									- Service

									- Deployment

									- ReplicaSet

									- ReplicationController

							- metadata

								- Dictionary

								- Name, labels etc

							- spec

								- Different for different object types

								- For POD type add image propoerty

							- kubectl create -f <fileName.yaml>

						- Using Deployment

							- Deployment provides means of changing the state of pod

							- Running multiple instances of an application

							- Scaling the number of instances of an application up or down

							- Updating every running instance of an application

							- Rolling back all running instances of an application to another version

							- Deployment Strategy

								- Recreate

								- Rolling Update

					- How to list pods?

						- kubectl get pods

					- How to access Application outside?

						- Use Services

							- types

								- NodePort

									- TargetPort

										- Container Application Port

									- Port

										- Service port or Cluster-ip

									- NodePort

										- 30000-32767

								- ClusterIP

								- LoadBalancer

- Setup

	- minikube

		- Sing-node kubernetes cluster

			- minikube start

	- kubeadm

		- Multi-node cluster

	- Cloud platform

	- Play-with-k8s.com

- Networking

	- IP address is Assigned to POD

	- Kubernetes Creates its own network per cluster

	- Services

		- Enable Loosely coupled Communication b/w pods

		- 

			- Act as builtin load balancer

### Mesos

- From Apache

