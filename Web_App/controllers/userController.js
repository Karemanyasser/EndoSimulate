const connection = require('../DataBase/connection'); // Import the connection module 

//=========================================================================================
function registerUser(req, res) {
    const {
      Gender,
      FirstName,
      LastName,
      Age,
      UserID,
      University,
      AcademicYear,
      Username,
      Password,
    } = req.body;
  
    // Check if UserID or Username already exist  (must unqiue username & UserID)
    const checkDuplicateQuery = `SELECT * FROM user WHERE Username = ? OR UserID = ?`;
    connection.query(checkDuplicateQuery, [Username, UserID], (checkDuplicateErr, duplicateResult) => {
      if (checkDuplicateErr) {
        console.error("Error checking for existing UserID and Username:", checkDuplicateErr);
        res.status(500).json({ error: "Internal Server Error, Check if UserID and Username exist in user table" });
        return;
      }
  
      if (duplicateResult.length > 0) {
        // If UserID or Username already exists, handle the error
        const existingUserID = duplicateResult.find(user => user.UserID === UserID);
        const existingUsername = duplicateResult.find(user => user.Username === Username);
  
        if (existingUserID) {
          console.log("UserID already exists");
          res.status(400).json({ error: "UserID already exists" });
          return;
        }

        if (existingUsername) {
          console.log("Username already exists");
          res.status(400).json({ error: "Username already exists" });
          return;
        }
      }
  
      // Insert into user table
      const insertUserQuery = `INSERT INTO user ( FirstName, LastName, Age, University, AcademicYear, Gender , UserID, Username, Password) 
                                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)`;
      connection.query(insertUserQuery, [FirstName, LastName, Age, University, AcademicYear, Gender , UserID, Username, Password], (insertErr, insertResult) => {
        if (insertErr) {
          console.error("Error creating user:", insertErr);
          res.status(500).json({ error: "Internal Server Error, Failed to register user" });
          return;
        }
  
        console.log("New user registered with UserID:", insertResult.insertId);
        res.status(200).json({ message: "User registered successfully" });
      });
    });
  }
//===============================================================================================
function loginUser(req, res) {
  const { Username, Password } = req.body;

  // Check if Username exists
  const checkUserQuery = `SELECT * FROM user WHERE Username = ?`;
  connection.query(checkUserQuery, [Username], (checkUserErr, userResult) => {
    if (checkUserErr) {
      console.error("Error checking for existing Username:", checkUserErr);
      res.status(500).json({ error: "Internal Server Error, Check if Username exists in user table" });
      return;
    }

    if (userResult.length === 0) {
      // If Username does not exist, handle the error
      console.log("Username does not exist");
      res.status(400).json({ error: "Invalid Username" });
      return;
    }

    const user = userResult[0];

    // Check if Password matches
    if (Password !== user.Password) {
      console.log("Incorrect Password");
      res.status(400).json({ error: "Incorrect Password" });
      return;
    }

    // Login successful
    console.log("Username logged in:", user.Username);
    console.log("UserID logged in:", user.UserID);

    // Send back the UserID along with the message
    res.status(200).json({ message: "Login successful", user });
  });
}

//====================================================================================================
function updatePassByusername(req, res) {
  
    // Extract updated information from the request body
    const { Username, Password } = req.body;
  
    // Check if Username exists in the database
    const sql_query = 'SELECT * FROM user WHERE Username = ?';
    connection.query(sql_query, [Username], (err, result) => {
        if (err) {
            console.error("Error checking for existing Username:", checkUserErr);
            res.status(500).json({ error: "Internal Server Error, Check if Username exists in user table" });
            return;
        }
        if (result.length === 0) {
            res.status(404).json({ message: `No users found for user with username ${Username}.` });
        } else {
            // Execute the update query
            const update_query = `
              UPDATE user
              SET Password = ?
              WHERE Username = ?`;
            connection.query(update_query, [Password, Username], (err, updateResult) => {
                if (err) {
                    console.error("Error updating user data:", err);
                    res.status(500).json({ error: "Internal Server Error" });
                    return;
                }
                console.error(`user with username:  ${Username} updated successfully.`);
                res.status(200).json({ message: `user with username:  ${Username} updated successfully.` });
            });
        }
    });
  }


//===============================================================================================
function getUser(req, res) {
  const { Username } = req.body;

  // Check if Username exists
  const checkUserQuery = `SELECT * FROM user WHERE Username = ?`;
  connection.query(checkUserQuery, [Username], (checkUserErr, userResult) => {
    if (checkUserErr) {
      console.error("Error checking for existing Username:", checkUserErr);
      res.status(500).json({ error: "Internal Server Error, Check if Username exists in user table" });
      return;
    }

    if (userResult.length === 0) {
      // If Username does not exist, handle the error
      console.log("Username does not exist");
      res.status(400).json({ error: "Invalid Username" });
      return;
    }

    const user = userResult[0];


    // Send back the UserID along with the message
    res.status(200).json(user);
  });
}
//=================================================================================================================
module.exports = {
    registerUser,
    loginUser,
    updatePassByusername,
    getUser,
};