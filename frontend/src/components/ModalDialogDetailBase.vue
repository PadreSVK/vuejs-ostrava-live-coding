<template>
  <ModalDialogBase
    :persistent="true"
    :loading="loading"
    :title="`Detail of ${name}`"
    @load-modal-event="loadState"
    @close-modal-event="cleanState"
  >
    <template #showbutton="on">
      <slot name="showbutton" v-bind="on" />
    </template>
    <template #content>
      <slot name="content" v-bind:detail="innerDetail" />
    </template>
    <template #footer="{close}">
      <v-btn color="error" text @click="close">Cancel</v-btn>
      <v-spacer />
      <v-btn color="success" text @click="confirm(close)">Confirm</v-btn>
    </template>
  </ModalDialogBase>
</template>

<script>
import { ModalDialogBase } from "@/components";
import { deepClone } from "@/utils";

export default {
  components: {
    ModalDialogBase,
  },
  props: {
    loading: {
      type: Boolean,
      default: false,
    },
    detail: {
      type: Object,
      required: true,
    },
    name: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      innerDetail: undefined,
    };
  },
  methods: {
    loadState() {
      this.innerDetail = deepClone(this.detail);
    },
    confirm(close) {
      //todo add validations
      this.$emit("confirm-event", { detail: this.innerDetail });
      close();
    },
    cleanState() {
      this.innerDetail = undefined;
    },
  },
};
</script>

<style></style>
