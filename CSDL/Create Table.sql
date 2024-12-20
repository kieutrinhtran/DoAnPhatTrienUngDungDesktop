CREATE DATABASE QLCC;
GO
USE QLCC;

-- Tạo bảng CuDanDaiDien
CREATE TABLE CuDanDaiDien (
    ID_CuDan NVARCHAR(10) PRIMARY KEY,       
    HoTen NVARCHAR(100) NOT NULL,          
    NgaySinh DATE NOT NULL,                     
    GioiTinh NVARCHAR(10) NOT NULL,         
    SoDienThoai NVARCHAR(15) NOT NULL,       
    Email NVARCHAR(100) NOT NULL,           
    TinhTrang NVARCHAR(30) NOT NULL                 
);

-- Tạo bảng BanQuanLy
CREATE TABLE BanQuanLy (
    ID_BanQuanLy NVARCHAR(10) PRIMARY KEY,        
    HoTen NVARCHAR(100) NOT NULL,              
    NgaySinh DATE NOT NULL,                         
    GioiTinh NVARCHAR(10) NOT NULL,           
    VaiTro NVARCHAR(50) NOT NULL,             
    SoDienThoai NVARCHAR(15) NOT NULL,           
    Email NVARCHAR(100) NOT NULL                
);

-- Tạo bảng CanHo
CREATE TABLE CanHo (
    ID_CanHo NVARCHAR(10) PRIMARY KEY,          
    SoCanHo NVARCHAR(10) NOT NULL,            
    Tang INT NOT NULL,                       
    LoaiCanHo NVARCHAR(50) NOT NULL,         
    DienTich FLOAT NOT NULL,                 
    Gia DECIMAL(18) NOT NULL,             
    TinhTrang NVARCHAR(50) NOT NULL           
);

-- Tạo bảng TaiKhoanCanHo
CREATE TABLE TaiKhoanCanHo (
    ID_TaiKhoan NVARCHAR(10) PRIMARY KEY,       
    ID_CanHo NVARCHAR(10) NULL,  -- Cho phép NULL vì ON DELETE SET NULL      
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE, 
    MatKhau NVARCHAR(255) NOT NULL          
);

-- Tạo bảng LichSuCanHo
CREATE TABLE LichSuCanHo (
    ID_LichSuCanHo NVARCHAR(10) PRIMARY KEY,
    CuDanSoHuu NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    ID_CanHo NVARCHAR(10) NULL,   -- Cho phép NULL vì ON DELETE SET NULL
    NgayDangKySoHuu DATE,
    NgayKetThucSoHuu DATE
);

-- Tạo bảng KhoanPhi
CREATE TABLE KhoanPhi (
    ID_KhoanPhi NVARCHAR(10) PRIMARY KEY,      
    TenKhoanPhi NVARCHAR(100) NOT NULL,       
    DonGia DECIMAL(18) NOT NULL,           
    ChuKy NVARCHAR(50) NOT NULL,              
    TrangThai NVARCHAR(20) NOT NULL           
);

-- Tạo bảng TienIch
CREATE TABLE TienIch (
    ID_TienIch NVARCHAR(10) PRIMARY KEY,
    TenTienIch NVARCHAR(50) NOT NULL,
    GioMo VARCHAR(10) NOT NULL,
    GioDong VARCHAR(10) NOT NULL,
    MoTa NVARCHAR(255),
    GiaTien INT NOT NULL
);

-- Tạo bảng KhieuNai
CREATE TABLE KhieuNai (
    ID_KhieuNai NVARCHAR(10) PRIMARY KEY,
    NguoiGui NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    NguoiTiepNhan NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    NoiDung NVARCHAR(255) NOT NULL,
    NgayGui DATE NOT NULL,
    TrangThai NVARCHAR(50)
);

-- Tạo bảng PhanHoi
CREATE TABLE PhanHoi (
    ID_PhanHoi NVARCHAR(10) PRIMARY KEY,
    ID_KhieuNai NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    NoiDung NVARCHAR(255),
    NgayGui DATE
);

-- Tạo bảng The
CREATE TABLE The (
    ID_The NVARCHAR(10) PRIMARY KEY,
    ID_CanHo NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    TinhTrang NVARCHAR(50),
    LoaiThe NVARCHAR(50),
    LoaiXe NVARCHAR(50),
    BienSoXe NVARCHAR(50)
);

-- Tạo bảng LichDangKyTienIch
CREATE TABLE LichDangKyTienIch (
    ID_DangKy NVARCHAR(10) PRIMARY KEY,
    ID_TaiKhoan NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    ID_TienIch NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    GioBatDau TIME,
    GioKetThuc TIME,
    NgayDangKy DATE,
    TongTien INT
);

-- Tạo bảng ThongBao
CREATE TABLE ThongBao (
    ID_ThongBao NVARCHAR(10) PRIMARY KEY,
    NguoiGui NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    TieuDe NVARCHAR(255),
    NoiDung NVARCHAR(MAX),
    NgayGui DATE,
    TrangThai NVARCHAR(50)
);

