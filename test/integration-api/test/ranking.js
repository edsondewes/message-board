const expect = require("chai").expect;
const axios = require("axios");

//TODO: use some config file or env to customize the URL
const rankingApiUrl = "http://localhost:5002/api/ranking";
const votingApiUrl = "http://localhost:5001/api/votes";

describe("Ranking API", function() {
  before(async function() {
    //create an unique vote option
    this.optionName = `opt-${new Date().getTime()}`;

    //create votes for different subject ids
    this.votes = {
      [`${this.optionName}-1`]: 1,
      [`${this.optionName}-2`]: 3,
      [`${this.optionName}-3`]: 2,
    };

    const requests = [];
    Object.entries(this.votes).forEach(([subjectId, voteCount]) => {
      for (let index = 0; index < voteCount; index++) {
        requests.push(
          axios.post(votingApiUrl, {
            optionName: this.optionName,
            subjectId: subjectId,
          }),
        );
      }
    });

    await Promise.all(requests);
  });

  describe("GET most voted by option name", function() {
    it("should return a ranking ordered by vote count", async function() {
      const response = await axios.get(`${rankingApiUrl}/${this.optionName}`);

      expect(response.status).to.equal(200);
      expect(response.data).deep.equal([
        { subjectId: `${this.optionName}-2`, count: 3 },
        { subjectId: `${this.optionName}-3`, count: 2 },
        { subjectId: `${this.optionName}-1`, count: 1 },
      ]);
    });
  });
});
