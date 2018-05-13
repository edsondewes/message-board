/* global __API_URL__ */
import axios from "axios";

const apiUrl = `${__API_URL__}/messages`;

export function get(from) {
  return axios
    .get(apiUrl, {
      params: {
        from,
      },
    })
    .then(response => response.data);
}

export function getById(id) {
  return axios.get(`${apiUrl}/${id}`).then(function(response) {
    return response.data;
  });
}

export function post(obj) {
  return axios.post(`${apiUrl}`, obj).then(response => response.data);
}
