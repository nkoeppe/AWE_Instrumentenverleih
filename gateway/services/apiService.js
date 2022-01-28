const jwt = require('jsonwebtoken');
const passport = require('passport')
const axios = require('axios');
const SECRET = 'test_secret'


class ApiService {
  constructor() {

  }
  authenticate() {

  }

  greet(req, res, next) {
    try {
      res.status(200).send("Successfully greeted")
    } catch (err) {
      res.staus(500).send(err)
    }
  }



  getInstruments(req, res, next) {
    try {
      console.log("test")

      /*  const mockReturn = [{
          ID: 0,
          Name: "Trompete",
          HerstellerFK: 1,
          Preis: 14,
          Ausgeliehen: true
        }, {
          ID: 1,
          Name: "tuba",
          HerstellerFK: 1,
          Preis: 23,
          Ausgeliehen: true
        }, {
          ID: 2,
          Name: "tuba",
          HerstellerFK: 1,
          Preis: 23,
          Ausgeliehen: false
        }, {
          ID: 3,
          Name: "schlagzeug",
          HerstellerFK: 2,
          Preis: 199.69,
          Ausgeliehen: false
        }, {
          ID: 4,
          Name: "schlagzeug",
          HerstellerFK: 2,
          Preis: 199.99,
          Ausgeliehen: true
        }, {
          ID: 5,
          Name: "trompete",
          HerstellerFK: 1,
          Preis: 14,
          Ausgeliehen: true
        }, {
          ID: 6,
          Name: "trompete",
          HerstellerFK: 1,
          Preis: 14,
          Ausgeliehen: false
        }]*/
      const mockReturn = [{
        ID: 0,
        Name: "Trompete",
        HerstellerFK: 1,
        Preis: 14.50,
        Ausgeliehen: 6,
        AufLager: 10
      }, {
        ID: 1,
        Name: "Tuba",
        HerstellerFK: 1,
        Preis: 23.90,
        Ausgeliehen: 18,
        AufLager: 40
      }, {
        ID: 2,
        Name: "Schlagzeug",
        HerstellerFK: 2,
        Preis: 420.69,
        Ausgeliehen: 3,
        AufLager: 1
      }, {
        ID: 3,
        Name: "Geige",
        HerstellerFK: 3,
        Preis: 199.69,
        Ausgeliehen: 5,
        AufLager: 0
      }, {
        ID: 6,
        Name: "Flöte",
        HerstellerFK: 4,
        Preis: 2.50,

        Ausgeliehen: 0,
        AufLager: 25
      }]
      res.send(mockReturn)

    } catch (e) {
      res.status(500).send(e)
    }
  }


  async getCustomer(req, res, next) {
    //const result = await axios.get('localhost:3002/api/values')
    // const result = await axios.get("172.0.0.1:3002/api/values")
    try {
      //const result = await axios.get("http://127.0.0.1:3002/api/values")
      //const result = await axios.get("http://localhost:3002/api/values")

      //const result = await axios({
      //    url: "127.0.0.1:3002/api/values"
      //  })


      //console.log(result)
      const mockReturn = [{
        ID: 0,
        Vorname: "Nico",
        Name: "Köppe",
        Strasse: "fucking-awesome",
        Hausnummer: 69,
        Ort: "siiick",
        Telefonnummer: "555-123-123-123"
      }, {
        ID: 1,
        Vorname: "Alex",
        Name: "FG",
        Strasse: "schulstrasse",
        Hausnummer: 420,
        Ort: "nicht-sick",
        Telefonnummer: "123-555-555-555"
      }, {
        ID: 2,
        Vorname: "Fabian",
        Name: "Louis",
        Strasse: "TFT-Street",
        Hausnummer: 3,
        Ort: "afk",
        Telefonnummer: "420-69-420-69"
      }]
      res.send(mockReturn)
    } catch (e) {
      console.log(e)
      res.status(500).send(e)

    }
  }



}



module.exports = ApiService;