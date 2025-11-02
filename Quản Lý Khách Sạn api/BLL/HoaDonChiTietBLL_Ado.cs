using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CoreApi.Models;

namespace CoreApi.BLL
{
    public class HoaDonChiTietBLL_Ado
    {
        private readonly string _connectionString;

        public HoaDonChiTietBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<HoaDonChiTiet> LayDanhSach()
        {
            var list = new List<HoaDonChiTiet>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM HoaDonChiTiet", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new HoaDonChiTiet
                        {
                            MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                            MaHD = Convert.ToInt32(reader["MaHD"]),
                            MaDV = reader["MaDV"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaDV"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            DonGia = Convert.ToDecimal(reader["DonGia"])
                        });
                    }
                }
            }
            return list;
        }

        public HoaDonChiTiet? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM HoaDonChiTiet WHERE MaChiTiet=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new HoaDonChiTiet
                        {
                            MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                            MaHD = Convert.ToInt32(reader["MaHD"]),
                            MaDV = reader["MaDV"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["MaDV"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            DonGia = Convert.ToDecimal(reader["DonGia"])
                        };
                    }
                }
            }
            return null;
        }

        public void Them(HoaDonChiTiet ct)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO HoaDonChiTiet (MaHD, MaDV, SoLuong, DonGia) VALUES (@MaHD, @MaDV, @SoLuong, @DonGia)", conn);
                cmd.Parameters.AddWithValue("@MaHD", ct.MaHD);
                cmd.Parameters.AddWithValue("@MaDV", (object?)ct.MaDV ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(HoaDonChiTiet ct)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE HoaDonChiTiet SET MaHD=@MaHD, MaDV=@MaDV, SoLuong=@SoLuong, DonGia=@DonGia WHERE MaCTHD=@MaCTHD", conn);
                cmd.Parameters.AddWithValue("@MaCTHD", ct.MaCTHD);
                cmd.Parameters.AddWithValue("@MaHD", ct.MaHD);
                cmd.Parameters.AddWithValue("@MaDV", (object?)ct.MaDV ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM HoaDonChiTiet WHERE MaCTHD=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
