const express = require('express');
const router = express.Router();

const userController = require("../controllers/userController");

//===================================================================================================
router.post("/registration", userController.registerUser);                // POST New patient
router.post("/login", userController.loginUser);                   // login 
router.put("/updatepass", userController.updatePassByusername);                   // update password in case forgot pass 
router.post("/getuser/:username", userController.getUser);
//===================================================================================================

module.exports =  router;      // Export the 'router' object