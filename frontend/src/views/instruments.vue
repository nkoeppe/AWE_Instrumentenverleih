<template>
  <div class="balance">
    <h1>Übersicht über alle Instrumente</h1>

    <table id="firstTable" class="styled-table" v-if="instruments">
      <thead>
        <tr>
          <th>ID</th>
          <th>Instrument</th>
          <th>Ausgeliehen (Anzahl)</th>
          <th>Auf Lager (Anzahl)</th>
          <th>Preis pro Tag</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(instrument) in instruments" v-bind:key="instrument.ID">
          <td>
            {{ instrument.ID }}
          </td>
          <td>
            {{ instrument.Name }}
          </td>
          <td>{{ instrument.Ausgeliehen }} </td>
          <td>{{ instrument.AufLager }}</td>
          <td>
            {{ instrument.Preis }} €
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Instruments",
  data() {
    return {
      instruments: null,
      info: null,
      token : null
    };
  },
  methods: {
    fire: function() {
      return {};
    }
  },
  mounted: async function() {
    try {

    if(this.$parent.authenticated === false) {
        this.$router.replace({ name: "login" });
    }
      this.instruments = await axios
        .get("http://localhost:3000/api/instruments", { headers: {auth: this.$parent.token} })
        .then(res => res.data);

      console.log(this.info);
      console.log(this.instruments);
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
