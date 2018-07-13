import Vue from 'vue';
import App from './components/App.vue';

export default async context => {
  const apiUrl = process.env.PUBLIC_API_URL;
  if (!apiUrl) {
    throw "Environment variable 'PUBLIC_API_URL' is required";
  }

  const initialState = await App.asyncData();
  context.state = initialState;
  context.apiUrl = apiUrl;

  return new Vue({
    render: h =>
      h(App, {
        props: initialState,
      }),
  });
};
