namespace MiniStore.Modules.PurchaseOrder.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PurchaseOrderSqlProvider
    {
        public const string INSERT_ORDER = @"
    INSERT INTO purchase_orders (
        code, supplier_id, order_date, expected_date, 
        total_amount, status, note, payment_method, created_at, updated_at
    )
    VALUES (
        @Code, @SupplierId, @OrderDate, @ExpectedDate, 
        @TotalAmount, @Status, @Note, @PaymentMethod, NOW(), NOW()
    );
    SELECT LAST_INSERT_ID();
";

        public const string UPDATE_ORDER = @"
    UPDATE purchase_orders
    SET
        code = @Code,
        supplier_id = @SupplierId,
        order_date = @OrderDate,
        expected_date = @ExpectedDate,
        total_amount = @TotalAmount,
        status = @Status,
        note = @Note,
        payment_method = @PaymentMethod, -- Thêm trường mới
        updated_at = NOW()
    WHERE
        id = @Id;
";

        public const string GET_ORDER_BY_ID = @"
    SELECT
        id, code, supplier_id, order_date, expected_date, 
        total_amount, status, note, payment_method, created_at, updated_at
    FROM purchase_orders
    WHERE id = @Id;
";

        public const string GET_ALL_ORDERS = @"
    SELECT
        po.id, po.code, po.supplier_id, po.order_date, po.expected_date, 
        po.total_amount, po.status, po.note, po.payment_method, po.created_at, po.updated_at,
        

        s.name AS supplier_name 
        
    FROM 
        purchase_orders po
    LEFT JOIN 
        Suppliers s ON po.supplier_id = s.id
    ORDER BY 
        po.order_date DESC;
";

        public const string UPDATE_ORDER_STATUS = @"
        UPDATE purchase_orders
        SET
            status = @Status,
            updated_at = NOW()
        WHERE
            id = @Id;
    ";

        public const string INSERT_ITEM = @"
        INSERT INTO purchase_order_items (
            purchase_order_id, product_id, quantity, unit_price, discount, total_price
        )
        VALUES (
            @PurchaseOrderId, @ProductId, @Quantity, @UnitPrice, @Discount, 
            @Quantity * @UnitPrice * (1 - @Discount / 100) -- Tự tính total_price
        );
        SELECT LAST_INSERT_ID();
    ";

        public const string DELETE_ITEMS_BY_ORDER_ID = @"
        DELETE FROM purchase_order_items
        WHERE purchase_order_id = @PurchaseOrderId;
    ";

        public const string GET_ITEMS_BY_ORDER_ID = @"
        SELECT
            id, purchase_order_id, product_id, quantity, unit_price, discount, total_price
        FROM purchase_order_items
        WHERE purchase_order_id = @PurchaseOrderId;
    ";
    }
}
