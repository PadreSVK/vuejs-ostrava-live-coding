<template>
  <div>
    <v-tabs>
      <v-tab :to="{ name: 'Home' }" >Home</v-tab>
      <v-tab :to="{ name: 'About' }">About</v-tab>
    </v-tabs>
    <slot/>
  </div>
</template>

<script>
export default {};
</script>

<style></style>
