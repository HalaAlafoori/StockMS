<?php

if(isset($_POST))
{ 
    require_once 'Conn.php';
    
    //Select User
    if($_POST['RequestType'] == "select")
    {
        $name = "";
        if(isset($_POST['name'])) $name=$_POST['name'];
        $Users = array();

        if($name == "")
        {
            $statment = "SELECT * FROM users";
        }
        else
        {
            $statment = "SELECT * FROM users WHERE name = '$name' ";
        }
        $base = $conn->prepare($statment);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);
    

        if ($data>0)
        {
            while($data)
            {
                $Users[] = $data;
                $data = $base -> fetch(PDO::FETCH_ASSOC);
            }
            echo json_encode($Users);
        }
    
        else
        {
            echo "ERR: user not found!";
        }
    
    }


    #######################################################################################################################


    //update User
    if($_POST['RequestType'] == "update")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];
        
        $name = "";
        if(isset($_POST['name'])) $name = htmlspecialchars($_POST['name']);
        
        $password = "";
        if(isset($_POST['password'])) $password = htmlspecialchars($_POST['password']);

        $phone = "";
        if(isset($_POST['phone'])) $phone = htmlspecialchars($_POST['phone']);


        $isAdmin = "";
        if(isset($_POST['isAdmin'])) $isAdmin = htmlspecialchars($_POST['isAdmin']);
        
        $bugs = [];
        
        if($ID=="")
        {
        $bugs[]="Id is empty!";
        }
        
        if($name == "")
        {
            $bugs[]="User name is empty!";
        }

        // check if name is already exist // user name must not be repeated
        $statement = "SELECT name FROM users WHERE name = '$name' and id != '$ID'";
        $base = $conn->prepare($statement);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);

        if($data)
        {
            $bugs[] = "User name is used";
        }

        // password validation
        // if(strlen($password) < 6 && $password != "")
        // {
        //     $bugs[]="The password must be more than 6 characters";
        // }
    
        if(empty($bugs))
        {
            $statement = "UPDATE users SET name = '$name', password = '$password', is_admin = '$isAdmin', phone = '$phone' WHERE ID = '$ID' ";

            $update_sql = $conn->prepare($statement)->execute();
            if (!$update_sql)
            {
                echo "ERR: failed update";;
            }
            else
            {
                echo "1"; 
            }
            

        }

        else
        {
            echo "ERR: ";
            foreach ($bugs as $value) {
                echo $value;
            }
        }
    
    
    }

    #######################################################################################################################


    ////activate (status)
    if($_POST['RequestType'] == "activate")
    {
        $id = "";
        if(isset($_POST['id'])) $id = htmlspecialchars($_POST['id']);
        $bugs = [];
    

        if(empty($id))
        {
            $bugs[]="user id is empty! ";
        }
    
        $statement = "SELECT status FROM users WHERE id = '$id' ";
        $base = $conn->prepare($statement);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);

        if(!$data)
        {
            $bugs[] = "user doesn't exist! ";
        }
        else
        {
            if($data['status'] == "1") $status = 0;
            else $status = 1;
        }
        if(empty($bugs))
        {

            $statement = "UPDATE users SET status = $status WHERE id = '$id'";
            $update_sql = $conn->prepare($statement)->execute();
            if (!$update_sql)
            {
                echo "ERR: ";
            }
            else
            {
                echo "1"; 
            }
        }
        else
        {
            echo "ERR:";
            foreach ($bugs as $value) {
                echo $value;
            }
        }
    }

    
    #######################################################################################################################


    //Delete user
    if($_POST['RequestType'] == "delete")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];    
    
        if($ID != "")
        {
            $statement = " DELETE FROM users WHERE id = '$ID' ";
            $delete_sql = $conn->prepare($statement)->execute();

            if (!$delete_sql)
            {
                echo "ERR: delete failed";
            }
            else
            {
                echo "1"; 
            }
        }
        else{
            echo "ERR: ID is empty! ";
        }
    }


    #######################################################################################################################


    //Insert user
    if($_POST['RequestType'] == "insert")
    {

        $name = "";
        if(isset($_POST['name'])) $name = htmlspecialchars($_POST['name']);
        $password = "";
        if(isset($_POST['password'])) $password = htmlspecialchars($_POST['password']);
        
        $phone = "";
        if(isset($_POST['phone'])) $phone = htmlspecialchars($_POST['phone']);
        $isAdmin = "";
        if(isset($_POST['isAdmin'])) $isAdmin = htmlspecialchars($_POST['isAdmin']);
        
        $bugs = [];
        if($name == "")
        {
            $bugs[]=" user name is empty! ";
        }

        $stm = "SELECT name FROM users WHERE name = '$name' ";
        $base = $conn->prepare($stm);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);

        if($data)
        {
            $bugs[] = " User name is used ! ";
        }

        if($password == "")
        {
            $bugs[]=" password is empty! ";
        }

        if($phone == "")
        {
            $bugs[]=" phone is empty! ";
        }
        if($isAdmin == "")
        {
            $isAdmin = 0;
        }
        // elseif(strlen($password) < 6)
        // {
        //     $bugs[]="The password must be more than 6 characters ";
        // }

        if(empty($bugs))
        {
            $statement = "INSERT INTO users (name, password, phone, is_admin) VALUES ('$name', '$password', '$phone', '$isAdmin')";
            $sql = $conn->prepare($statement)->execute();
            
            if (!$sql)
            {
                echo "ERR: insert failed! ";
            }
            else
            {
                echo "1"; 
            }
        }

        else
        {
            echo "ERR:";
            foreach ($bugs as $value) {
                echo $value;
            }
        }

    }
}

else 
{
    echo "ERR: method must be post";
}

?>