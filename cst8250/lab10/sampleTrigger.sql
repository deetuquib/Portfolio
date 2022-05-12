drop trigger trgCheckInventory;
DELIMITER $$

CREATE TRIGGER trgCheckInventory BEFORE INSERT ON order_lines
FOR EACH ROW
BEGIN
DECLARE onhand INT;
DECLARE allocated INT;
DECLARE available INT;
SELECT inventory INTO onhand FROM products WHERE products.id = NEW.product_id;

SELECT sum(qty) into allocated FROM allocations WHERE 
			allocations.product_id = NEW.product_id;
IF allocated IS NULL THEN 
	SET allocated := 0;
END IF;

SET available :=(onhand-allocated);
-- signal sqlstate '45000'	set message_text = available;
IF available < NEW.qty  THEN
	signal sqlstate '45000'	set message_text = "INSUFFICIENT INVENTORY";
END IF;

END;$$

DELIMITER ;


 drop trigger trgCheckInventory;
DELIMITER $$

CREATE TRIGGER trgAllocateInventory AFTER INSERT ON order_lines
FOR EACH ROW
BEGIN
INSERT INTO allocations (order_line_id,qty,product_id)
VALUES (NEW.id,NEW.qty,NEW.product_id);

END;$$

DELIMITER ;

drop trigger trgOrderShipped;
DELIMITER $$

CREATE TRIGGER trgOrderShipped AFTER UPDATE ON orders
FOR EACH ROW
BEGIN
DECLARE vproduct_id INT;
DECLARE vorder_line_id INT;
DECLARE exit_loop BOOLEAN;
DECLARE allocated INT;
DECLARE available INT;
DECLARE vnew_available INT;

DECLARE allocationCursor CURSOR FOR
      select id, product_id from order_lines 
		where order_id=NEW.id;
        
DECLARE CONTINUE HANDLER FOR NOT FOUND SET exit_loop = TRUE;


OPEN allocationCursor;

allocation_loop: LOOP
	FETCH allocationCursor INTO vorder_line_id, vproduct_id;
    
    if exit_loop THEN
		CLOSE allocationCursor;
        LEAVE allocation_loop;
    END IF;

	select qty into allocated from allocations 
          where allocations.order_line_id=vorder_line_id;
          
	select inventory into available from products where products.id =
    (SELECT product_id from order_lines where id=vorder_line_id);
    
   # signal sqlstate '45000'	set message_text = vproduct_id;
    
    SET vnew_available := available - allocated;
   
    update products set inventory = vnew_available where products.id=(SELECT product_id from order_lines where id=vorder_line_id);
    
    delete from allocations where allocations.order_line_id=vorder_line_id;
   
END LOOP allocation_loop;  

END;$$

DELIMITER ;