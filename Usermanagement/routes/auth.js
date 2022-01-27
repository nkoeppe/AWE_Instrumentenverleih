var express = require('express');
var router = express.Router();
var AuthService = require('../src/authService');
let service = new AuthService();



/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});



module.exports = router;