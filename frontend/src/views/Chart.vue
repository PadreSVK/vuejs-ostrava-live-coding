<template>
  <div>
    <LineChart :chart-data="graphData" />
    <v-btn @click="initSignalR">Init signalR</v-btn>
  </div>
</template>

<script>
import { LineChart } from "@/components";
export default {
  components: {
    LineChart,
  },
  data() {
    return {
      numbers: [1, 2, 3],
    };
  },
  computed: {
    graphData() {
      return {
        labels: [
          "January",
          "February",
          "March",
          "April",
          "May",
          "June",
          "July",
        ],
        datasets: [
          {
            label: "Data One",
            borderColor: "#FC2525",
            pointBackgroundColor: "white",
            borderWidth: 1,
            pointBorderColor: "white",
            backgroundColor: this.gradient,
            data: this.$store.getters.graphData,
          },
        ],
      };
    },
  },
  methods: {
    initSignalR() {
      this.$store.dispatch("initSignalR");
    },
  },
};
</script>

<style></style>
