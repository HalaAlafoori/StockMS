<?php

if(isset($_POST))
{ 
    require_once 'Conn.php';
    
    //Select login_out
    if($_POST['RequestType'] == "select")
    {
        $id = "";
        if(isset($_POST['id'])) $id=$_POST['id'];
        $login_out = array();

        if($id == "")
        {
            $statment = "SELECT * FROM login_out";
        }
        else
        {
            $statment = "SELECT * FROM login_out WHERE id = '$id' ";
        }
        $base = $conn->prepare($statment);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);
    
        if ($data>0)
        {
            while($data)
            {
                $login_out[] = $data;
                $data = $base -> fetch(PDO::FETCH_ASSOC);
            }
            echo json_encode($login_out);
        }
    
        else
        {
            echo "ERR: login_out not found!";
        }
    }
    
    #######################################################################################################################
    
    //update login_out
    if($_POST['RequestType'] == "update")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];
        $user_id = "";
        if(isset($_POST['user_id'])) $user_id = ($_POST['user_id']);
        $in_out = "";
        if(isset($_POST['in_out'])) $row_id = $_POST['in_out'];
        $date = "";
        if(isset($_POST['date'])) $date = $_POST['date'];

        if($ID != "")
        {
            $statement = 
                "   UPDATE login_out SET user_id = '$user_id', in_out = '$in_out', date = '$date' 
                    WHERE id = '$ID'";

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
            echo "ERR: ID is empty! ";
        }
    }
    
    #######################################################################################################################


    //Delete login_out
    if($_POST['RequestType'] == "delete")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id']; 
        if($ID != "")
        {
            $statement = " DELETE FROM login_out WHERE id = '$ID' ";
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


    //Insert login_out
    if($_POST['RequestType'] == "insert")
    {
        $user_id = "";
        if(isset($_POST['user_id'])) $user_id = ($_POST['user_id']);
        $in_out = "";
        if(isset($_POST['in_out'])) $in_out = $_POST['in_out'];
        $date = "";
        if(isset($_POST['date'])) $date = $_POST['date'];   
        
        $bugs = [];
        if($user_id == "")
        {
            $bugs[]=" user_id is empty! ";
        }
        if($in_out == "")
        {
            $bugs[]=" in_out is empty! ";
        }
        if($date == "")
        {
            $bugs[]=" date is empty! ";
        }
        
        if(empty($bugs))
        {
            $statement = 
                    "   INSERT INTO login_out (user_id, in_out, date)
                        VALUES ('$user_id', '$in_out', '$date')";
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