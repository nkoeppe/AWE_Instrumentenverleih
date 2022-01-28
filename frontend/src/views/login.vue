<template>
    <div id="login">
        <h1>Login</h1>
        <input type="text" name="username" v-model="input.username" placeholder="Username" />
        <input type="password" name="password" v-model="input.password" placeholder="Password" />
        <button type="button" v-on:click="login()">Login</button>

    </div>

</template>

<script>
import axios from "axios";

    export default {
        name: 'Login',
        data() {
            return {
                input: {
                    username: "",
                    password: ""
                }
            }
        },
        methods: {
            async login() {
            try {

            console.log(this.input.username)
                if(this.input.username != "" && this.input.password != "") {
                this.$parent.token = await axios
                  .post("http://localhost:3000/api/authenticate", {
                  "user": this.input.username,
                  "passwd" : this.input.password
                  })
                  .then(res => res.data);

                  console.log(this.$parent.token)
                  this.$parent.authenticated = true;
                  this.$router.replace({ name: "Home" });

                } else {
                    console.log("A username and password must be present");
                }
              }catch{
                this.$parent.token = "";
                this.$parent.authenticated = false;
                this.$alert("Username or password is wrong");

              }

            }
        }
    }
</script>

<style scoped>
    #login {
        width: 500px;
        border: 1px solid #CCCCCC;
        background-color: #FFFFFF;
        margin: auto;
        margin-top: 200px;
        padding: 20px;
    }
</style>
