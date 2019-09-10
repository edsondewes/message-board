/* global __API_URL__ */
import axios from "axios";

const apiUrl = `${__API_URL__}/ranking`;

export async function get(optionName) {
  const response = await axios.get(`${apiUrl}/${optionName}`);
  return response.data;
}
