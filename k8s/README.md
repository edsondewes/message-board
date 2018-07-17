# Running on kubernetes
This deployment script has only been tested on [minikube](https://github.com/kubernetes/minikube). If you run a real cluster, you may need to change it according to your needs.

## Prerequisites
Make sure you have a kubernetes cluster and a working  **kubectl** binary on your workstation.

## Deployments and services
Run the following command on the root folder of this repository:
```bash
cd k8s
./deploy.sh
```
This command will create the following services and deployments:
1. Redis
2. NATS
3. Message Board API Services
4. React Web App
5. Traefik Ingress Controller (DaemonSet)
6. Traefik Dashboard Ingress
7. Message Board API Ingress

The ingress is set to listen on some hostnames. Make sure that your hosts file has the following configuration:
```bash
echo "$(minikube ip) traefik-ui.minikube" | sudo tee -a /etc/hosts
echo "$(minikube ip) messageboard.minikube" | sudo tee -a /etc/hosts
```
You can now open your browser and visit http://messageboard.minikube and http://traefik-ui.minikube

## Removing the app
The following command will remove the entire application:
```bash
./deploy.sh -d
```