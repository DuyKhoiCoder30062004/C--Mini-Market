-- ==============================================================================
-- 1. INDEPENDENT TABLES (Level 0)
--    These tables have no foreign key dependencies.
-- ==============================================================================

-- 1.1 Functions (Chức năng)
use Winforms_C#;
SET IDENTITY_INSERT Functions ON;
INSERT INTO Functions (function_id, function_name) VALUES
(1, 'Xem Bảng điều khiển (Dashboard)'),
(2, 'Quản lý Nhân viên'),
(3, 'Quản lý Sản phẩm'),
(4, 'Xử lý Hóa đơn'),
(5, 'Xem Báo cáo'),
(6, 'Cấu hình Hệ thống');
SET IDENTITY_INSERT Functions OFF;
GO

-- 1.2 Permission_Groups (Nhóm Quyền)
SET IDENTITY_INSERT Permission_Groups ON;
INSERT INTO Permission_Groups (permission_group_id, permission_group_name) VALUES
(100, 'Quyền Admin'),
(101, 'Quyền Quản lý'),
(102, 'Quyền Bán hàng'),
(103, 'Quyền Kho hàng'),
(104, 'Quyền Chỉ đọc');
SET IDENTITY_INSERT Permission_Groups OFF;
GO

-- 1.3 Positions (Vị trí)
SET IDENTITY_INSERT Positions ON;
INSERT INTO Positions (position_id, position_name, description) VALUES
(1, 'Tổng Giám đốc (CEO)', 'Lãnh đạo cao nhất, chịu trách nhiệm toàn bộ công ty.'),
(2, 'Quản lý Bán hàng', 'Giám sát bộ phận bán hàng và mục tiêu doanh số.'),
(3, 'Đại diện Kinh doanh', 'Xử lý tài khoản khách hàng và tạo ra doanh thu.'),
(4, 'Thủ kho/Kiểm kê', 'Quản lý mức tồn kho sản phẩm và vận hành kho.'),
(5, 'Lập trình viên Cơ sở', 'Hỗ trợ bảo trì hệ thống và triển khai tính năng.');
SET IDENTITY_INSERT Positions OFF;
GO

-- 1.4 Suppliers (Nhà cung cấp)
SET IDENTITY_INSERT Suppliers ON;
INSERT INTO Suppliers (supplier_id, supplier_name, contact_person, phone_number, email, address) VALUES
(1, 'Công ty Điện tử Sài Gòn', 'Lê Văn A', '028-3821-1234', 'levana@saigon-elec.com', '123 Đường Nguyễn Huệ, Q.1, TP.HCM'),
(2, 'Thời trang Cao Cấp Hà Nội', 'Trần Thị B', '024-3936-5678', 'tranthib@fashionhn.vn', '456 Phố Tràng Tiền, Q. Hoàn Kiếm, Hà Nội');
SET IDENTITY_INSERT Suppliers OFF;
GO

-- 1.5 Customers (Khách hàng)
SET IDENTITY_INSERT Customers ON;
INSERT INTO Customers (customer_id, full_name, phone_number, address, email, points, create_at) VALUES
(1, 'Nguyễn Văn Hùng', '0901-111-222', '789 Đường Lê Lợi, Q.3, TP.HCM', 'hung.nv@email.com', 150, GETDATE()),
(2, 'Phạm Thị Lan', '0912-333-444', '101 Phố Hàng Bạc, Hoàn Kiếm, Hà Nội', 'lan.pt@email.com', 50, GETDATE()),
(3, 'Lê Minh Khôi', '0987-555-666', '202 Đường Tôn Đức Thắng, Q.1, TP.HCM', 'khoi.lm@email.com', 0, GETDATE());
SET IDENTITY_INSERT Customers OFF;
GO

-- ==============================================================================
-- 2. DEPENDENT TABLES (Level 1)
--    Requires data from Level 0 tables.
-- ==============================================================================

