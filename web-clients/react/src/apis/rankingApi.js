/* global __API_URL__ */
const apiUrl = `${__API_URL__}/ranking`;

export function get(optionName) {
  return fetch(`${apiUrl}/${optionName}`).then(function(response) {
    return response.json();
  });
}
