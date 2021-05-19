<?php
    include_once 'dbh.inc.php';

    $clientID = $_POST['clientID'];
    $CBName = $_POST['Name'];
    $rating = $_POST['rating'];

    $sql = "INSERT INTO clientsatisfaction (clientID, CBName, Rating) VALUES ('$clientID', '$CBName', '$rating');";

    mysqli_query($conn, $sql);


    header("Location: ../index.php?rating=success");