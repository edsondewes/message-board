import Vue from 'vue';
import App from './components/App.vue';

const initialState = window.__INITIAL_STATE__ || {};

new Vue({
  render: h =>
    h(App, {
      props: initialState,
    }),
}).$mount('#app');
