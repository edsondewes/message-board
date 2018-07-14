/* global __API_URL__ */
import axios from 'axios';

const apiUrl = `${__API_URL__}/votes`;

export function get(subjectId) {
  return axios.get(`${apiUrl}/${subjectId}`).then(function(response) {
    return response.data;
  });
}

export function post(subjectId, optionName) {
  return axios
    .post(`${apiUrl}`, {
      subjectId,
      optionName,
    })
    .then(response => response.data);
}