-- Tạo bảng ChiTietThongBao
CREATE TABLE ChiTietThongBao (
    ID_ChiTietThongBao NVARCHAR(10) PRIMARY KEY,
    NguoiNhan NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    ID_ThongBao NVARCHAR(10) NOT NULL,
    ThoiGianXem DATETIME NULL,
    TrangThai NVARCHAR(50) NOT NULL
);

-- Tạo bảng ThongKeSuDung
CREATE TABLE ThongKeSuDung (
    ID_ThongKe NVARCHAR(10) PRIMARY KEY,
    ID_KhoanPhi NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    ID_CanHo NVARCHAR(10) NULL, -- Cho phép NULL vì ON DELETE SET NULL
    SoLuong INT,
    TrangThai NVARCHAR(30)
);

-- Thêm khóa ngoại cho bảng KhieuNai
ALTER TABLE KhieuNai
ADD FOREIGN KEY (NguoiGui) REFERENCES TaiKhoanCanHo(ID_TaiKhoan) ON DELETE SET NULL, -- Nếu người gửi bị xóa, giữ lại khiếu nại và đặt giá trị NguoiGui thành NULL.
    FOREIGN KEY (NguoiTiepNhan) REFERENCES BanQuanLy(ID_BanQuanLy) ON DELETE SET NULL; -- Nếu người tiếp nhận bị xóa, giữ lại khiếu nại và đặt NguoiTiepNhan thành NULL.

-- Thêm khóa ngoại cho bảng PhanHoi
ALTER TABLE PhanHoi
ADD FOREIGN KEY (ID_KhieuNai) REFERENCES KhieuNai(ID_KhieuNai) ON DELETE CASCADE; -- Nếu khiếu nại bị xóa, tất cả phản hồi liên quan cũng sẽ bị xóa.

-- Thêm khóa ngoại cho bảng The
ALTER TABLE The
ADD FOREIGN KEY (ID_CanHo) REFERENCES CanHo(ID_CanHo) ON DELETE SET NULL; -- Nếu căn hộ bị xóa, thẻ sẽ không bị xóa nhưng ID_CanHo sẽ được đặt thành NULL.

-- Thêm khóa ngoại cho bảng LichDangKyTienIch
ALTER TABLE LichDangKyTienIch
ADD FOREIGN KEY (ID_TaiKhoan) REFERENCES TaiKhoanCanHo(ID_TaiKhoan) ON DELETE SET NULL, -- Nếu tài khoản bị xóa, giữ lại lịch đăng ký và đặt ID_TaiKhoan thành NULL.
    FOREIGN KEY (ID_TienIch) REFERENCES TienIch(ID_TienIch) ON DELETE SET NULL; -- Nếu tiện ích bị xóa, giữ lại lịch đăng ký và đặt ID_TienIch thành NULL.

-- Thêm khóa ngoại cho bảng ThongBao
ALTER TABLE ThongBao
ADD FOREIGN KEY (NguoiGui) REFERENCES BanQuanLy(ID_BanQuanLy) ON DELETE SET NULL; -- Nếu người gửi thông báo bị xóa, giữ lại thông báo và đặt NguoiGui thành NULL.

-- Thêm khóa ngoại cho bảng ChiTietThongBao
ALTER TABLE ChiTietThongBao
ADD FOREIGN KEY (NguoiNhan) REFERENCES TaiKhoanCanHo(ID_TaiKhoan) ON DELETE SET NULL, -- Nếu tài khoản người nhận bị xóa, giữ lại chi tiết thông báo và đặt NguoiNhan thành NULL.
    FOREIGN KEY (ID_ThongBao) REFERENCES ThongBao(ID_ThongBao) ON DELETE CASCADE; -- Nếu thông báo bị xóa, tất cả chi tiết liên quan cũng sẽ bị xóa.

-- Thêm khóa ngoại cho bảng TaiKhoanCanHo
ALTER TABLE TaiKhoanCanHo 
ADD FOREIGN KEY (ID_CanHo) REFERENCES CanHo(ID_CanHo) ON DELETE SET NULL; -- Nếu căn hộ bị xóa, giữ lại tài khoản và đặt ID_CanHo thành NULL.

-- Thêm khóa ngoại cho bảng LichSuCanHo
ALTER TABLE LichSuCanHo 
ADD FOREIGN KEY (CuDanSoHuu) REFERENCES CuDanDaiDien(ID_CuDan) ON DELETE SET NULL, -- Nếu cư dân đại diện bị xóa, giữ lại lịch sử sở hữu của cư dân
    FOREIGN KEY (ID_CanHo) REFERENCES CanHo(ID_CanHo) ON DELETE SET NULL; -- Nếu căn hộ bị xóa, giữ lại toàn bộ lịch sử sở hữu của căn hộ

-- Thêm khóa ngoại cho bảng ThongKeSuDung
ALTER TABLE ThongKeSuDung
ADD FOREIGN KEY (ID_KhoanPhi) REFERENCES KhoanPhi(ID_KhoanPhi) ON DELETE SET NULL, -- Nếu khoản phí bị xóa, giữ lại thống kê và đặt ID_KhoanPhi thành NULL.
    FOREIGN KEY (ID_CanHo) REFERENCES CanHo(ID_CanHo) ON DELETE SET NULL;  -- Nếu căn hộ bị xóa, giữ lại toàn bộ thống kê liên quan.
