# GraphQL Server

Example of GraphQL server using dataloader and GRPC services.
Credits:

- graphql-dotnet: https://graphql-dotnet.github.io/
- graphql-playground: https://github.com/prismagraphql/graphql-playground
- GRPC: https://grpc.io/

## Running the GRPC services for development

The easiest way to start all the services is by using the docker-compose file located in the root of the repository.

```bash
docker-compose -f docker-compose.grpc-only.yml up -d
cd server/graphql
dotnet run
```

If you want to debug some specific service, you can run it using VS Code or Visual Studio.
Make sure a Redis and a NATS servers are running and the hosts are correct in the appsettings.json file.

## Mutations

First of all, let's create some messages:

```graphql
mutation newMessages($message: MessageInput!) {
  createMessage(message: $message) {
    id
    created
    text
  }
}
```

Set the **$message** variable to:

```json
{
  "message": {
    "text": "My new message"
  }
}
```

And the result will be:

```json
{
  "data": {
    "createMessage": {
      "id": 1,
      "created": "2018-06-19T22:37:39.3040954Z",
      "text": "My new message"
    }
  }
}
```

Now we can add a vote to that message.

```graphql
mutation newVote($vote: VoteInput!) {
  addVote(vote: $vote) {
    count
    optionName
  }
}
```

Set the **$vote** variable to:

```json
{
  "vote": {
    "optionName": "like",
    "subjectId": "1"
  }
}
```

And the result will be:

```json
{
  "data": {
    "addVote": {
      "count": 1,
      "optionName": "like"
    }
  }
}
```

Try to create more messages and add some votes.

## Queries

After creating some messages, we can execute a query to retrieve a paginated list.

```graphql
query paginatedList {
  messages {
    id
    created
    text
    votes {
      count
      optionName
    }
  }
}
```

You can also use the parameter **from** to continue the pagination.

```graphql
query paginatedList{
  messages(from: 10){
  ...
  }
}
```

After a few votes, you probably want a ranking of the most liked messages.
You can use the ranking query for that:

```graphql
query topLiked {
  ranking(optionName: "like") {
    voteCount
    message {
      id
      text
    }
  }
}
```

You can query other types of rankings using a different **optionName**.
