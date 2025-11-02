using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CoreApi.Models;

namespace CoreApi.BLL
{
    public class NguoiDungBLL_Ado
    {
        private readonly string _connectionString;
        public NguoiDungBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<NguoiDung> LayDanhSach()
        {
            var list = new List<NguoiDung>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM NguoiDung", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NguoiDung
                        {
                            MaND = Convert.ToInt32(reader["MaND"]),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            HoTen = reader["HoTen"].ToString(),
                            VaiTro = reader["VaiTro"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public NguoiDung? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM NguoiDung WHERE MaND=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NguoiDung
                        {
                            MaND = Convert.ToInt32(reader["MaND"]),
                            TenDangNhap = reader["TenDangNhap"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            HoTen = reader["HoTen"].ToString(),
                            VaiTro = reader["VaiTro"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Them(NguoiDung nd)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES (@TenDangNhap, @MatKhau, @HoTen, @VaiTro)", conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", nd.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@HoTen", nd.HoTen);
                cmd.Parameters.AddWithValue("@VaiTro", nd.VaiTro);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(NguoiDung nd)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE NguoiDung SET TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, HoTen=@HoTen, VaiTro=@VaiTro WHERE MaND=@MaND", conn);
                cmd.Parameters.AddWithValue("@MaND", nd.MaND);
                cmd.Parameters.AddWithValue("@TenDangNhap", nd.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", nd.MatKhau);
                cmd.Parameters.AddWithValue("@HoTen", nd.HoTen);
                cmd.Parameters.AddWithValue("@VaiTro", nd.VaiTro);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM NguoiDung WHERE MaND=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
