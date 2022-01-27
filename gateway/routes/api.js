var express = require('express');
var router = express.Router();
var apiService = require('../services/apiService');
var service = new apiService();
const passport = require('passport')
const axios = require('axios');

//const cookieParser = require('cookie-parser');



/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

router.post('/checkToken', function(req, res, next) {


})




//router.get('/greetme', (...args) => service.checkAuth(...args), service.greet);
router.get('/greetme', passport.authenticate('jwt', {
  session: false
}), (...args) => service.greet(...args));








router.post('/authenticate', async function(req, res, next) {

  try {

    const result = await axios.post('http://localhost:3001/users/authenticate', req.body)
    var token = null
    for (const cookie of result.headers["set-cookie"]) {
      if (cookie.startsWith("auth")) {

        token = cookie.split(";")[0].split("=")[1]
        //token = cookie.substr(5)
      }
    }
    res.cookie('auth', token, {
      httpOnly: true
    });
    res.send(token)

  } catch (e) {
    console.log(e)
    res.status(401).send("Unauthorized")
  }
})

router.get('/instruments', passport.authenticate('jwt', {
    session: false
  }),
  (...args) => service.getInstruments(...args));

router.get('/customer', passport.authenticate('jwt', {
    session: false
  }),
  (...args) => service.getCustomer(...args));




module.exports = router;