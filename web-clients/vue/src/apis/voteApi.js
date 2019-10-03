/* global __API_URL__ */
import axios from 'axios';

const apiUrl = `${__API_URL__}/votes`;

export async function get(subjectId) {
  const response = await axios.get(`${apiUrl}/${subjectId}`);
  return response.data;
}

export async function post(subjectId, optionName) {
  const response = await axios.post(`${apiUrl}`, {
    subjectId: subjectId.toString(),
    optionName,
  });
  return response.data;
}
