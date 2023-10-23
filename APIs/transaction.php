<?php

if(isset($_POST))
{ 
    require_once 'Conn.php';
    
    //Select transactions
    if($_POST['RequestType'] == "select")
    {
        $id = "";
        if(isset($_POST['id'])) $id=$_POST['id'];
        $transactions = array();

        if($id == "")
        {
            $statment = "SELECT * FROM transactions";
        }
        else
        {
            $statment = "SELECT * FROM transactions WHERE id = '$id' ";
        }
        $base = $conn->prepare($statment);
        $base -> execute();
        $data = $base -> fetch(PDO::FETCH_ASSOC);
    
        if ($data>0)
        {
            while($data)
            {
                $transactions[] = $data;
                $data = $base -> fetch(PDO::FETCH_ASSOC);
            }
            echo json_encode($transactions);
        }
    
        else
        {
            echo "ERR: transactions not found!";
        }
    
    }
    
    #######################################################################################################################
    
    //update transactions
    if($_POST['RequestType'] == "update")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];
        $item_id = "";
        if(isset($_POST['item_id'])) $item_id = htmlspecialchars($_POST['item_id']);
        $stock_id = "";
        if(isset($_POST['stock_id'])) $stock_id = $_POST['stock_id'];
        $date = "";
        if(isset($_POST['date'])) $date = $_POST['date'];
        $quantity = "";
        if(isset($_POST['quantity'])) $quantity = $_POST['quantity'];
        $type = "";
        if(isset($_POST['type'])) $type = $_POST['type'];
        $details = "";
        if(isset($_POST['details'])) $details = $_POST['details'];

        $bugs = [];
        if($item_id == "")
        {
            $bugs[] = "item_id is empty! ";
        }
        if($stock_id == "")
        {
            $bugs[] = "stock_id is empty! ";
        }
        if($date == "")
        {
            $bugs[] = "date is empty! ";
        }
        if($quantity == "")
        {
            $bugs[] = "quantity is empty! ";
        }
        if($type == "")
        {
            $bugs[] = "type is empty! ";
        }
        if($details == "")
        {
            $bugs[] = "details is empty! ";
        }
        if(empty($bugs))
        {
            // print('item_id'.$item_id);
            // print('stock_id'.$stock_id);
            // print('date'.$date);
            // print('quantity'.$quantity);
            // print('type'.$type);
            // print('details'.$details);
            $statement = 
                "   UPDATE transactions SET item_id = '$item_id', stock_id = '$stock_id', date = '$date', 
                    quantity = '$quantity', type = '$type', details = '$details'
                    WHERE id = '$ID'";
                    
            $update_sql = $conn->prepare($statement)->execute();
            if (!$update_sql)
            {
                echo "ERR: update failed! ";
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


    //Delete transactions
    if($_POST['RequestType'] == "delete")
    {
        $ID = "";
        if(isset($_POST['id'])) $ID = $_POST['id'];    
        if($ID != "")
        {
            $statement = " DELETE FROM transactions WHERE id = '$ID' ";
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


    //Insert transactions
    if($_POST['RequestType'] == "insert")
    {
        $item_id = "";
        if(isset($_POST['item_id'])) $item_id = ($_POST['item_id']);
        $stock_id = "";
        if(isset($_POST['stock_id'])) $stock_id = $_POST['stock_id'];
        $date = "";
        if(isset($_POST['date'])) $date = $_POST['date'];
        $quantity = "";
        if(isset($_POST['quantity'])) $quantity = $_POST['quantity'];
        $type = "";
        if(isset($_POST['type'])) $type = $_POST['type'];
        $details = "";
        if(isset($_POST['details'])) $details = htmlspecialchars($_POST['details']);
        
        $bugs = [];
        if($item_id == "")
        {
            $bugs[] = "item_id is empty! ";
        }
        if($stock_id == "")
        {
            $bugs[] = "stock_id is empty! ";
        }
        if($date == "")
        {
            $bugs[] = "date is empty! ";
        }
        if($quantity == "")
        {
            $bugs[] = "quantity is empty! ";
        }
        if($type == "")
        {
            $bugs[] = "type is empty! ";
        }
        if($details == "")
        {
            $bugs[] = "details is empty! ";
        }
        
        if(empty($bugs))
        {
            $statement = 
                    "   INSERT INTO transactions (item_id, stock_id, date, quantity, type, details) 
                        VALUES ('$item_id', '$stock_id', 'date', '$quantity', '$type', '$details')";
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