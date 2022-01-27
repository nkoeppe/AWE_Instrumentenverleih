var express = require('express');
var router = express.Router();
var apiService = require('../services/apiService');
var service = new apiService();
const passport = require('passport')


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








router.post('/authenticate', function(req, res, next) {

  try {
    const {
      user,
      passwd
    } = req.body
    if (user === undefined || passwd === undefined) throw "user or password is undefined"
    console.log(`user: ${user} wants to authenticate with password: ${passwd}`)

    const id = 1


    if (user === "nico") {
      if (passwd === "asdf") {

        console.log("user and password correct ")
        const token = jwt.sign({
          id: id,
          name: user
        }, SECRET, {
          expiresIn: 60 * 60,
        });
        res.cookie('auth', token, {
          httpOnly: true
        });
        res.send("authenticate successful")

      } else {
        console.log("passwd wrong")
      }
    } else {
      console.log("user wrong")
    }


  } catch (e) {
    console.log(e)
    res.status(500).send(e)
  }
})

router.get('/instruments', passport.authenticate('jwt', {
    session: false
  }),
  (...args) => service.getInstruments(...args));


router.get('/customer', function(req, res, next) {
  try {
    const ret = service.getCustomer();
    res.send(ret)
  } catch (e) {
    console.log(e)
    res.status(500).send(e)
  }
})



module.exports = router;