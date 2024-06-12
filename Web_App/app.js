const express = require('express');
const dotenv = require('dotenv');

dotenv.config(); // Load environment variables from .env file

const connectionModule = require('./DataBase/connection');
const UserRoute = require('./routes/userRouter');

const app = express();
const PORT = 5000;

//====================================================================
app.listen(PORT, () => {
  console.log(`SERVER: http://localhost:${PORT}`);
  connectionModule.connect((err) => {
    if (err) throw err; 
    console.log('DATABASE CONNECTED');
  });
});

//====================================================================
app.use(express.json());
app.use('/', UserRoute);
app.use(express.static('public'));