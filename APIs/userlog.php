<?php

if(isset($_POST))
{ 
    require_once 'Conn.php';
    
    //Select user_log
    if($_POST['RequestType'] == "select")
    {
        $id = "";
        if(isset($_POST['id'])) $id=$_POST['id'];
        $user_log = array();

        if($id == "")
        {
            $statment = "SELECT * FROM user_log";
        }
        else
        {
            $statment = "SELECT * FROM user_log WHERE id = '$id' ";
        }
        $base = $conn->prepare($statment);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);
    
        if ($data>0)
        {
            while($data)
            {
                $user_log[] = $data;
                $data = $base -> fetch(PDO::FETCH_ASSOC);
            }
            echo json_encode($user_log);
        }
    
        else
        {
            echo "ERR: user_log not found!";
        }
    }
    
    #######################################################################################################################
    
    //update user_log
    if($_POST['RequestType'] == "update")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];
        $user_id = "";
        if(isset($_POST['user_id'])) $user_id = ($_POST['user_id']);
        $row_id = "";
        if(isset($_POST['row_id'])) $row_id = $_POST['row_id'];
        $table_name = "";
        if(isset($_POST['table_name'])) $table_name = $_POST['table_name'];
        $type = "";
        if(isset($_POST['type'])) $type = $_POST['type'];
        $date = "";
        if(isset($_POST['date'])) $date = $_POST['date'];

        if($ID != "")
        {
            $statement = 
                "   UPDATE user_log SET user_id = '$user_id', row_id = '$row_id',
                    table_name = '$table_name', type = '$type', date = '$date'
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


    //Delete user_log
    if($_POST['RequestType'] == "delete")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];    
        if($ID != "")
        {
            $statement = " DELETE FROM user_log WHERE id = '$ID' ";
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


    //Insert user_log
    if($_POST['RequestType'] == "insert")
    {
        $item_id = "";
        if(isset($_POST['item_id'])) $item_id = htmlspecialchars($_POST['item_id']);
        $user_id = "";
        if(isset($_POST['user_id'])) $user_id = ($_POST['user_id']);
        $row_id = "";
        if(isset($_POST['row_id'])) $row_id = $_POST['row_id'];
        $table_name = "";
        if(isset($_POST['table_name'])) $table_name = $_POST['table_name'];
        $type = "";
        if(isset($_POST['type'])) $type = $_POST['type'];
        $date = "";
        if(isset($_POST['date'])) $date = $_POST['date'];
        
        $bugs = [];
        if($item_id == "")
        {
            $bugs[]=" item_id is empty! ";
        }
        if($user_id == "")
        {
            $bugs[]=" user_id is empty! ";
        }
        if($row_id == "")
        {
            $bugs[]=" row_id is empty! ";
        }
        if($table_name == "")
        {
            $bugs[]=" table_name is empty! ";
        }
        if($type == "")
        {
            $bugs[]=" type is empty! ";
        }
        if($date == "")
        {
            $bugs[]=" date is empty! ";
        }
        if(empty($bugs))
        {
            $statement = 
                    "   INSERT INTO user_log (user_id, row_id, table_name, type, date)
                        VALUES ('$user_id', '$row_id', '$table_name', '$type', '$date')";
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