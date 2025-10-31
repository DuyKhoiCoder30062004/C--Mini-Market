CREATE TABLE Permission_Groups (
    permission_group_id INTEGER PRIMARY KEY AUTOINCREMENT,
    permission_group_name TEXT NOT NULL
);

CREATE TABLE Roles (
    role_id INTEGER PRIMARY KEY AUTOINCREMENT,
    permission_group_id INTEGER NOT NULL,
    role_name TEXT NOT NULL,
    FOREIGN KEY (permission_group_id) REFERENCES Permission_Groups(permission_group_id)
);

CREATE TABLE Functions (
    function_id INTEGER PRIMARY KEY AUTOINCREMENT,
    function_name TEXT NOT NULL
);

CREATE TABLE Departments (
    department_id INTEGER PRIMARY KEY AUTOINCREMENT,
    department_name TEXT NOT NULL,
    description TEXT
);

CREATE TABLE Positions (
    position_id INTEGER PRIMARY KEY AUTOINCREMENT,
    position_name TEXT NOT NULL,
    description TEXT
);

CREATE TABLE Employees (
    employee_id INTEGER PRIMARY KEY AUTOINCREMENT,
    department_id INTEGER NOT NULL,
    position_id INTEGER NOT NULL,
    role_id INTEGER NOT NULL,
    full_name TEXT NOT NULL,
    username TEXT UNIQUE NOT NULL,
    password TEXT NOT NULL,
    email TEXT,
    phone_number TEXT,
    address TEXT,
    create_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_archive BOOLEAN DEFAULT 0,
    FOREIGN KEY (department_id) REFERENCES Departments(department_id),
    FOREIGN KEY (position_id) REFERENCES Positions(position_id),
    FOREIGN KEY (role_id) REFERENCES Roles(role_id)
);