-- 2.1 PerGroup_Func (Phân quyền chức năng)
-- This is a junction table; assuming it does NOT have an IDENTITY column, 
-- but relies on foreign keys, which are now correctly populated above.
INSERT INTO PerGroup_Func (permission_group_id, function_id) VALUES
-- Admin (100): All functions
(100, 1), (100, 2), (100, 3), (100, 4), (100, 5), (100, 6),
-- Manager (101): View, Manage Products/Employees/Reports
(101, 1), (101, 2), (101, 3), (101, 5),
-- Sales (102): View, Process Invoices
(102, 1), (102, 4);
GO

-- 2.2 Roles (Vai trò)
SET IDENTITY_INSERT Roles ON;
INSERT INTO Roles (role_id, permission_group_id, role_name) VALUES
(10, 100, 'Quản trị Viên Hệ thống'),
(11, 101, 'Quản lý Cấp cao'),
(12, 102, 'Trưởng nhóm Kinh doanh'),
(13, 103, 'Nhân viên Kho');
SET IDENTITY_INSERT Roles OFF;
GO

-- 2.3 Categories (Danh mục - Self-referencing parent_category_id)
SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (category_id, category_name, description, parent_category_id, is_archive) VALUES
(1, 'Thiết bị Điện tử', 'Tất cả các thiết bị điện tử.', NULL, 0),
(2, 'Quần áo & Thời trang', 'Tất cả các mặt hàng may mặc và phụ kiện.', NULL, 0),
(3, 'Máy tính xách tay', 'Thiết bị tính toán di động.', 1, 0), -- Con của Thiết bị Điện tử
(4, 'Điện thoại thông minh', 'Thiết bị liên lạc di động.', 1, 0), -- Con của Thiết bị Điện tử
(5, 'Áo phông', 'Trang phục thường ngày.', 2, 0); -- Con của Quần áo & Thời trang
SET IDENTITY_INSERT Categories OFF;
GO

-- ==============================================================================
-- 3. DEPENDENT TABLES (Level 2 & 3 - Core Entities)
--    Requires data from Level 1/0 tables.
-- ==============================================================================

-- 3.1 Employees (Nhân viên)
SET IDENTITY_INSERT Employees ON;
INSERT INTO Employees (employee_id,position_id, role_id, full_name, username, password, email, phone_number, address, create_at, is_archive) VALUES
(10, 1, 10, 'Phan Thanh Hải', 'hai.pt', HASHBYTES('SHA2_256', 'AdminPass123'), 'hai.pt@company.com', '0901-000-001', '100 Trụ sở Chính, TP.HCM', GETDATE(), 0), -- CEO, Admin
(11, 2, 11, 'Võ Thị Mai', 'mai.vt', HASHBYTES('SHA2_256', 'ManagerPass456'), 'mai.vt@company.com', '0902-000-002', '200 Đại lộ Bán hàng, TP.HCM', GETDATE(), 0), -- Sales Manager
(12, 3, 12, 'Hoàng Trung Dũng', 'dung.ht', HASHBYTES('SHA2_256', 'SalesPass789'), 'dung.ht@company.com', '0903-000-003', '300 Đại lộ Bán hàng, TP.HCM', GETDATE(), 0), -- Sales Rep
(13, 4, 13, 'Đặng Văn Kiên', 'kien.dv', HASHBYTES('SHA2_256', 'WarehousePass012'), 'kien.dv@company.com', '0904-000-004', '400 Khu Công nghiệp, TP.HCM', GETDATE(), 0); -- Inventory Clerk
SET IDENTITY_INSERT Employees OFF;
GO



-- 3.2 Promotions (Khuyến mãi)
SET IDENTITY_INSERT Promotions ON;
INSERT INTO Promotions (promotion_id, promotion_name, discount_code, discount_type, discount_value, min_order_amount, start_date, end_date, usage_limit) VALUES
(1, 'Khuyến mãi Hè', 'KMHE20', 'percent', 20.00, 1000000.00, '2025-06-01', '2025-08-31', 100), -- 20% off, min order 1M
(2, 'Chào mừng Mua lần đầu', 'CHAO10', 'fixed', 50000.00, 500000.00, '2025-01-01', '2026-01-01', 500), -- 50k off, min order 500k
(3, 'Xả hàng Cuối năm', 'XH50', 'percent', 50.00, 0.00, '2025-11-01', '2025-12-31', 20); -- 50% off, no min
SET IDENTITY_INSERT Promotions OFF;
GO

