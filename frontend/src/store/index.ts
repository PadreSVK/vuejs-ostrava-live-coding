import Vue from 'vue'
import Vuex from 'vuex'
import { identity, administration, notification, chart } from "@/store/modules";

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
    },
    mutations: {
    },
    actions: {
    },
    modules: {
        identity,
        administration,
        notification,
        chart
    }
})
