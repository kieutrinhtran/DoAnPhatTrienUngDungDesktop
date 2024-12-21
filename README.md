# [N3] ĐỒ ÁN CUỐI KỲ MÔN PHÁT TRIỂN ỨNG DỤNG DESKTOP
Đồ án cuối kỳ môn Phát triển ứng dụng Desktop xây dựng một hệ thống quản lý chung cư bao gồm các chức năng:
- Đăng nhập 
- Chăm sóc cư dân
- Quản lý tiện ích 
- Quản lý dịch vụ 
- Quản lý căn hộ 
- Quản lý tài khoản
- Quản lý cư dân 
- Quản lý khoản phí
- Thông báo 
- Đăng xuất

## Hướng dẫn chạy code
- Bước 1: Thực hiện mở `SQL Server Management Studio` và chạy Script `Create Table` và `Insert Data` trong folder `CSDL` để tạo cơ sở dữ liệu phục vụ cho quá trình thiết kế hệ thống.
- Bước 2: Trong **link github này**, Chọn mục `<> Code` → Chọn `Open with Visual Studio` để clone project về máy người dùng
- Bước 3: Trong **Visual Studio**, tìm đến `Class DBconnect.cs` trong thư mục `DAL`, sau đó thay đổi tên server của trong chuỗi kết nối (connection string) của đối tượng SQLConnection để phù hợp với cấu hình máy của người dùng (là tên server trong SQL Server Management Studio)
- Bước 4: Thực hiện chạy code trong Visual Studio với thông tin đăng nhập là:
  - Tên đăng nhập: nhom3
  - Mật khẩu: 123456

