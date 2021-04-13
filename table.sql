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

create sequence ThemSeq
	start with 1000 --bat dau tu 1000
	increment by 1; --moi lan tang 1 don vi
		select next value for ThemSeq

create procedure selectAllHang
as
	select maHang, tenHang, soLuong, giaNhap, giaBan
	from hang

exec selectAllHang
-----------------------------------------------------------
create procedure selectHangById @Ma nvarchar(10)
as
begin

	select maHang, tenHang, soLuong, giaNhap, giaBan
	from hang
	where maHang = @Ma

end

----------------------------------------------------------
create proc InsertHang
	@tenHang nvarchar(50),
	@soLuong float(20),
	@giaNhap float(20),
	@giaBan float(20)
as
begin
	insert into hang
	(
		maHang, tenHang, soLuong, giaNhap, giaBan
	)values(
		'SP' + cast(next value for ThemSeq as nvarchar(10)),
		@tenHang,
		@soLuong,
		@giaNhap,
		@giaBan
	);

if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end
----------------------------------------------------------
create proc UpdateHang
	@maHang nvarchar(10),
	@tenHang nvarchar(50),
	@soLuong float(20),
	@giaNhap float(20),
	@giaBan float(20)
as
begin
	update hang
	set
		tenHang = @tenHang,
		soLuong = @soLuong,
		giaNhap = @giaNhap,
		giaBan = @giaBan
	where maHang = @maHang;

	if @@ROWCOUNT > 0 begin return 1 end
		else begin return 0 end;
end
---------------------------------------------------------
---Search Hang---
create procedure searchMaHang @MaHang nvarchar(10)
as 
begin
	select maHang, tenHang, soLuong, giaNhap, giaBan
	from hang
	where maHang = @MaHang
end
go


create procedure searchTenHang @TenHang nvarchar(50)
as 
begin
	select maHang, tenHang, soLuong, giaNhap, giaBan
	from hang
	where tenHang = @TenHang
end
go

create procedure searchGiaNhap @GiaNhap float(20)
as 
begin
	select maHang, tenHang, soLuong, giaNhap, giaBan
	from hang
	where giaNhap <= @GiaNhap
end
go


create procedure searchGiaBan @GiaBan float(20)
as 
begin
	select maHang, tenHang, soLuong, giaNhap, giaBan
	from hang
	where giaBan <= @GiaBan
end
go

-----------------------------------------------------