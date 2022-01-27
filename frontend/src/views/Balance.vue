<template>
  <div class="balance">
    <h1>Übersicht über alle Instrumente</h1>

    <table id="firstTable" class="styled-table" v-if="coinBalances">
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Tokens</th>
          <th>Wert in USD</th>
          <th>Aktueller Preis</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(balance, i) in coinBalances" v-bind:key="balance.Name">
          <td>
            {{ i }}
          </td>
          <td>
            {{ balance.name }}
          </td>
          <td>{{ balance.name }} {{ balance.available }}</td>
          <td>{{ balance.usdWorth.toFixed(2) }}$</td>
          <td>
            {{ balance.price }}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Balance",
  data() {
    return {
      coinBalances: null,
      info: null,
      token: null
    };
  },
  methods: {
    fire: function() {
      return {};
    }
  },
  mounted: async function() {
    try {

        this.token = await axios
          .post("localhost:3000/api/authenticate", {
          "user": "nico",
          "passwd" : "nico"
          }).then(res => res.data);
          console.log(this.token)
      this.info = await axios
        .get("http://localhost:3000")
        .then(res => res.data);
      this.coinBalances = await axios
        .get("http://localhost:3000/balance")
        .then(res => res.data);

      console.log(this.info);
      console.log(this.coinBalances);
    } catch (e) {
      console.error(`Z.81 ${e}`);
    }
  }
};
</script>
<style>
.styled-table {
  border-collapse: collapse;
  margin: 25px 0;
  font-size: 0.9em;
  font-family: sans-serif;
  min-width: 400px;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
  margin-left: auto;
  margin-right: auto;
}

.styled-table thead tr {
  background-color: #009879;
  color: #ffffff;
  text-align: left;
}

.styled-table th,
.styled-table td {
  padding: 12px 15px;
}

.styled-table tbody tr {
  border-bottom: 1px solid #dddddd;
}

.styled-table tbody tr:nth-of-type(even) {
  background-color: #f3f3f3;
}

.styled-table tbody tr:last-of-type {
  border-bottom: 2px solid #009879;
}

.styled-table tbody tr.active-row {
  font-weight: bold;
  color: #009879;
}
</style>
