<?php

if(isset($_POST))
{ 
    require_once 'Conn.php';
    
    //Select Item
    if($_POST['RequestType'] == "select")
    {
        $id = "";
        if(isset($_POST['id'])) $id=$_POST['id'];
        $items = array();

        if($id == "")
        {
            $statment = "SELECT * FROM items";
        }
        else
        {
            $statment = "SELECT * FROM items WHERE id = '$id' ";
        }
        $base = $conn->prepare($statment);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);
    

        if ($data>0)
        {
            while($data)
            {
                $items[] = $data;
                $data = $base -> fetch(PDO::FETCH_ASSOC);
            }
            echo json_encode($items);
        }
    
        else
        {
            echo "ERR: item not found!";
        }
    
    }


    #######################################################################################################################


    //update item
    if($_POST['RequestType'] == "update")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];
        
        $name = "";
        if(isset($_POST['name'])) $name = htmlspecialchars($_POST['name']);

        $price = "";
        if(isset($_POST['price'])) $price = $_POST['price'];
        
        $bugs = [];
        
        if($ID == "")
        {
            $bugs[] = "Id is empty! ";
        }
        if($name == "")
        {
            $bugs[] = "name is empty! ";
        }
        if($price == "")
        {
            $bugs[] = "price is empty! ";
        }
        if(empty($bugs))
        {
            $statement = "UPDATE items SET name = '$name', price = '$price' WHERE id = '$ID'";
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


    //Delete item
    if($_POST['RequestType'] == "delete")
    {
        $ID = $_POST['id'];    
    
        $statement = " DELETE FROM items WHERE id = '$ID' ";
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
    
    #######################################################################################################################


    //Insert item
    if($_POST['RequestType'] == "insert")
    {

        $name = "";
        if(isset($_POST['name'])) $name = htmlspecialchars($_POST['name']);
        $price = "";
        if(isset($_POST['price'])) $price = htmlspecialchars($_POST['price']);
        
        $bugs = [];
        if($name == "")
        {
            $bugs[]=" item name is empty! ";
        }
        if($price == "")
        {
            $bugs[]=" item price is empty! ";
        }
        if(empty($bugs))
        {
            $statement = "INSERT INTO items (name, price) VALUES ('$name', '$price')";
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