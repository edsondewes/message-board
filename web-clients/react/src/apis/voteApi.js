/* global __API_URL__ */
const apiUrl = `${__API_URL__}/votes`;

export function get(subjectId) {
  return fetch(`${apiUrl}/${subjectId}`).then(function(response) {
    return response.json();
  });
}

export function post(subjectId, optionName) {
  return fetch(`${apiUrl}`, {
    method: "POST",
    body: JSON.stringify({
      subjectId,
      optionName,
    }),
    headers: {
      "Content-Type": "application/json",
    },
  }).then(response => response.json());
}
