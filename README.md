# Message Board - Simple web app for learning/testing new frameworks, features and ideas

This is a simple web app for writing messages.
The goal is to keep it's code simple so everyone can read, understand and maybe use some parts in your projects.

I'll try to keep it updated and adding new features.
You can see below what is done and what is planned.

# Features
## Backend / services
- [x] Messaging, voting and ranking APIs (.NET Core 2.1)
- [x] Internal communication using command/query with [MediatR](https://github.com/jbogard/MediatR)
- [x] External communication using [NATS](https://nats.io/)
- [x] Redis as database
- [x] GraphQL Server (with data loader)
- [x] GRPC Services
- [ ] Basic metrics (probably using [Prometheus](https://prometheus.io/))
- [ ] Integration tests

## React App
- [x] React 16.x client
- [x] Server side rendering (without frameworks and fetching data)
- [x] Offline support
- [x] Responsive layout
- [x] PWA ready
- [x] Light/dark themes (using css variables)

## Vue App
- [x] Vue 2.5.x client
- [ ] Server side rendering
- [ ] Offline support
- [x] Responsive layout
- [ ] PWA ready
- [x] Light/dark themes

## Other
- [x] Deployment: https://messageboard.site
- [x] [Traefik](https://traefik.io/) as API Gateway
- [x] Docker support (multistage build)
- [ ] Kubernetes support

# Running
## Entire application (web client)
```bash
docker-compose up -d
```

Open http://localhost:8080/ in your browser

## Only APIs for web development
```bash
docker-compose -f docker-compose.api-only.yml up -d
cd web-clients/react/
yarn install
yarn start
```

## GraphQL Playground
```bash
docker-compose -f docker-compose.graphql.yml up -d
```

Open http://localhost:8181/ in your browser

# Sending feedback and pull requests
Fell free to open issues pointing to bugs, feature request, discuss some ideas/implementations of the project.
If you know how to solve some problem, have an interesting new feature or want to implement using another framework (polymer, angular), send me a pull request!
