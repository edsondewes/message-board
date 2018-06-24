const messages = [];

module.exports = {
  addMessage: function(msg) {
    messages.unshift(msg);
  },
  listMessages: function() {
    return messages;
  },
};
