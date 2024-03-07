<?php
// example of update actor table, all first_name ADAM will be updated to CHRIS
$servername = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Databse connected successfully, username " . $username . "<br><br>";
$sql = "CREATE TABLE Persons (
    PersonID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
);";
$conn->query($sql);
echo "Table actor updated – all ADAM to CHRIS";
$conn->close();
?>