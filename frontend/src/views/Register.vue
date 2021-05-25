<template>
  <div>
    <h1>Create new User</h1>
    <v-text-field label="Name" :value="name" />
    <v-text-field label="Password" type="password" :value="password" />
    <v-btn @click="createUser">Create user</v-btn>
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
  methods:{
      createUser(){

      }
  }
};
</script>

<style></style>
