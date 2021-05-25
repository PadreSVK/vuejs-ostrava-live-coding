<template>
   <HelloWorld />
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
