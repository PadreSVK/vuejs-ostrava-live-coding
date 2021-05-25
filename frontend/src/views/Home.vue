<template>
  <MainLayout>
     <HelloWorld />
  </MainLayout>
</template>

<script lang="ts">
import Vue from "vue";
import { HelloWorld } from "@/components";
import { MainLayout } from "@/layouts";

export default Vue.extend({
  name: "Home",

  components: {
    HelloWorld,
    MainLayout
  },
});
</script>
