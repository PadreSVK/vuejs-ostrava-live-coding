<template>
  <div>
    <HelloWorld />
    <v-btn @click="showErrorNotification({ message: 'Hello world' })">Show Error</v-btn>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { HelloWorld } from "@/components";

export default Vue.extend({
  name: "Home",

  components: {
    HelloWorld,
  },
});
</script>
