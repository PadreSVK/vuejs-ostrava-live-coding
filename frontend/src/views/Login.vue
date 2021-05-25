<template>
  <div>
    <v-text-field label="Name" :value="name" />
    <v-text-field label="Password" type="password" :value="password" />
    <v-btn :to="{ name: 'Home' }">Login</v-btn>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: undefined,
      password: undefined,
    };
  },
};
</script>

<style></style>
