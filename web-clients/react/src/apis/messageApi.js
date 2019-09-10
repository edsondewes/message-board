/* global __API_URL__ */
import axios from "axios";
import EventEmitter from "wolfy87-eventemitter";

const apiUrl = `${__API_URL__}/messages`;

export const MESSAGE_CREATED = "message.created";
export const eventBus = new EventEmitter();

export async function get(from) {
  const response = await axios.get(apiUrl, {
    params: {
      from,
    },
  });

  return response.data;
}

export async function getById(id) {
  const response = await axios.get(`${apiUrl}/${id}`);
  return response.data;
}

export async function post(obj) {
  const response = await axios.post(`${apiUrl}`, obj);
  const message = response.data;

  eventBus.emit(MESSAGE_CREATED, message);

  return message;
}
