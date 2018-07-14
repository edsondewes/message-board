const OfflineMixin = {
  data() {
    return {
      offline: false,
    };
  },
  beforeDestroy() {
    window.removeEventListener('online', this.updateOnlineStatus);
    window.removeEventListener('offline', this.updateOnlineStatus);
  },
  mounted() {
    window.addEventListener('online', this.updateOnlineStatus);
    window.addEventListener('offline', this.updateOnlineStatus);

    if (this.offline !== !navigator.onLine) {
      this.updateOnlineStatus();
    }
  },
  methods: {
    updateOnlineStatus() {
      this.offline = !navigator.onLine;
    },
  },
};

export default OfflineMixin;
