namespace MiniStore.Modules.SupplierManager.DAL
{
        public class SupplierSqlProvider
    {
                public const string INSERT_SUPPLIER = @"
    INSERT INTO Suppliers (supplier_name, contact_person, phone_number, email, address)
    VALUES (@SupplierName, @ContactPerson, @PhoneNumber, @Email, @Address);
    SELECT last_insert_rowid();";

                public const string UPDATE_SUPPLIER = @"
        UPDATE Suppliers
        SET
            supplier_name = @SupplierName,
            contact_person = @ContactPerson,
            phone_number = @PhoneNumber,
            email = @Email,
            address = @Address
        WHERE
            supplier_id = @SupplierId;
    ";

                public const string DELETE_SUPPLIER = @"
        DELETE FROM Suppliers
        WHERE supplier_id = @SupplierId;
    ";

                public const string GET_SUPPLIER_BY_ID = @"
        SELECT
            supplier_id, supplier_name, contact_person, phone_number, email, address
        FROM Suppliers
        WHERE supplier_id = @SupplierId;
    ";

                public const string GET_ALL_SUPPLIERS = @"
        SELECT
            supplier_id, supplier_name, contact_person, phone_number, email, address
        FROM Suppliers;
    ";
    }
}
