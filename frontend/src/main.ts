import Vue from 'vue'
import App from './App.vue'
import store from './store'
import router from './router'
import vuetify from './plugins/vuetify'
import veeValdiate from './plugins/veevalidate'
import { OpenAPI } from "@/apiService";
import { isDevelopment, configuration } from '@/configuration'
import { apply } from "./mixins";
apply()

veeValdiate.apply(Vue)

OpenAPI.BASE = configuration.baseUrl

if (isDevelopment()) {
    console.table(process.env)
}

Vue.config.productionTip = false

new Vue({
    store,
    router,
    vuetify,
    render: h => h(App)
}).$mount('#app')
