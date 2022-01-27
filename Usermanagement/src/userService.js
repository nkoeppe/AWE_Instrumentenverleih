/** @module userService  */

var mysql = require('mysql2/promise');


let client;

class UserService {
  constructor() {

  }

  async connectDatabase() {
    client = await mysql.createConnection({
      host: '127.0.0.1',
      user: 'root',
      password: '',
      database: 'usermanagement',
      port: 3306
    });
    //
    // client.connect(function(err) {
    // 	if (err) console.log(err);
    // 	console.log('Connected!');
    // });
  }

  async disconnectDatabase() {
    client.end();
  }
  async default () {
    try {
      if (true) return `API up an running ${client}`;

    } catch (e) {
      return e;
    }
  }

  async functionWrapper(next, args) {
    try {
      await this.connectDatabase();
      const result = await next(args);
      await this.disconnectDatabase();
      return result;

    } catch (e) {

      await this.disconnectDatabase();
      throw e;
    } finally {

    }
  }

  async getAllUser({
    that
  }) {
    try {
      var sql = 'SELECT * from user';
      let [rows] = await client.execute(sql);
      // rows = await Promise.all(rows.map(async (row) => {
      //
      //   row['roles'] = await that.getRoleForUser({
      //     id: row.ID,
      //     that: that
      //   });
      //   return row;
      // }));
      return {
        rows
      };
    } catch (e) {
      console.log(e);
      throw e;
    }
  }

  validateUser(request, user) {

    if (request.username === user.username && request.password === user.password) {
      return true;
    } else {
      return false
    }
  }

  async getUserByName({
    user,
    that
  }) {
    try {
      var sql = `SELECT * from user WHERE username = '${user}' LIMIT 1`;
      let [rows] = await client.execute(sql);
      user = rows[0]
      return user

    } catch (e) {
      console.log(e);
      return e;
    }
  }
  async getSingleUser({
    id,
    that
  }) {
    try {
      var sql = `SELECT * from user WHERE ID = ${id}`;
      let [rows] = await client.execute(sql);
      // rows = await Promise.all(rows.map(async (row) => {
      //
      //   row['roles'] = await that.getRoleForUser({
      //     id: row.ID,
      //     that: that
      //   });
      //   return row;
      // }));
      if (true) return {
        rows
      };

    } catch (e) {
      console.log(e);
      return e;
    }
  }


  async createUser({
    username,
    password,
    roleID = 1, //Default Role: Guest
    that
  }) {
    try {
      const sqlUser = `INSERT INTO user (username, password) VALUES ('${username}', '${password}')`;

      let result = await client.execute(sqlUser);
      const userID = result[0].insertId;
      const sqlUserRole = `INSERT INTO user_roles (user_id, role_id) VALUES ('${userID}','${roleID}')`;

      result = await client.execute(sqlUserRole);
      return {
        success: true
      };

    } catch (e) {
      console.log(e);
      return {
        success: false,
        error: e
      };
    }
  }


  async getRoleForUser({
    id,
    that
  }) {
    try {
      var sql = `SELECT * from user_roles WHERE user_id = ${id}`;
      let [rows] = await client.execute(sql);
      rows = await Promise.all(rows.map(async (item) => {
        const role = await that.getSingleRole({
          id: item.role_id,
          that: that
        });
        return role;
      }));
      return rows;

    } catch (e) {
      console.log(e);
      throw e;
    }
  }

  async getPermissionsForRole({
    id,
    that
  }) {
    try {

      // console.log(id);
      var sql = `SELECT * from role_permissions WHERE role_id = ${id}`;
      // console.log(sql);
      let [rows] = await client.execute(sql);
      rows = await Promise.all(rows.map(async (item) => {
        return (({
          name,
          ...description
        }) => (
          name
        ))(await that.getSinglePermission({
          id: item.permission_id
        }));
      }));
      // console.log(rows);
      // console.log(rows);
      return rows;

    } catch (e) {
      console.log(e);
      throw e;
    }
  }

  async getAllRoles({
    that
  }) {
    try {
      var sql = 'SELECT * from role';
      let [rows] = await client.execute(sql);
      rows = await Promise.all(rows.map(async (row) => {

        const t = await that.getPermissionsForRole({
          id: row.ID,
          that: that
        });
        row['permissions'] = t;
        console.log(row);
        return row;
      }));
      return rows;

    } catch (e) {
      console.log(e);
      throw e;
    }
  }


  async getSingleRole({
    id,
    that
  }) {
    try {
      var sql = `SELECT * from role WHERE ID = ${id}`;
      let [rows] = await client.execute(sql);
      rows = await Promise.all(rows.map(async (row) => {
        const t = await that.getPermissionsForRole({
          id: row.ID,
          that: that
        });
        row['permissions'] = t;
        return row;
      }));
      return rows;


    } catch (e) {
      console.log(e);
      return e;
    }
  }

  async getAllRolePermissions() {
    try {
      var sql = 'SELECT * from role_permissions';
      let [rows] = await client.execute(sql);
      return {
        rows
      };
    } catch (e) {
      console.log(e);
      throw e;
    }
  }


  async getAllPermissions() {
    try {
      var sql = 'SELECT * from permissions';
      let [rows] = await client.execute(sql);
      return {
        rows
      };
    } catch (e) {
      console.log(e);
      throw e;
    }
  }


  async getSinglePermission({
    id
  }) {
    try {
      let [rows] = await client.execute(`SELECT * from permissions WHERE ID = ${id}`);

      return rows[0];

    } catch (e) {
      return e;
    }
  }


}

module.exports = UserService;