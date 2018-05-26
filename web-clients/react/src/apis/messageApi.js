/* global __API_URL__ */
import axios from "axios";
import EventEmitter from "wolfy87-eventemitter";

const apiUrl = `${__API_URL__}/messages`;

export const MESSAGE_CREATED = "message.created";
export const eventBus = new EventEmitter();

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

  eventBus.emit(MESSAGE_CREATED, message);

  return message;
}
