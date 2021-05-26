import { GlobalState } from "@/store/interfaces";
import { Module } from "vuex";
import { configuration } from "@/configuration";
import { changeLogLevel, cleanLogs, dumpLogs, tryGetLogLevel } from "@/logger";


export const administration: Module<AdministrationState, GlobalState> = {
    state: {
        logLevel: configuration.logger.level,
        logs: []
    },
    getters: {
        logLevel: (state) => state.logLevel,
        logs: (state) => state.logs,
    },
    mutations: {
        update_log_level(state, logLevel: LogLevel) {
            state.logLevel = logLevel
        },
        update_logs(state, { logs }: { logs: Array<Log> }) {
            state.logs = logs
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
        },
        cleanLogs({ commit }) {
            cleanLogs()
            commit("update_logs", { logs: [] })
        },
        dumpLogs({ commit }) {
            const logs: Array<Log> = dumpLogs().map((i) => {
                const splittedLog = i.split("|=|");
                return {
                    date: splittedLog[0].trim(),
                    level: splittedLog[1].trim(),
                    message: splittedLog[2].trim(),
                };
            });
            commit("update_logs", { logs })
        }
    }
}