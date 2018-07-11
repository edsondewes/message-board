import Vue from 'vue';
import App from './components/App.vue';

export default context => {
  return new Promise((resolve, reject) => {
    const apiUrl = process.env.PUBLIC_API_URL;
    if (!apiUrl) {
      reject("Environment variable 'PUBLIC_API_URL' is required");
    }

    context.apiUrl = apiUrl;

    resolve(
      new Vue({
        render: h => h(App),
      }),
    );
  });
};
