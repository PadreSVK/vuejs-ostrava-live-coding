<template>
  <div>
    <v-btn @click="cleanLogs">Clean Logs</v-btn>
    <v-btn @click="downloadLogs">Download Logs</v-btn>
    <v-data-table :items="logs" :headers="headers">
      <template #item.level="{ item }">
        <v-chip :color="getLevelColor(item)">{{ item.level }}</v-chip>
      </template>
    </v-data-table>
    <v-select
      :items="logLevels"
      v-model="logLevel"
      filled
      label="Current log level"
    ></v-select>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {
      headers: [
        { text: "Date", value: "date" },
        { text: "Level", value: "level" },
        { text: "Message", value: "message" },
      ],
      logLevels: ["Information", "Warning", "Error"],
    };
  },
  mounted() {
    this.$store.dispatch("dumpLogs");
  },
  computed: {
    logLevel: {
      get() {
        return this.$store.getters.logLevel;
      },
      set(value) {
        this.$store.dispatch("changeLogLevel", { logLevel: value });
      },
    },
    ...mapGetters(["logs"]),
  },
  methods: {
    getLevelColor({ level }) {
      switch (level) {
        case "Information":
          return "blue";
        case "Warning":
          return "yellow";
        case "Error":
          return "red";
        default:
          return "green";
      }
    },
    ...mapActions(["cleanLogs"]),
    downloadLogs(){
        console.table(this.logs)
    }
  },
};
</script>

<style></style>
