const expect = require("chai").expect;
const axios = require("axios");

const neverRejectSettings = {
  validateStatus: function() {
    return true; //never reject the response
  },
};

describe("Voting API", function() {
  before(async function() {
    const response = await axios.post(process.env.URL_MESSAGING_API, {
      text: "test message for voting",
    });

    this.message = response.data;
  });

  describe("POST vote", function() {
    it("should add a vote to the given option name", async function() {
      const response = await axios.post(process.env.URL_VOTING_API, {
        optionName: "like",
        subjectId: this.message.id.toString(),
      });

      expect(response.status).to.equal(200);
      expect(response.data).to.deep.equal({
        like: 1,
      });
    });

    it("should reject empty option name", async function() {
      const body = {
        subjectId: this.message.id.toString(),
      };

      const response = await axios.post(
        process.env.URL_VOTING_API,
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
        process.env.URL_VOTING_API,
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
        axios.post(process.env.URL_VOTING_API, {
          optionName: "like",
          subjectId: this.message.id.toString(),
        }),
        axios.post(process.env.URL_VOTING_API, {
          optionName: "dislike",
          subjectId: this.message.id.toString(),
        }),
      ]);
    });

    it("should return all votes", async function() {
      const response = await axios.get(
        `${process.env.URL_VOTING_API}/${this.message.id}`,
      );

      expect(response.status).to.equal(200);
      expect(response.data).to.deep.equal({
        like: 2,
        dislike: 1,
      });
    });
  });
});
