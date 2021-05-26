<template>
  <div>
    <HelloWorld />
    <v-btn @click="showErrorNotification({ message: 'Hello world' })"
      >Show Error</v-btn
    >
    <ModalDialogDetailBase
      :loading="loading"
      :detail="myDetail"
      name="XYZ"
      @confirm-event="confirm"
    >
      <template #showbutton="on">
        <v-btn @click="loadData" v-on="on">Show me</v-btn>
      </template>
      <template #content="{detail}">
        <v-text-field v-model="detail.name" label="Name" />
        <v-text-field v-model="detail.age" type="number" label="Age" />
      </template>
    </ModalDialogDetailBase>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { HelloWorld, ModalDialogDetailBase } from "@/components";

type User = {
  name: string;
  age: number;
};

export default Vue.extend({
  name: "Home",
  data() {
    return {
      loading: true,
      myDetail: {
        name: "Fero",
        age: 25,
      },
    };
  },

  components: {
    HelloWorld,
    ModalDialogDetailBase,
  },
  methods: {
    loadData() {
      setTimeout(() => {
        this.loading = false;
      }, 3000);
    },
    confirm({ detail }: { detail: User }) {
      console.log({ detail });
    },
  },
});
</script>
