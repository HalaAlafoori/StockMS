<?php

if(isset($_POST))
{ 
    require_once 'Conn.php';
    $username= htmlspecialchars($_POST['name']);
    $password = htmlspecialchars($_POST['password']);
    $bugs = [];

    if(empty($username))
    {
        $bugs[]="Name is required! ";
    }

    if(empty($password))
    {
        $bugs[]="Password is required!";
    }

    if(empty($bugs))
    {
        $statment = " select name , password  FROM users WHERE name  = '$username' and password = '" . Crypt(md5($password), sha1($password)) . "' ";
        $query = $conn->prepare($statment);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);

        if (!$data)
        {
            echo "Sorry, you are not registered yet";    }
        else
        {
            echo "1"; 
        }
    }
    else
    {
       echo $bugs; 
    }
}


else 
{
    echo "No data enterd!";
}

?>