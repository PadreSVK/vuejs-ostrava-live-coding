<template>
  <AppLayout/>
</template>

<script lang="ts">
import Vue from "vue";
import { AppLayout } from "@/layouts";

export default Vue.extend({
  name: "App",
  components: {
      AppLayout
  },
  mounted(){
      this.$store.dispatch("initLogLevel")
  },

  data: () => ({
    //
  }),
});
</script>
