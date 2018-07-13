import Vue from 'vue';
import App from './components/App.vue';
import registerServiceWorker from './registerServiceWorker';

const initialState = window.__INITIAL_STATE__ || {};

new Vue({
  render: h =>
    h(App, {
      props: initialState,
    }),
}).$mount('#app');

registerServiceWorker();
