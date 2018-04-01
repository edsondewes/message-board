/* global __API_URL__ */
const apiUrl = `${__API_URL__}/messages`;

export function get(from) {
  return fetch(`${apiUrl}?from=${from || ""}`).then(function(response) {
    return response.json();
  });
}

export function post(obj) {
  return fetch(`${apiUrl}`, {
    method: "POST",
    body: JSON.stringify(obj),
    headers: {
      "Content-Type": "application/json",
    },
  }).then(response => response.json());
}
