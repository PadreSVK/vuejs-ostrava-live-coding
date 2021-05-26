import { GlobalState } from "@/store/interfaces";
import { Module } from "vuex";
import { configuration } from "@/configuration";
import { changeLogLevel, tryGetLogLevel } from "@/logger";


export const administration: Module<AdministrationState, GlobalState> = {
    state: {
        logLevel: configuration.logger.level
    },
    getters: {
        logLevel: (state) => state.logLevel
    },
    mutations: {
        update_log_level(state, logLevel: LogLevel) {
            state.logLevel = logLevel
        }
    },
    actions: {
        changeLogLevel({ commit }, { logLevel }: { logLevel: LogLevel }) {
            commit("update_log_level", logLevel)
            changeLogLevel(logLevel)
        },
        initLogLevel({ commit }) {
            const logLevel = tryGetLogLevel()
            if (logLevel) {
                commit("update_log_level", logLevel)
            }
        }
    }

}