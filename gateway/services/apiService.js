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

    const mockReturn = [{
      id: 0,
      name: "trompete",
      borrowed: 6,
      available: 14,
      price: 69.99
    }, {
      id: 1,
      name: "tuba",
      borrowed: 1,
      available: 23,
      price: 42.00
    }, {
      id: 3,
      name: "schlagzeug",
      borrowed: 9,
      available: 3,
      price: 199.69
    }]
    res.send(mockReturn)
  }


  getCustomer() {

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