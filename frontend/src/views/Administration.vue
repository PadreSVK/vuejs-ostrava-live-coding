<template>
  <div>
    <v-btn @click="dumpLogs">Dump Logs</v-btn>

    <v-data-table :items="logs" :headers="headers"> </v-data-table>

    <v-select
      :items="logLevels"
      v-model="logLevel"
      filled
      label="Current log level"
    ></v-select>
  </div>
</template>

<script>
import { dumpLogs } from "@/logger";

export default {
  data() {
    return {
      logs: [],
      headers: [
        { text: "Date", value: "date" },
        { text: "Level", value: "level" },
        { text: "Message", value: "message" },
      ],
      logLevels: ["Information", "Warning", "Error"],
    };
  },
  computed: {
    logLevel: {
      get() {
        return this.$store.state.logLevel;
      },
      set(value) {
        this.$store.dispatch("changeLogLevel", { logLevel: value });
      },
    },
  },
  methods: {
    dumpLogs() {
      const logs = dumpLogs();
      this.logs = logs.map((i) => {
        const splittedLog = i.split("|=|");
        return {
          date: splittedLog[0],
          level: splittedLog[1],
          message: splittedLog[2],
        };
      });
    },
  },
};
</script>

<style></style>
