var express = require('express');
var UserService = require('../src/userService');
var router = express.Router();
let service = new UserService();
/* GET users listing. */

router.get('/', async function(req, res, next) {
  // res.send('User - API up and running');
  try {
    res.status(200).send(await service.default());
  } catch (e) {
    res.status(500).send(e);
  }
});

router.post('/authenticate', function(req, res, next) {
  try {

    const {
      user,
      password
    } = req.body

    if (user === undefined || password === undefined) throw "email or password is undefined"


    // const ret = service.authenticate()
    // 
    res.send(ret);

  } catch (e) {
    console.error(e);
    res.status(500).send(e)
  }
});

router.get('/user', async function(req, res, next) {
  try {
    const user = await service.functionWrapper(service.getAllUser, {
      that: service
    });
    res.status(200).send(user);
  } catch (e) {
    console.log(e);
    res.status(500).send(e);
  }
});

router.post('/user', async (req, res) => {
  ({
    username,
    password,
    roleID,
    personID
  } = req.body);
  try {

    const user = await service.functionWrapper(service.createUser, {
      username: username,
      password: password,
      roleID: roleID,
      that: service
    });

    res.status(200).send(user);
  } catch (e) {
    res.status(500).send(e);
  }
});

router.get('/user/:id', async function(req, res, next) {
  try {
    var id = req.params.id;
    const user = await service.functionWrapper(service.getSingleUser, {
      id: id,
      that: service
    });
    res.status(200).send(user);
  } catch (e) {
    console.log(e);
    res.status(500).send(e);
  }
});


router.get('/getRole', async function(req, res, next) {
  try {
    const roles = await service.functionWrapper(service.getAllRoles, {
      that: service
    });

    res.status(200).send(roles);
  } catch (e) {
    console.log(e);
    res.status(500).send(e);
  }
});

router.get('/getRole/:id', async function(req, res, next) {
  try {
    var id = req.params.id;
    const role = await service.functionWrapper(service.getSingleRole, {
      id: id,
      that: service
    });
    res.status(200).send(role);
  } catch (e) {
    console.log(e);
    res.status(500).send(e);
  }
});


router.get('/getPermission', async function(req, res, next) {
  try {
    const permissions = await service.functionWrapper(service.getAllPermissions);
    res.status(200).send(permissions);
  } catch (e) {
    console.log(e);
    res.status(500).send(e);
  }
});

router.get('/getPermission/:id', async function(req, res, next) {
  try {
    var id = req.params.id;
    const permission = await service.functionWrapper(service.getSinglePermission, {
      id: id
    });
    res.status(200).send(permission);
  } catch (e) {
    console.log(e);
    res.status(500).send(e);
  }
});


router.get('/getRowPermission', async function(req, res, next) {
  try {
    const role_permission = await service.functionWrapper(service.getPermissionsForRole, {
      id: 4,
      that: service
    });
    res.status(200).send(role_permission);
  } catch (e) {
    console.log(e);
    res.status(500).send(e);
  }
}.bind(this));


module.exports = router;