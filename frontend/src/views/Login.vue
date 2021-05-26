<template>
  <div>
    <v-text-field label="Name" v-model="name" />
    <v-text-field label="Password" v-model="password" :value="password" />
    <v-btn @click="login">Login</v-btn>
    <v-alert color="red" :value="showLoginError">Wrong credentials</v-alert>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: undefined,
      password: undefined,
      showLoginError: false,
    };
  },
  methods: {
    async login() {
      const { autenticated } = await this.$store.dispatch("login", {
        email: this.name,
        password: this.password,
      });
      if (autenticated) {
        const redirectTo = this.$route.query.redirect || { name: "Home" };
        this.$router.replace(redirectTo);
      } else {
        this.showLoginError = true;
      }
    },
  },
};
</script>

<style></style>
