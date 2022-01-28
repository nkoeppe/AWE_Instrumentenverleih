<template>
  <div class="home">


  <h1>Willkommen zum Instrumentenverleih</h1>
    <img alt="Instrumenten Logo" src="../assets/pic.png">



  </div>
</template>

<script>
// @ is an alias to /src

export default {
  name: 'Home',
  mounted: async function() {
   if(this.$parent.authenticated === false) {
        this.$router.replace({ name: "login" });
    }}
}
</script>
