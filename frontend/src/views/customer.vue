<template>
  <div class="balance">
    <h1>Übersicht über alle Kunden</h1>

    <table id="firstTable" class="styled-table" v-if="customers">
      <thead>
        <tr>
          <th>ID</th>
          <th>Vorname</th>
          <th>Nachname</th>
          <th>Ort</th>
          <th>Straße</th>
          <th>Hausnummer</th>
          <th>Telefonnummer</th>

        </tr>
      </thead>
      <tbody>
        <tr v-for="(customer) in customers" v-bind:key="customer.ID">
          <td>
            {{ customer.ID }}
          </td>
          <td>
            {{ customer.Vorname }}
          </td>
          <td>{{ customer.Name }} </td>
          <td>{{ customer.Ort }}</td>
          <td>
            {{ customer.Strasse}}
          </td><td>
            {{ customer.Hausnummer}}
          </td><td>
            {{ customer.Telefonnummer}}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Customer",
  data() {
    return {
      customers: null,
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


      this.customers = await axios
        .get("http://localhost:3000/api/customer", { headers: {auth: this.$parent.token} })
        .then(res => res.data);

      console.log(this.info);
      console.log(this.customer);
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
