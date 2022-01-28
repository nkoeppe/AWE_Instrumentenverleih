<template>
<div id="nav">
  <div id="app">
    <router-link to="/">Home</router-link> |
    <router-link to="/instruments">Instrumente</router-link> |
    <router-link to="/customer">Kunden</router-link>
  </div>
  <router-view />
  </div>

</template>

<script>

export default {
  name: 'App',
  data() {
          return {
              authenticated: false,
              token: ''
          }},
  mounted() {
      if(this.authenticated === false) {
          this.$router.replace({ name: "login" });
      }
  },

}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
