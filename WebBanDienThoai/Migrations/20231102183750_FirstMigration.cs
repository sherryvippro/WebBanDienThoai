using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanDienThoai.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    IDQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.IDQuyen);
                });

            migrationBuilder.CreateTable(
                name: "tHang",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tTheLoai", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "tNhaCungCap",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNhaCungCap", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "tTheLoai",
                columns: table => new
                {
                    MaTL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenTL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tNhaXuatBan", x => x.MaTL);
                });

            migrationBuilder.CreateTable(
                name: "Nguoidung",
                columns: table => new
                {
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anhdaidien = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dienthoai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Matkhau = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDQuyen = table.Column<int>(type: "int", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhanQuyenIDQuyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhang", x => x.MaNguoiDung);
                    table.ForeignKey(
                        name: "FK_Nguoidung_PhanQuyen_PhanQuyenIDQuyen",
                        column: x => x.PhanQuyenIDQuyen,
                        principalTable: "PhanQuyen",
                        principalColumn: "IDQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tHoaDonNhap",
                columns: table => new
                {
                    SoHDN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaNCC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TongHDN = table.Column<decimal>(type: "money", nullable: true),
                    MaNccNavigationMaNcc = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tHoaDonNhap", x => x.SoHDN);
                    table.ForeignKey(
                        name: "FK_tHoaDonNhap_tNhaCungCap_MaNccNavigationMaNcc",
                        column: x => x.MaNccNavigationMaNcc,
                        principalTable: "tNhaCungCap",
                        principalColumn: "MaNCC");
                });

            migrationBuilder.CreateTable(
                name: "tSP",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MaTL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MaHang = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DonGiaNhap = table.Column<decimal>(type: "money", nullable: true),
                    DonGiaBan = table.Column<decimal>(type: "money", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    Anh = table.Column<byte[]>(type: "image", nullable: true),
                    MaHangNavigationMaHang = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    MaTlNavigationMaTl = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tSach", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_tSP_tHang_MaHangNavigationMaHang",
                        column: x => x.MaHangNavigationMaHang,
                        principalTable: "tHang",
                        principalColumn: "MaHang");
                    table.ForeignKey(
                        name: "FK_tSP_tTheLoai_MaTlNavigationMaTl",
                        column: x => x.MaTlNavigationMaTl,
                        principalTable: "tTheLoai",
                        principalColumn: "MaTL");
                });

            migrationBuilder.CreateTable(
                name: "tHoaDonBan",
                columns: table => new
                {
                    SoHDB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayBan = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TongHDB = table.Column<decimal>(type: "money", nullable: true),
                    MaKhNavigationMaNguoiDung = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tHoaDonBan", x => x.SoHDB);
                    table.ForeignKey(
                        name: "FK_tHoaDonBan_Nguoidung_MaKhNavigationMaNguoiDung",
                        column: x => x.MaKhNavigationMaNguoiDung,
                        principalTable: "Nguoidung",
                        principalColumn: "MaNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "tChiTietHDN",
                columns: table => new
                {
                    SoHDN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SLNhap = table.Column<int>(type: "int", nullable: true),
                    KhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tChiTietHDN", x => new { x.SoHDN, x.MaSP });
                    table.ForeignKey(
                        name: "FK_tChiTietHDN_tHoaDonNhap_SoHDN",
                        column: x => x.SoHDN,
                        principalTable: "tHoaDonNhap",
                        principalColumn: "SoHDN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tChiTietHDN_tSP_MaSP",
                        column: x => x.MaSP,
                        principalTable: "tSP",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tChiTietHDB",
                columns: table => new
                {
                    SoHDB = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SLBan = table.Column<int>(type: "int", nullable: true),
                    KhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tChiTietHDB", x => new { x.SoHDB, x.MaSP });
                    table.ForeignKey(
                        name: "FK_tChiTietHDB_tHoaDonBan_SoHDB",
                        column: x => x.SoHDB,
                        principalTable: "tHoaDonBan",
                        principalColumn: "SoHDB",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tChiTietHDB_tSP_MaSP",
                        column: x => x.MaSP,
                        principalTable: "tSP",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nguoidung_PhanQuyenIDQuyen",
                table: "Nguoidung",
                column: "PhanQuyenIDQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_tChiTietHDB_MaSP",
                table: "tChiTietHDB",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_tChiTietHDN_MaSP",
                table: "tChiTietHDN",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_tHoaDonBan_MaKhNavigationMaNguoiDung",
                table: "tHoaDonBan",
                column: "MaKhNavigationMaNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_tHoaDonNhap_MaNccNavigationMaNcc",
                table: "tHoaDonNhap",
                column: "MaNccNavigationMaNcc");

            migrationBuilder.CreateIndex(
                name: "IX_tSP_MaHangNavigationMaHang",
                table: "tSP",
                column: "MaHangNavigationMaHang");

            migrationBuilder.CreateIndex(
                name: "IX_tSP_MaTlNavigationMaTl",
                table: "tSP",
                column: "MaTlNavigationMaTl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tChiTietHDB");

            migrationBuilder.DropTable(
                name: "tChiTietHDN");

            migrationBuilder.DropTable(
                name: "tHoaDonBan");

            migrationBuilder.DropTable(
                name: "tHoaDonNhap");

            migrationBuilder.DropTable(
                name: "tSP");

            migrationBuilder.DropTable(
                name: "Nguoidung");

            migrationBuilder.DropTable(
                name: "tNhaCungCap");

            migrationBuilder.DropTable(
                name: "tHang");

            migrationBuilder.DropTable(
                name: "tTheLoai");

            migrationBuilder.DropTable(
                name: "PhanQuyen");
        }
    }
}
