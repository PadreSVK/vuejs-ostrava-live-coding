<template>
  <v-dialog v-model="show" scrollable :persistent="persistent" :width="width">
    <template #activator="{ on }">
      <slot name="showbutton" v-bind="on" />
    </template>
    <v-card v-if="show && !loading">
      <v-card-title>
        <h3>{{ title }}</h3>
      </v-card-title>
      <v-card-text>
        <v-flex class="mt-1">
          <slot name="content" />
        </v-flex>
      </v-card-text>
      <v-card-actions class="justify-space-around">
        <slot name="footer" :close="close" />
      </v-card-actions>
    </v-card>
    <v-card v-else>
      <v-card-title>
        <h3>{{ title }}</h3>
      </v-card-title>
      <v-card-text>
        Working...
        <v-progress-linear indeterminate />
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: {
    loading: {
      type: Boolean,
      default: false,
    },
    title: {
      type: String,
      required: true,
    },
    persistent: {
      type: Boolean,
      default: false,
    },
    width: {
      type: String,
      default: "40%",
    },
  },
  watch: {
    showModal(newValue) {
      if (newValue && !this.loading) {
        this.$emit("load-modal-event");
      }
    },
    loading(newValue) {
      if (!newValue) {
        this.$emit("load-modal-event");
      }
    },
  },
  data() {
    return {
      show: false,
    };
  },
  methods: {
    close() {
      this.show = false;
      this.$emit("close-modal-event");
    },
  },
};
</script>

<style></style>
