const jwt = require('jsonwebtoken');
const passport = require('passport')
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

      const mockReturn = [{
        ID: 0,
        Name: "trompete",
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
      }]

      var result = {}
      for (const instrument of mockReturn) {
        console.log(instrument)
      }
      res.send(mockReturn)

    } catch (e) {
      res.status(500).send(e)
    }
  }


  async getCustomer() {
    const result = await axios.get('http://localhost:3002/api/values')
    console.log(result)
    const mockReturn = [{
      id: 0,
      prename: "Nico",
      surname: "Köppe",
      adress: {
        street: "fucking-awesome",
        nr: 69,
        plz: 42069,
        city: "siiick"


      },
      tarif: 2,
      borrowed: 4,
      overdue: 1
    }]
    return mockReturn
  }



}



module.exports = ApiService;