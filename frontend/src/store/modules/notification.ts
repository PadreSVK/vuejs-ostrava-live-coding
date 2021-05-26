import { Module } from "vuex";

export const notification: Module<NotificationState, GlobalState> = {
    state:{
        errorMessage: "",
        showError: false
    },
    getters:{
        showError: (state) => state.showError,
        errorMessage: (state) => state.errorMessage,
    },
    mutations: {
        show_error(state, { message }) {
            state.showError = true
            state.errorMessage = message
        },
        close_error(state) {
            state.showError = false
            state.errorMessage = ""
        }
    },
    actions: {
        showError({ commit }, { message }) {
            commit("show_error", { message })
        },
        closeError({ commit }) {
            commit("close_error")

        }
    }
}