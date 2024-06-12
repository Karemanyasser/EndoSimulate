<?php

$con = mysqli_connect(sql11.freesqldatabase.com, sql11702765, yG5V63x14g, endosimulate);

// check that connection happens
if (mysqli_connect_errno()) {
    echo "Connection Failed"; // error code #1 = connection failed
    exit();
}

$UserID = $_POST['UserID'];
$Password = $_POST['Password'];

//check if UserID exists
$UserIDcheckquery = "SELECT UserID, FirstName, LastName, score, Password FROM user WHERE UserID='" . mysqli_real_escape_string($con, $UserID) . "'";

$UserIDcheck = mysqli_query($con, $UserIDcheckquery) or die("UserID check failed"); // error code #2 UserID check query failed

if (mysqli_num_rows($UserIDcheck) != 1) {
    echo "UserID not found"; // error code #5 UserID not found or multiple users with the same UserID
    exit();
}

//get login info from query
$existinginfo = mysqli_fetch_assoc($UserIDcheck);

$DBPassword = $existinginfo["Password"];
if ($DBPassword != $Password) {
    echo "Incorrect Password"; //error code #6 incorrect Password
    exit();
}

// Login successful, return user information
echo "0\t" . $existinginfo["UserID"] . "\t" . $existinginfo["FirstName"] . "\t" . $existinginfo["LastName"] . "\t" . $existinginfo["score"];
?>
