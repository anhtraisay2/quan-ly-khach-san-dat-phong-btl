using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CoreApi.Models;

namespace CoreApi.BLL
{
    public class HoaDonBLL_Ado
    {
        private readonly string _connectionString;

        public HoaDonBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<HoaDon> LayDanhSach()
        {
            var list = new List<HoaDon>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MaHD, SoHD, MaKhach, MaND, NgayLap, TongTien, HinhThucThanhToan, SoTienDaTra, SoTienConNo FROM HoaDon", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hoaDon = new HoaDon
                        {
                            MaHD = Convert.ToInt32(reader["MaHD"]),
                            SoHD = reader["SoHD"].ToString(),
                            MaKhach = Convert.ToInt32(reader["MaKhach"]),
                            MaND = Convert.ToInt32(reader["MaND"]),
                            NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"]),
                            HinhThucThanhToan = reader["HinhThucThanhToan"].ToString(),
                            SoTienDaTra = Convert.ToDecimal(reader["SoTienDaTra"])
                        };
                        list.Add(hoaDon);
                    }
                }
            }
            return list;
        }

        public HoaDon? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM HoaDon WHERE MaHD=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HoaDon
                        {
                            MaHD = Convert.ToInt32(reader["MaHD"]),
                            MaKhach = Convert.ToInt32(reader["MaKhach"]),
                            NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                            TongTien = Convert.ToDecimal(reader["TongTien"]),
                            HinhThucThanhToan = reader["HinhThucThanhToan"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Them(HoaDon hd)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO HoaDon (MaKhach, NgayLap, TongTien, HinhThucThanhToan) VALUES (@MaKhach, @NgayLap, @TongTien, @HinhThucThanhToan)", conn);
                cmd.Parameters.AddWithValue("@MaKhach", hd.MaKhach);
                cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                cmd.Parameters.AddWithValue("@HinhThucThanhToan", hd.HinhThucThanhToan);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(HoaDon hd)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE HoaDon SET MaKhach=@MaKhach, NgayLap=@NgayLap, TongTien=@TongTien, HinhThucThanhToan=@HinhThucThanhToan WHERE MaHD=@MaHD", conn);
                cmd.Parameters.AddWithValue("@MaHD", hd.MaHD);
                cmd.Parameters.AddWithValue("@MaKhach", hd.MaKhach);
                cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                cmd.Parameters.AddWithValue("@HinhThucThanhToan", hd.HinhThucThanhToan);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM HoaDon WHERE MaHD=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
