using System;
using System.Collections.Generic;

namespace QuanLyChuyenXe
{
    public abstract class ChuyenXe
    {
        public string MaSoChuyen { get; set; }
        public string HoTenTaiXe {  get; set; }
        public string SoXe { get; set; }
        public double DoanhThu {  get; set; }   
        public ChuyenXe() { }
        public ChuyenXe(string maSoChuyen, string hoTenTaiXe, string soXe, double doanhThu)
        {
            MaSoChuyen = maSoChuyen;
            HoTenTaiXe = hoTenTaiXe;
            SoXe = soXe;
            DoanhThu = doanhThu;
        }
        public virtual void Xuat()
        {
            Console.WriteLine($"Mã chuyến: {MaSoChuyen} | Tài xế: {HoTenTaiXe} | Số xe: {SoXe} | Doanh thu: {DoanhThu:N0} VNĐ");
        }

    }
    public class ChuyenXeNoiThanh : ChuyenXe
    {
        public int SoTuyen { get; set; }
        public double SoKm { get; set; }
        public ChuyenXeNoiThanh() { }
        public ChuyenXeNoiThanh(string maSoChuyen, string hoTenTaiXe, string soXe, int soTuyen, double soKm, double doanhThu) : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            SoTuyen = soTuyen;
            SoKm = soKm;
        }
        public override void Xuat()
        {
            Console.WriteLine($"  -> [Nội thành] Số tuyến: {SoTuyen} | Số km đi được: {SoKm} km");
        }
    }
    public class ChuyenXeNgoaiThanh : ChuyenXe
    {
        public string NoiDen {  get; set; }
        public int SoNgayDiDuoc {  get; set; }
        public ChuyenXeNgoaiThanh() { }
        public ChuyenXeNgoaiThanh(string maSoChuyen, string hoTenTaiXe, string soXe,  string noiDen, int soNgayDiDuoc, double doanhThu) : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            NoiDen=noiDen;
            SoNgayDiDuoc=soNgayDiDuoc;
        }
        public override void Xuat()
        {
            Console.WriteLine($" -> [Ngoại thành] Nơi đến: {NoiDen} | Số ngày đi được: {SoNgayDiDuoc} ngày");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập hiển thị tiếng Việt có dấu trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Tạo danh sách quản lý chung
            List<ChuyenXe> danhSachChuyenXe = new List<ChuyenXe>()
    {
        new ChuyenXeNoiThanh("NT01", "Nguyễn Văn A", "51B-123.45", 10, 120.5, 1500000),
        new ChuyenXeNoiThanh("NT02", "Trần Văn B", "51B-678.90", 5, 85.0, 950000),
        new ChuyenXeNgoaiThanh("NG01", "Lê Văn C", "51B-999.11", "Đà Lạt", 3, 4500000),
        new ChuyenXeNgoaiThanh("NG02", "Phạm Văn D", "51B-888.22", "Vũng Tàu", 2, 2800000)
    };

            // 2. Xuất danh sách chuyến xe
            Console.WriteLine("================ DANH SÁCH CHUYẾN XE ================\n");
            foreach (var cx in danhSachChuyenXe)
            {
                cx.Xuat();
                Console.WriteLine(new string('-', 60));
            }

            // 3. Tính tổng doanh thu
            double tongDoanhThuNoiThanh = 0;
            double tongDoanhThuNgoaiThanh = 0;
            double tongDoanhThuTatCa = 0;

            foreach (var cx in danhSachChuyenXe)
            {
                tongDoanhThuTatCa += cx.DoanhThu;

                if (cx is ChuyenXeNoiThanh)
                {
                    tongDoanhThuNoiThanh += cx.DoanhThu;
                }
                else if (cx is ChuyenXeNgoaiThanh)
                {
                    tongDoanhThuNgoaiThanh += cx.DoanhThu;
                }
            }

            // 4. In thống kê
            Console.WriteLine("\n================ THỐNG KÊ DOANH THU ================");
            Console.WriteLine($"Tổng doanh thu xe Nội thành  : {tongDoanhThuNoiThanh:N0} VNĐ");
            Console.WriteLine($"Tổng doanh thu xe Ngoại thành : {tongDoanhThuNgoaiThanh:N0} VNĐ");
            Console.WriteLine($"----------------------------------------------------");
            Console.WriteLine($"TỔNG DOANH THU TẤT CẢ        : {tongDoanhThuTatCa:N0} VNĐ");

            // Dừng màn hình chờ người dùng
            Console.WriteLine("\nNhấn phím Enter để kết thúc...");
            Console.ReadLine();
        }
    }
}