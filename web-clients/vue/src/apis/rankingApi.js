/* global __API_URL__ */
import axios from 'axios';

const apiUrl = `${__API_URL__}/ranking`;

export function get(optionName) {
  return axios.get(`${apiUrl}/${optionName}`).then(function(response) {
    return response.data;
  });
}
