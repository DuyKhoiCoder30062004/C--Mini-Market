namespace MiniStore.Modules.SupplierManager.DAL
{
    public class SupplierSqlProvider
    {
       
        public const string INSERT_SUPPLIER = @"
            INSERT INTO Suppliers (name, phone, contact, address, email, status, created_at, updated_at)
            VALUES (@Name, @Phone, @ContactPerson, @Address, @Email, @Status, NOW(), NULL);
            SELECT LAST_INSERT_ID();";

       
        public const string UPDATE_SUPPLIER = @"
            UPDATE Suppliers
            SET
                name = @Name,
                phone = @Phone,
                contact = @ContactPerson,
                address = @Address,
                email = @Email,
                status = @Status,
                updated_at = NOW()
            WHERE
                id = @Id;
        ";

       
        public const string DELETE_SUPPLIER = @"
            UPDATE Suppliers
            SET 
                status = 'Deleted',
                updated_at = NOW()
            WHERE 
                id = @Id;
        ";

        
        public const string GET_SUPPLIER_BY_ID = @"
            SELECT
                id, name, phone, contact, address, email, status, created_at, updated_at
            FROM Suppliers
            WHERE id = @Id;
        ";

        public const string GET_SUPPLIER_BY_PhONE = @"
            SELECT
                id, name, phone, contact, address, email, status, created_at, updated_at
            FROM Suppliers
            WHERE phone = @Phone;
        ";

        public const string SEARCH_BY_NAME_OR_PHONE = @"
        SELECT * FROM Suppliers 
        WHERE 
            (name LIKE @SearchTerm OR phone LIKE @SearchTerm)
            AND status != 'Deleted';";
        public const string RESTORE_SUPPLIER_BY_ID = @"
        UPDATE Suppliers 
        SET 
            status = 'Active', 
            updated_at = NOW() 
        WHERE 
            id = @id;";

        public const string GET_ALL_SUPPLIERS = @"
            SELECT
                id, name, phone, contact, address, email, status, created_at, updated_at
            FROM Suppliers
           
            ORDER BY name;
        ";
    }
}