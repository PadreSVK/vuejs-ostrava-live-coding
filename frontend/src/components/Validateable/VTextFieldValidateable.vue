<template>
  <ValidationProvider
    :name="$attrs.label"
    :rules="rules"
    v-slot="{ errors }"
    :disabled="$attrs.disabled"
  >
    <v-text-field
      v-model="innerValue"
      :error-messages="errors"
      v-bind="$attrs"
      v-on="$listeners"
    />
  </ValidationProvider>
</template>

<script>
export default {
  name: "VTextFieldValidateable",
  props: {
    rules: {
      type: [Object, String],
      default: "",
    },
    value: {
      type: null,
    },
  },
  data() {
    return {
      innerValue: "",
    };
  },
  watch: {
    //   v-model
    innerValue(newVal) {
      this.$emit("input", newVal);
    },
    value: {
      handler(newVal) {
        this.innerValue = newVal;
      },
      immediate: true,
    },
  },
};
</script>
