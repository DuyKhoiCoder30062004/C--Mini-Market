CREATE TABLE Departments (
    department_id       INTEGER PRIMARY KEY AUTOINCREMENT,
    department_name     TEXT NOT NULL,
    description         TEXT
);

CREATE TABLE Positions (
    position_id         INTEGER PRIMARY KEY AUTOINCREMENT,
    position_name       TEXT NOT NULL,
    description         TEXT
);

CREATE TABLE Categories (
    category_id         INTEGER PRIMARY KEY AUTOINCREMENT,
    category_name       TEXT NOT NULL,
    description         TEXT,
    parent_category_id  INTEGER,
    is_archive          BOOLEAN DEFAULT 0,

    FOREIGN KEY (parent_category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Suppliers (
    supplier_id         INTEGER PRIMARY KEY AUTOINCREMENT,
    supplier_name       TEXT NOT NULL,
    contact_person      TEXT,
    phone_number        TEXT,
    email               TEXT,
    address             TEXT
);

CREATE TABLE Employees (
    employee_id         INTEGER PRIMARY KEY AUTOINCREMENT,
    department_id       INTEGER NOT NULL,
    position_id         INTEGER NOT NULL,
    full_name           TEXT NOT NULL,
    username            TEXT UNIQUE,
    password            TEXT,
    email               TEXT,
    phone_number        TEXT,
    address             TEXT,
    create_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_archive          BOOLEAN DEFAULT 0,

    FOREIGN KEY (department_id) REFERENCES Departments(department_id),
    FOREIGN KEY (position_id) REFERENCES Positions(position_id)
);

CREATE TABLE Products (
    product_id          INTEGER PRIMARY KEY AUTOINCREMENT,
    category_id         INTEGER NOT NULL,
    supplier_id         INTEGER NOT NULL,
    barcode TEXT        UNIQUE,
    product_name        TEXT NOT NULL,
    description         TEXT,
    unit                TEXT,
    import_price        REAL,
    sale_price          REAL,
    image               TEXT,
    create_at           DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_archive          BOOLEAN DEFAULT 0,

    FOREIGN KEY (category_id) REFERENCES Categories(category_id),
    FOREIGN KEY (supplier_id) REFERENCES Suppliers(supplier_id)
);

CREATE TABLE Customers (
    customer_id         INTEGER PRIMARY KEY AUTOINCREMENT,
    full_name           TEXT NOT NULL,
    phone_number        TEXT,
    address             TEXT,
    email               TEXT,
    points              INTEGER DEFAULT 0,
    create_at           DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Inventory (
    inventory_id        INTEGER PRIMARY KEY AUTOINCREMENT,
    product_id          INTEGER NOT NULL,
    current_quantity    INTEGER DEFAULT 0,
    min_quantity        INTEGER DEFAULT 0,
    max_quantity        INTEGER DEFAULT 1000,
    last_updated        DATETIME DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Invoices (
    invoice_id          INTEGER PRIMARY KEY AUTOINCREMENT,
    employee_id         INTEGER NOT NULL,
    customer_id         INTEGER NOT NULL,
    invoice_date        DATETIME DEFAULT CURRENT_TIMESTAMP,
    total_amount        REAL,
    amount_paid         REAL,
    change_amount       REAL,
    create_at           DATETIME DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

CREATE TABLE Invoice_details (
    detail_id           INTEGER PRIMARY KEY AUTOINCREMENT,
    invoice_id          INTEGER NOT NULL,
    product_id          INTEGER NOT NULL,
    quantity            INTEGER,
    total_price         REAL,

    FOREIGN KEY (invoice_id) REFERENCES Invoices(invoice_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Import_receipts (
    import_id           INTEGER PRIMARY KEY AUTOINCREMENT,
    supplier_id         INTEGER NOT NULL,
    employee_id         INTEGER NOT NULL,
    import_date         DATETIME DEFAULT CURRENT_TIMESTAMP,
    total_amount        REAL,

    FOREIGN KEY (supplier_id) REFERENCES Suppliers(supplier_id),
    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id)
);

CREATE TABLE Import_receipt_details (
    detail_id           INTEGER PRIMARY KEY AUTOINCREMENT,
    product_id          INTEGER NOT NULL,
    import_id           INTEGER NOT NULL,
    quantity            INTEGER,
    total_price         REAL,

    FOREIGN KEY (product_id) REFERENCES Products(product_id),
    FOREIGN KEY (import_id) REFERENCES Import_receipts(import_id)
);

CREATE TABLE Export_receipts (
    export_id           INTEGER PRIMARY KEY AUTOINCREMENT,
    employee_id         INTEGER NOT NULL,
    export_date         DATETIME DEFAULT CURRENT_TIMESTAMP,
    total_amount        REAL,

    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id)
);

CREATE TABLE Export_receipt_details (
    detail_id           INTEGER PRIMARY KEY AUTOINCREMENT,
    product_id          INTEGER NOT NULL,
    export_id           INTEGER NOT NULL,
    quantity            INTEGER,
    total_price         REAL,

    FOREIGN KEY (product_id) REFERENCES Products(product_id),
    FOREIGN KEY (export_id) REFERENCES Export_receipts(export_id)
);

CREATE TABLE Promotions (
    promotion_id        INTEGER PRIMARY KEY AUTOINCREMENT,
    promotion_name      TEXT NOT NULL,
    discount_code       TEXT UNIQUE,
    discount_type       TEXT CHECK(discount_type IN ('fixed', 'percent')),
    discount_value      REAL,
    min_order_amount    REAL DEFAULT 0,
    start_date          DATETIME,
    end_date            DATETIME,
    usage_limit         INTEGER
);

INSERT INTO Departments (department_name, description) VALUES
('Sales', 'Bán hàng và chăm sóc khách hàng'),
('Warehouse', 'Quản lý kho và xuất nhập hàng');

INSERT INTO Positions (position_name, description) VALUES
('Manager', 'Quản lý bộ phận'),
('Staff', 'Nhân viên thực hiện nghiệp vụ');

INSERT INTO Categories (category_name, description, parent_category_id) VALUES
('Electronics', 'Thiết bị điện tử', NULL),
('Food', 'Thực phẩm và đồ uống', NULL),
('Smartphone', 'Điện thoại thông minh', 1);

INSERT INTO Suppliers (supplier_name, contact_person, phone_number, email, address) VALUES
('Supplier A', 'Mr. X', '0123456789', 'contact@supplierA.com', 'Hanoi'),
('Supplier B', 'Ms. Y', '0987654321', 'contact@supplierB.com', 'HCMC');

INSERT INTO Employees (department_id, position_id, full_name, username, password, email, phone_number, address) VALUES
(1, 1, 'Nguyen Van A', 'nva', '123456', 'nva@company.com', '0111222333', 'Hanoi'),
(2, 2, 'Tran Thi B', 'ttb', 'abcdef', 'ttb@company.com', '0999888777', 'HCMC');

INSERT INTO Products (category_id, supplier_id, barcode, product_name, description, unit, import_price, sale_price) VALUES
(3, 1, '123456789', 'iPhone 14', 'Smartphone Apple', 'piece', 20000, 22000),
(3, 2, '987654321', 'Samsung Galaxy', 'Smartphone Android', 'piece', 15000, 18000);

INSERT INTO Customers (full_name, phone_number, address, email) VALUES
('Customer 1', '0123456789', 'Ha Noi', 'customer1@email.com'),
('Customer 2', '0987654321', 'HCMC', 'customer2@email.com');

INSERT INTO Inventory (product_id, current_quantity, min_quantity, max_quantity) VALUES
(1, 50, 5, 100),
(2, 100, 10, 200);

INSERT INTO Invoices (employee_id, customer_id, total_amount, amount_paid, change_amount) VALUES
(1, 1, 44000, 50000, 6000),
(1, 2, 18000, 20000, 2000);

INSERT INTO Invoice_details (invoice_id, product_id, quantity, total_price) VALUES
(1, 1, 2, 44000),
(2, 2, 1, 18000);

INSERT INTO Import_receipts (supplier_id, employee_id, total_amount) VALUES
(1, 2, 40000),
(2, 2, 30000);

INSERT INTO Import_receipt_details (product_id, import_id, quantity, total_price) VALUES
(1, 1, 2, 40000),
(2, 2, 2, 30000);

INSERT INTO Export_receipts (employee_id, total_amount) VALUES
(2, 22000),
(2, 18000);

INSERT INTO Export_receipt_details (product_id, export_id, quantity, total_price) VALUES
(1, 1, 1, 22000),
(2, 2, 1, 18000);

INSERT INTO Promotions (promotion_name, discount_code, discount_type, discount_value, min_order_amount, start_date, end_date, usage_limit) VALUES
('Summer Sale', 'SUMMER2024', 'percent', 10, 100000, '2024-06-01', '2024-08-31', 1000),
('New Customer', 'WELCOME', 'fixed', 5000, 0, '2024-01-01', '2024-12-31', NULL);
