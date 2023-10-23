<?php

if(isset($_POST))
{ 
    require_once 'Conn.php';
    
    //Select stock
    if($_POST['RequestType'] == "select")
    {
        $id = "";
        if(isset($_POST['id'])) $id=$_POST['id'];
        $stock = array();

        if($id == "")
        {
            $statment = "SELECT * FROM stock";
        }
        else
        {
            $statment = "SELECT * FROM stock WHERE id = '$id' ";
        }
        $base = $conn->prepare($statment);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);
    

        if ($data>0)
        {
            while($data)
            {
                $stock[] = $data;
                $data = $base -> fetch(PDO::FETCH_ASSOC);
            }
            echo json_encode($stock);
        }
    
        else
        {
            echo "ERR: stock not found!";
        }
    
    }


    #######################################################################################################################


    //update stock
    if($_POST['RequestType'] == "update")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];
        
        $name = "";
        if(isset($_POST['name'])) $name = htmlspecialchars($_POST['name']);

        $location = "";
        if(isset($_POST['location'])) $location = $_POST['location'];

        $bugs = [];
        
        if($ID == "")
        {
            $bugs[] = "Id is empty! ";
        }
        if($name == "")
        {
            $bugs[] = "name is empty! ";
        }
        if($location == "")
        {
            $bugs[] = "location is empty! ";
        }
        if(empty($bugs))
        {
            $statement = "UPDATE stock SET name = '$name',  location = '$location' WHERE id = '$ID'";

            $update_sql = $conn->prepare($statement)->execute();
            if (!$update_sql)
            {
                echo "ERR: update failed! ";;
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


    //Delete stock
    if($_POST['RequestType'] == "delete")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];    
        if($ID != "")
        {
            $statement = " DELETE FROM stock WHERE id = '$ID' ";
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


    //Insert stock
    if($_POST['RequestType'] == "insert")
    {
        $name = "";
        if(isset($_POST['name'])) $name = htmlspecialchars($_POST['name']);
        $location = "";
        if(isset($_POST['location'])) $location = htmlspecialchars($_POST['location']);
        
        $bugs = [];
        if($name == "")
        {
            $bugs[]=" stock name is empty! ";
        }
        if($location == "")
        {
            $bugs[]=" stock location is empty! ";
        }
        
        if(empty($bugs))
        {
            $statement = "INSERT INTO stock (name, location) VALUES ('$name', '$location')";
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