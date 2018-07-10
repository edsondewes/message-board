import Vue from "vue";
import App from "./components/App.vue";

export default () => {
  return Promise.resolve(
    new Vue({
      render: h => h(App),
    }),
  );
};
