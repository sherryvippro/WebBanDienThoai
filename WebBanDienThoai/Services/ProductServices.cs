using WebBanDienThoai.InputModels;
using WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

using System.Linq;
using System;
using System.Collections;

namespace WebBanDienThoai.Services
{
    public class ProductServices
    {
        private readonly QLBanDTContext _context;
        private readonly ImageServices _imageServices;

        public ProductServices(QLBanDTContext context, ImageServices imageServices)
        {
            _context = context;
            _imageServices = imageServices;
        }
        public async Task<TSp> CreateProductAsync(InputProducts inputProducts)
        {
            var query = _context.TSp.Find(inputProducts.MaSp);
            var tSp = new TSp()
            {
                TenSp = inputProducts.TenSp,
                MaSp = inputProducts.MaSp,
                SoLuong = inputProducts.SoLuong,
                DonGiaNhap = inputProducts?.DonGiaNhap,
                DonGiaBan = inputProducts?.DonGiaBan,
                Anh = await _imageServices.SaveFileAsync(inputProducts.Anh),
                MaHang = inputProducts?.MaHang,
                MaTl = inputProducts?.MaTl
            };
            if (query != null)
            {
                query.TenSp = inputProducts.TenSp;
                query.SoLuong += inputProducts.SoLuong;
                query.DonGiaBan = inputProducts.DonGiaBan;
                query.DonGiaNhap = inputProducts.DonGiaNhap;
                query.Anh = await _imageServices.SaveFileAsync(inputProducts.Anh);
            }
            else
            {
                
                _context.Add(tSp);
            }
            _context.SaveChanges();
            return tSp;
        }
        public async Task<TSp> EditProductAsync(InputProducts inputProducts, string id)
        {
            var query = await _context.TSp.FindAsync(id);
            if (query != null)
            {
                query.TenSp = inputProducts.TenSp;
                query.SoLuong = inputProducts.SoLuong;
                query.DonGiaBan = inputProducts.DonGiaBan;
                query.DonGiaNhap = inputProducts.DonGiaNhap;
                query.Anh = await _imageServices.SaveFileAsync(inputProducts.Anh);
            }
            _context.SaveChanges();
            return query;
        }
        public async Task<TSp> DeleteProductAsync(string id)
        {
            var tSp = _context.TSp.Find(id);
            if(tSp != null)
            {
                tSp.SoLuong = 0;
            }
            _context.SaveChanges();
            return tSp;
        }

        public async Task<int> GetTotalProductAsync()
        {
            var total = await _context.TSp.SumAsync(x => x.SoLuong);
            return (int)total;
        }
        public async Task<double> GetTotalMoneyAsync()
        {
            var money = await _context.THoaDonNhaps.SumAsync(x => x.TongHdn);
            return (double)money;
        }
        public async Task<double> GetRevenueAsync()
        {
            var revenue = await _context.THoaDonBans.SumAsync(x => x.TongHdb);
            return (double)revenue;
        }
        public async Task<double> GetProfitAsync()
        {
            var profit = await _context.THoaDonBans.SumAsync(x => x.TongHdb) - await _context.THoaDonNhaps.SumAsync(x => x.TongHdn);
            return (double)profit;
        }
        public async Task<double> GetProductSoldAsync()
        {
            var productSold = await _context.TChiTietHdbs.Include(t => t.SoHdbNavigation).SumAsync(x => x.Slban);
            return (double)productSold;
        }
        public async Task<string> GetTopProductsAsync()
        {
            /*var day =  _context.THoaDonBans.Select(x => x.NgayBan).ToList();
            foreach(var i in day)
            {
                DateTime.Parse(i);
            }*/
            var query = from sp in _context.TSp
                        join chiTietHDB in _context.TChiTietHdbs on sp.MaSp equals chiTietHDB.MaSp
                        join hoaDonBan in _context.THoaDonBans on chiTietHDB.SoHdb equals hoaDonBan.SoHdb
                        where hoaDonBan.NgayBan.Value.Year == DateTime.Now.Year
                        group chiTietHDB by sp.MaSp into g
                        orderby g.Sum(x => x.Slban) descending
                        select new
                        {
                            masp = g.Key,
                            TotalSales = g.Sum(x => x.Slban),
                            sohdb = g.FirstOrDefault().SoHdb 
                        };
            string result;
            if (query.Select(x => x.masp) != null)
            {
                result =  query.FirstOrDefaultAsync().Result.masp;
                return (string)result;
            }
            else return "";
        }
        /*public List<string> GetTop10Products()
        {
            var query = from sp in _context.TSp
                        join chiTietHDB in _context.TChiTietHdbs on sp.MaSp equals chiTietHDB.MaSp
                        join hoaDonBan in _context.THoaDonBans on chiTietHDB.SoHdb equals hoaDonBan.SoHdb
                        where hoaDonBan.NgayBan.Value.Year == DateTime.Now.Year
                        group chiTietHDB by sp.MaSp into g
                        orderby g.Sum(x => x.Slban) descending
                        select new
                        {
                            masp = g.Key,
                            TotalSales = g.Sum(x => x.Slban),
                            sohdb = g.Select(x => x.SoHdb),
                            tensp = g.Select(x => x.MaSpNavigation.TenSp)
                        };
            string list = "";
            if(query.Select(x => x.masp) == null)
            {
                list = "Không có sản phẩm nào";
            }
            
                return query.Select(x => x.masp).ToList();

        }*/

        public async Task<long> GetMoneyofTopProductsAsync()
        {
            /*var day =  _context.THoaDonBans.Select(x => x.NgayBan).ToList();
            foreach(var i in day)
            {
                DateTime.Parse(i);
            }*/
            var query = from sp in _context.TSp
                        join chiTietHDB in _context.TChiTietHdbs on sp.MaSp equals chiTietHDB.MaSp
                        join hoaDonBan in _context.THoaDonBans on chiTietHDB.SoHdb equals hoaDonBan.SoHdb
                        where hoaDonBan.NgayBan.Value.Year == DateTime.Now.Year
                        group chiTietHDB by sp.MaSp into g
                        orderby g.Sum(x => x.Slban) descending
                        select new
                        {
                            masp = g.Key,
                            TotalSales = g.Sum(x => x.SoHdbNavigation.TongHdb),
                            sohdb = g.FirstOrDefault().SoHdb
                        };
            long result;
            if (query.Select(x => x.masp) != null)
            {
                result = (long)query.FirstOrDefaultAsync().Result.TotalSales;
                return (long)result;
            }
            else return 0;
        }

        
    }
}
