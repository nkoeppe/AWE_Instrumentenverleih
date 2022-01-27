var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');
var session = require('express-session');

var indexRouter = require('./routes/index');
var apiRouter = require('./routes/api');
const passport = require('passport');
const JwtStrategy = require('passport-jwt').Strategy,
  ExtractJwt = require('passport-jwt').ExtractJwt;

const SECRET = 'test_secret'

var app = express();

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({
  extended: false
}));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use(session({
  secret: 'SECRET',
  resave: true,
  saveUninitialized: true
}));
app.use(passport.initialize());
app.use(passport.session());



app.use('/', indexRouter);
app.use('/api', apiRouter);


const cookieExtractor = function(req) {
  let token = null;
  if (req && req.cookies && req.cookies['auth']) {
    token = req.cookies['auth'];
  } else if (req && req.headers && req.headers['auth']) {
    token = req.headers['auth']
  }
  return token;
};

const opts = {
  jwtFromRequest: ExtractJwt.fromExtractors([cookieExtractor]),
  secretOrKey: SECRET,
};

passport.use(
  'jwt',
  new JwtStrategy(opts, (jwt_payload, done) => {
    try {
      console.log('jwt_payload', jwt_payload);
      done(null, jwt_payload);
    } catch (err) {

      console.log(`err= ${err}`)
      done(err);
    }
  }),
);




// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  console.log(err)
  // render the error page
  res.status(err.status || 500);
  res.send(err)
});

module.exports = app;