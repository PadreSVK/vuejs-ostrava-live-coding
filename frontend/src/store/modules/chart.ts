import { Module } from "vuex";
import * as signalR from "@microsoft/signalr";
import { configuration } from "@/configuration";

export const chart: Module<GraphState, GlobalState> = {
    state: {
        graphData: [],
    },
    getters: {
        graphData: (state) => state.graphData,
    },
    mutations: {
        update_graphData(state, { data }: { data: Array<Number> }) {
            state.graphData = data
        },
    },
    actions: {
        async initSignalR({ commit }) {
            const connection = new signalR.HubConnectionBuilder()
                .withUrl(configuration.signalRUrl)
                .withAutomaticReconnect()
                .build();

            connection.on("receiveGraphData", (numbers: Array<Number>) => {
                commit("update_graphData", { data: numbers })
            })
            
            await connection.start()
        }
    }
}