-- 3.3 Products (Sản phẩm)
SET IDENTITY_INSERT Products ON;
INSERT INTO Products (product_id, category_id, supplier_id, barcode, product_name, description, unit, import_price, sale_price, image, create_at, last_updated, current_quantity, is_archive) VALUES
(100, 3, 1, '893456789012', 'Laptop Dell XPS 13', 'Máy tính xách tay cao cấp với màn hình 4K.', 'cái', 18000000.00, 28000000.00, 'url_laptop.jpg', GETDATE(), GETDATE(), 50, 0), -- Laptops
(101, 4, 1, '893456789013', 'Điện thoại Samsung Galaxy A55', 'Điện thoại thông minh tầm trung chạy Android.', 'cái', 8000000.00, 12000000.00, 'url_phone.jpg', GETDATE(), GETDATE(), 120, 0), -- Smartphones
(102, 5, 2, '903456789014', 'Áo phông Cotton Cơ bản', 'Áo phông trắng trơn chất liệu cotton.', 'cái', 100000.00, 250000.00, 'url_tshirt.jpg', GETDATE(), GETDATE(), 500, 0); -- T-Shirts
SET IDENTITY_INSERT Products OFF;
GO

-- 3.4 Import_Receipts (Phiếu nhập hàng - Need Suppliers, Employees)
SET IDENTITY_INSERT Import_receipts ON;
INSERT INTO Import_receipts (import_id, supplier_id, employee_id, import_date, total_amount) VALUES
(1000, 1, 13, GETDATE(), 900000000.00), -- 50 Laptops @ 18M = 900M
(1001, 2, 13, GETDATE(), 50000000.00); -- 500 T-shirts @ 100K = 50M
SET IDENTITY_INSERT Import_receipts OFF;
GO

-- 3.5 Export_Receipts (Phiếu xuất hàng/Kiểm kê - Need Employees)
SET IDENTITY_INSERT Export_receipts ON;
INSERT INTO Export_receipts (export_id, employee_id, export_date, total_amount) VALUES
(2000, 13, GETDATE(), 250000.00); -- Xuất 1 Áo phông (ví dụ: cho nhân viên)
SET IDENTITY_INSERT Export_receipts OFF;
GO

-- 3.6 Invoices (Hóa đơn - Need Employees, Customers)
SET IDENTITY_INSERT Invoices ON;
INSERT INTO Invoices (invoice_id, employee_id, customer_id, invoice_date, total_amount, amount_paid, change_amount, create_at) VALUES
(3000, 12, 1, GETDATE(), 28000000.00, 28000000.00, 0.00, GETDATE()), -- Sale to Hùng by Dũng (Sales Rep) - Laptop
(3001, 12, 2, GETDATE(), 12000000.00, 12000000.00, 0.00, GETDATE()), -- Sale to Lan by Dũng (Sales Rep) - Phone (No promo used here, calculated in details)
(3002, 11, 3, GETDATE(), 500000.00, 500000.00, 0.00, GETDATE()); -- Sale to Khôi by Mai (Manager) - 2 T-shirts
SET IDENTITY_INSERT Invoices OFF;
GO

-- ==============================================================================
-- 4. DETAILS TABLES (Level 4)
--    Requires data from all core transaction and entity tables.
-- ==============================================================================

-- 4.1 Import_Receipt_Details (Chi tiết Phiếu nhập)
SET IDENTITY_INSERT Import_receipt_Details ON;
INSERT INTO Import_receipt_Details (detail_id, import_id, product_id, quantity, total_price) VALUES
(1, 1000, 100, 50, 900000000.00), -- 50 Laptops @ 18,000,000.00
(2, 1001, 102, 500, 50000000.00); -- 500 T-shirts @ 100,000.00
SET IDENTITY_INSERT Import_receipt_Details OFF;
GO