CREATE TABLE Customers (
    customer_id INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name TEXT NOT NULL,
    phone_number TEXT,
    address TEXT,
    email TEXT,
    points INTEGER DEFAULT 0,
    create_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Categories (
    category_id INTEGER PRIMARY KEY AUTOINCREMENT,
    category_name TEXT NOT NULL,
    description TEXT,
    parent_category_id INTEGER,
    is_archive BOOLEAN DEFAULT 0,
    FOREIGN KEY (parent_category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Suppliers (
    supplier_id INTEGER PRIMARY KEY AUTOINCREMENT,
    supplier_name TEXT NOT NULL,
    contact_person TEXT,
    phone_number TEXT,
    email TEXT,
    address TEXT
);

CREATE TABLE Products (
    product_id INTEGER PRIMARY KEY AUTOINCREMENT,
    category_id INTEGER NOT NULL,
    supplier_id INTEGER NOT NULL,
    barcode TEXT UNIQUE,
    product_name TEXT NOT NULL,
    description TEXT,
    unit TEXT,
    import_price REAL,
    sale_price REAL,
    image TEXT,
    create_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    last_updated DATETIME DEFAULT CURRENT_TIMESTAMP,
    current_quantity INTEGER DEFAULT 0,
    is_archive BOOLEAN DEFAULT 0,
    FOREIGN KEY (category_id) REFERENCES Categories(category_id),
    FOREIGN KEY (supplier_id) REFERENCES Suppliers(supplier_id)
);

CREATE TABLE Provisions (
    invoice_id INTEGER PRIMARY KEY AUTOINCREMENT,
    employee_id INTEGER NOT NULL,
    customer_id INTEGER NOT NULL,
    invoice_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    total_amount REAL,
    amount_paid REAL,
    change_amount REAL,
    create_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

CREATE TABLE Promotions (
    promotion_id INTEGER PRIMARY KEY AUTOINCREMENT,
    promotion_name TEXT NOT NULL,
    discount_code TEXT UNIQUE,
    discount_type TEXT CHECK(discount_type IN ('fixed', 'percent')),
    discount_value REAL,
    min_order_amount REAL DEFAULT 0,
    start_date DATETIME,
    end_date DATETIME,
    usage_limit INTEGER
);

CREATE TABLE Import_receipts (
    import_id INTEGER PRIMARY KEY AUTOINCREMENT,
    supplier_id INTEGER NOT NULL,
    employee_id INTEGER NOT NULL,
    import_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    total_amount REAL,
    FOREIGN KEY (supplier_id) REFERENCES Suppliers(supplier_id),
    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id)
);

CREATE TABLE Export_receipts (
    export_id INTEGER PRIMARY KEY AUTOINCREMENT,
    employee_id INTEGER NOT NULL,
    export_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    total_amount REAL,
    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id)
);

CREATE TABLE Import_receipt_details (
    detail_id INTEGER PRIMARY KEY AUTOINCREMENT,
    product_id INTEGER NOT NULL,
    import_id INTEGER NOT NULL,
    quantity INTEGER,
    total_price REAL,
    FOREIGN KEY (product_id) REFERENCES Products(product_id),
    FOREIGN KEY (import_id) REFERENCES Import_receipts(import_id)
);

CREATE TABLE Export_receipt_details (
    detail_id INTEGER PRIMARY KEY AUTOINCREMENT,
    product_id INTEGER NOT NULL,
    export_id INTEGER NOT NULL,
    quantity INTEGER,
    total_price REAL,
    FOREIGN KEY (product_id) REFERENCES Products(product_id),
    FOREIGN KEY (export_id) REFERENCES Export_receipts(export_id)
);

-- Permission Groups
INSERT INTO Permission_Groups (permission_group_name) VALUES
('Administrator'),
('Manager'),
('Staff'),
('Viewer');

-- Roles
INSERT INTO Roles (permission_group_id, role_name) VALUES
(1, 'Super Admin'),
(2, 'Sales Manager'),
(3, 'Sales Staff'),
(3, 'Warehouse Staff'),
(4, 'Report Viewer');

-- Functions
INSERT INTO Functions (function_name) VALUES
('User Management'),
('Product Management'),
('Inventory Management'),
('Sales Management'),
('Report Viewing'),
('System Configuration');

-- Departments
INSERT INTO Departments (department_name, description) VALUES
('Sales', 'Bán hàng và chăm sóc khách hàng'),
('Warehouse', 'Quản lý kho và xuất nhập hàng'),
('Accounting', 'Kế toán và tài chính');

-- Positions
INSERT INTO Positions (position_name, description) VALUES
('Department Manager', 'Quản lý bộ phận'),
('Sales Executive', 'Nhân viên kinh doanh'),
('Warehouse Staff', 'Nhân viên kho'),
('Accountant', 'Kế toán viên');

-- Employees
INSERT INTO Employees (department_id, position_id, role_id, full_name, username, password, email, phone_number, address) VALUES
(1, 1, 2, 'Nguyen Van A', 'nva', '123456', 'nva@company.com', '0123456789', 'Hanoi'),
(1, 2, 3, 'Tran Thi B', 'ttb', 'abcdef', 'ttb@company.com', '0987654321', 'HCMC'),
(2, 3, 4, 'Pham Van C', 'pvc', '123456', 'pvc@company.com', '0111222333', 'Danang');

-- Customers
INSERT INTO Customers (full_name, phone_number, address, email) VALUES
('Customer 1', '0111222333', 'Ha Noi', 'customer1@email.com'),
('Customer 2', '0999888777', 'HCMC', 'customer2@email.com'),
('Customer 3', '0333444555', 'Da Nang', 'customer3@email.com');

-- Categories
INSERT INTO Categories (category_name, description, parent_category_id) VALUES
('Electronics', 'Thiết bị điện tử', NULL),
('Food & Beverage', 'Thực phẩm và đồ uống', NULL),
('Smartphone', 'Điện thoại thông minh', 1),
('Laptop', 'Máy tính xách tay', 1),
('Beverage', 'Đồ uống', 2);

-- Suppliers
INSERT INTO Suppliers (supplier_name, contact_person, phone_number, email, address) VALUES
('Supplier A', 'Mr. X', '0123456789', 'contact@supplierA.com', 'Hanoi'),
('Supplier B', 'Ms. Y', '0987654321', 'contact@supplierB.com', 'HCMC'),
('Supplier C', 'Mr. Z', '0369852147', 'contact@supplierC.com', 'Danang');

-- Products
INSERT INTO Products (category_id, supplier_id, barcode, product_name, description, unit, import_price, sale_price, current_quantity) VALUES
(3, 1, '1234567890123', 'iPhone 14 Pro', 'Smartphone Apple 128GB', 'piece', 20000000, 22000000, 50),
(3, 2, '1234567890124', 'Samsung Galaxy S23', 'Smartphone Samsung 256GB', 'piece', 15000000, 18000000, 100),
(4, 1, '1234567890125', 'MacBook Air M2', 'Laptop Apple M2 2023', 'piece', 30000000, 35000000, 30),
(5, 3, '1234567890126', 'Coca Cola', 'Nước ngọt Coca Cola', 'can', 8000, 12000, 200);

-- Provisions (Invoices)
INSERT INTO Provisions (employee_id, customer_id, total_amount, amount_paid, change_amount) VALUES
(2, 1, 44000000, 50000000, 6000000),
(2, 2, 18000000, 20000000, 2000000),
(2, 3, 35000000, 40000000, 5000000);

-- Promotions
INSERT INTO Promotions (promotion_name, discount_code, discount_type, discount_value, min_order_amount, start_date, end_date, usage_limit) VALUES
('Summer Sale', 'SUMMER2024', 'percent', 10, 1000000, '2024-06-01', '2024-08-31', 1000),
('New Customer', 'WELCOME', 'fixed', 500000, 0, '2024-01-01', '2024-12-31', NULL),
('Big Sale', 'BIGSALE50', 'percent', 15, 5000000, '2024-05-01', '2024-05-31', 500);

-- Import_receipts
INSERT INTO Import_receipts (supplier_id, employee_id, total_amount) VALUES
(1, 3, 100000000),
(2, 3, 75000000),
(3, 3, 2400000);

-- Export_receipts
INSERT INTO Export_receipts (employee_id, total_amount) VALUES
(3, 22000000),
(3, 18000000),
(3, 120000);

-- Import_receipt_details
INSERT INTO Import_receipt_details (product_id, import_id, quantity, total_price) VALUES
(1, 1, 5, 100000000),
(2, 2, 5, 75000000),
(4, 3, 300, 2400000);

-- Export_receipt_details
INSERT INTO Export_receipt_details (product_id, export_id, quantity, total_price) VALUES
(1, 1, 1, 22000000),
(2, 2, 1, 18000000),
(4, 3, 10, 120000);
