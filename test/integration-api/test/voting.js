const expect = require("chai").expect;
const axios = require("axios");

//TODO: use some config file or env to customize the URL
const messagingApiUrl = "http://localhost:5000/api/messages";
const votingApiUrl = "http://localhost:5001/api/votes";

const neverRejectSettings = {
  validateStatus: function() {
    return true; //never reject the response
  },
};

describe("Voting API", function() {
  before(async function() {
    const response = await axios.post(messagingApiUrl, {
      text: "test message for voting",
    });

    this.message = response.data;
  });

  describe("POST vote", function() {
    it("should add a vote to the given option name", async function() {
      const response = await axios.post(votingApiUrl, {
        optionName: "like",
        subjectId: this.message.id,
      });

      expect(response.status).to.equal(200);
      expect(response.data).to.deep.equal({
        like: 1,
      });
    });

    it("should reject empty option name", async function() {
      const body = {
        subjectId: this.message.id,
      };

      const response = await axios.post(
        votingApiUrl,
        body,
        neverRejectSettings,
      );
      expect(response.status).to.equal(400);
    });

    it("should reject empty subject id", async function() {
      const body = {
        optionName: "like",
      };

      const response = await axios.post(
        votingApiUrl,
        body,
        neverRejectSettings,
      );
      expect(response.status).to.equal(400);
    });
  });

  describe("GET votes by subject id", function() {
    before(function() {
      //add some votes
      return Promise.all([
        axios.post(votingApiUrl, {
          optionName: "like",
          subjectId: this.message.id,
        }),
        axios.post(votingApiUrl, {
          optionName: "dislike",
          subjectId: this.message.id,
        }),
      ]);
    });

    it("should return all votes", async function() {
      const response = await axios.get(`${votingApiUrl}/${this.message.id}`);

      expect(response.status).to.equal(200);
      expect(response.data).to.deep.equal({
        like: 2,
        dislike: 1,
      });
    });
  });
});
