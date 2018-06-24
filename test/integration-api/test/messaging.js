const expect = require("chai").expect;
const axios = require("axios");
const context = require("../helpers/testContext");

//TODO: use some config file or env to customize the URL
const apiUrl = "http://localhost:5000/api/messages";

const neverRejectSettings = {
  validateStatus: function() {
    return true; //never reject the response
  },
};

describe("Messaging API", function() {
  describe("POST message", function() {
    it("should save the message and return it's data", async function() {
      const response = await axios.post(apiUrl, {
        text: "test text",
      });

      expect(response.status).to.equal(200);
      expect(response.data).to.have.all.keys("id", "created", "text");

      context.addMessage(response.data);
    });

    it("should reject text longer than 250 characteres", async function() {
      const body = {
        text: "long-text".repeat(30),
      };

      const response = await axios.post(apiUrl, body, neverRejectSettings);
      expect(response.status).to.equal(400);
    });

    it("should reject empty text", async function() {
      const body = {
        text: "",
      };

      const response = await axios.post(apiUrl, body, neverRejectSettings);
      expect(response.status).to.equal(400);
    });
  });

  describe("GET message by id", function() {
    it("should return the same data as the POST method", async function() {
      const contextMessage = context.listMessages()[0];
      const response = await axios.get(`${apiUrl}/${contextMessage.id}`);

      expect(response.status).to.equal(200);
      expect(response.data).to.deep.equal(contextMessage);
    });

    it("should return not found for an unknown id", async function() {
      const response = await axios.get(
        `${apiUrl}/99999999`,
        neverRejectSettings,
      );

      expect(response.status).to.equal(404);
    });
  });

  describe("GET paginated messages", function() {
    before(async function() {
      //create some messages before testing the pagination
      for (let index = 0; index < 5; index++) {
        var response = await axios.post(apiUrl, {
          text: `test message ${index}`,
        });

        context.addMessage(response.data);
      }
    });

    it("should return the last created messages if 'from' is not specified", async function() {
      const response = await axios.get(apiUrl);

      const contextMessages = context.listMessages();
      const responseMessages = response.data.slice(0, contextMessages.length);

      expect(contextMessages).to.deep.equal(responseMessages);
    });

    it("should return the messages created before the 'from'", async function() {
      const contextMessages = context.listMessages();
      const fromIndex = 1;

      const response = await axios.get(apiUrl, {
        params: {
          from: contextMessages[fromIndex].id,
        },
      });

      const paginatedContext = contextMessages.slice(fromIndex + 1);
      const responseMessages = response.data.slice(0, paginatedContext.length);

      expect(paginatedContext).to.deep.equal(responseMessages);
    });
  });
});
