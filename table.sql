use qlbh


create table khach
(
	maKhach nvarchar(10) PRIMARY key,
	tenKhach nvarchar(50),
	diaChi nvarchar(100),
	sdt nvarchar(14)

)

create table hang
(
	maHang nvarchar(10) PRIMARY key,
	tenHang nvarchar(50),
	soLuong float(20),
	giaNhap float(20),
	giaBan float(20),

)


create table nhanvien
(
	maNhanVien nvarchar(10) PRIMARY key,
	tenNhanVien nvarchar(50),
	gioiTinh nvarchar(10),
	diaChi nvarchar(100),
	sdt nvarchar(14)
)

create table HDban
(
	maHDban nvarchar(10) PRIMARY key,
	maNhanVien nvarchar(10) references nhanvien(manhanvien),
	maKhach nvarchar(10) references khach(makhach),
	ngayBan datetime,
	tongtien float (20)
)

create table chitiethdban
(
	maHDban nvarchar(10)  references hdban(mahdban),
	maHang nvarchar(10) references hang(maHang),
	soluong float (20),
	dongia float (20),
	thanhtien float (20)
)