-- 4.2 Export_Receipt_Details (Chi tiết Phiếu xuất)
SET IDENTITY_INSERT Export_receipt_details ON;
INSERT INTO Export_receipt_details (detail_id, export_id, product_id, quantity, total_price) VALUES
(1, 2000, 102, 1, 250000.00); -- 1 T-Shirt @ 250,000.00
SET IDENTITY_INSERT Export_receipt_details OFF;
GO

-- 4.3 Invoice_Details (Chi tiết Hóa đơn)
SET IDENTITY_INSERT Invoice_Details ON;
INSERT INTO Invoice_Details (detail_id, invoice_id, product_id, promotion_id, quantity, total_price, discounted_total_price) VALUES
-- Invoice 3000 (Nguyễn Văn Hùng - Laptop)
(1, 3000, 100, NULL, 1, 28000000.00, 28000000.00),
-- Invoice 3001 (Phạm Thị Lan - Phone, applied CHAO10 fixed discount 50,000)
(2, 3001, 101, 2, 1, 12000000.00, 11950000.00), -- 12M - 50k (fixed) = 11,950,000.00
-- Invoice 3002 (Lê Minh Khôi - 2 T-Shirts, total price = 500,000)
(3, 3002, 102, NULL, 2, 500000.00, 500000.00);
SET IDENTITY_INSERT Invoice_Details OFF;
GO

-- ==============================================================================
-- SQL SCRIPT TO CHANGE SPECIFIED COLUMNS TO NVARCHAR(100)
-- This ensures Unicode compatibility and standardized string lengths.
-- ==============================================================================

-- 1. Permission_Groups
ALTER TABLE Permission_Groups
ALTER COLUMN permission_group_name NVARCHAR(100) NOT NULL;

-- 2. Functions
ALTER TABLE Functions
ALTER COLUMN function_name NVARCHAR(100) NOT NULL;

-- 3. Suppliers
ALTER TABLE Suppliers
ALTER COLUMN supplier_name NVARCHAR(100) NOT NULL;
ALTER TABLE Suppliers
ALTER COLUMN contact_person NVARCHAR(100); -- Assuming this can be NULL
ALTER TABLE Suppliers
ALTER COLUMN address NVARCHAR(100); -- Assuming this can be NULL

-- 4. Products
ALTER TABLE Products
ALTER COLUMN product_name NVARCHAR(100) NOT NULL;
ALTER TABLE Products
ALTER COLUMN description NVARCHAR(100); -- Assuming this can be NULL
ALTER TABLE Products
ALTER COLUMN unit NVARCHAR(100);

-- 5. Roles
ALTER TABLE Roles
ALTER COLUMN role_name NVARCHAR(100) NOT NULL;

-- 6. Promotions
ALTER TABLE Promotions
ALTER COLUMN promotion_name NVARCHAR(100) NOT NULL;

-- 7. Positions
ALTER TABLE Positions
ALTER COLUMN position_name NVARCHAR(100) NOT NULL;
ALTER TABLE Positions
ALTER COLUMN description NVARCHAR(100); -- Assuming this can be NULL

-- 8. Customers
ALTER TABLE Customers
ALTER COLUMN full_name NVARCHAR(100) NOT NULL;
ALTER TABLE Customers
ALTER COLUMN address NVARCHAR(100); -- Assuming this can be NULL

-- 9. Employees
ALTER TABLE Employees
ALTER COLUMN full_name NVARCHAR(100) NOT NULL;
-- SECURITY NOTE: Employees.password stores HASHBYTES (VARBINARY) and SHOULD NOT be changed to NVARCHAR.
-- ALTER TABLE Employees ALTER COLUMN password VARBINARY(100); -- If you needed a larger hash, use VARBINARY, but 32 is standard.
ALTER TABLE Employees
ALTER COLUMN address NVARCHAR(100); -- Assuming this can be NULL

-- 10. Categories
ALTER TABLE Categories
ALTER COLUMN category_name NVARCHAR(100) NOT NULL;
ALTER TABLE Categories
ALTER COLUMN description NVARCHAR(100); -- Assuming this can be NULL