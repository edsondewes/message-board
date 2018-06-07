/* global __API_URL__ */
import axios from "axios";
import Vue from "vue";

const apiUrl = `${__API_URL__}/messages`;

export const MESSAGE_CREATED = "message.created";
export const EventBus = new Vue();

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

export async function post(obj) {
  const response = await axios.post(`${apiUrl}`, obj);
  const message = response.data;

  EventBus.$emit(MESSAGE_CREATED, message);

  return message;
}
