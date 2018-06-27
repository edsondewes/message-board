const expect = require("chai").expect;
const axios = require("axios");

const neverRejectSettings = {
  validateStatus: function() {
    return true; //never reject the response
  },
};

describe("Messaging API", function() {
  describe("POST message", function() {
    it("should save the message and return it's data", async function() {
      const response = await axios.post(process.env.URL_MESSAGING_API, {
        text: "test text",
      });

      expect(response.status).to.equal(200);
      expect(response.data).to.have.all.keys("id", "created", "text");
    });

    it("should reject text longer than 250 characteres", async function() {
      const body = {
        text: "long-text".repeat(30),
      };

      const response = await axios.post(
        process.env.URL_MESSAGING_API,
        body,
        neverRejectSettings,
      );
      expect(response.status).to.equal(400);
    });

    it("should reject empty text", async function() {
      const body = {
        text: "",
      };

      const response = await axios.post(
        process.env.URL_MESSAGING_API,
        body,
        neverRejectSettings,
      );
      expect(response.status).to.equal(400);
    });
  });

  describe("GET message by id", function() {
    before(async function() {
      const response = await axios.post(process.env.URL_MESSAGING_API, {
        text: "test message by id",
      });

      this.message = response.data;
    });

    it("should return the same data as the POST method", async function() {
      const response = await axios.get(
        `${process.env.URL_MESSAGING_API}/${this.message.id}`,
      );

      expect(response.status).to.equal(200);
      expect(response.data).to.deep.equal(this.message);
    });

    it("should return not found for an unknown id", async function() {
      const response = await axios.get(
        `${process.env.URL_MESSAGING_API}/99999999`,
        neverRejectSettings,
      );

      expect(response.status).to.equal(404);
    });
  });

  describe("GET paginated messages", function() {
    before(async function() {
      //create some messages before testing the pagination
      this.messages = [];
      for (let index = 0; index < 5; index++) {
        var response = await axios.post(process.env.URL_MESSAGING_API, {
          text: `test message ${index}`,
        });

        this.messages.unshift(response.data);
      }
    });

    it("should return the last created messages if 'from' is not specified", async function() {
      const response = await axios.get(process.env.URL_MESSAGING_API);
      const responseMessages = response.data.slice(0, this.messages.length);
      expect(this.messages).to.deep.equal(responseMessages);
    });

    it("should return the messages created before the 'from'", async function() {
      const fromIndex = 1;
      const response = await axios.get(process.env.URL_MESSAGING_API, {
        params: {
          from: this.messages[fromIndex].id,
        },
      });

      const paginatedContext = this.messages.slice(fromIndex + 1);
      const responseMessages = response.data.slice(0, paginatedContext.length);

      expect(paginatedContext).to.deep.equal(responseMessages);
    });
  });
});
