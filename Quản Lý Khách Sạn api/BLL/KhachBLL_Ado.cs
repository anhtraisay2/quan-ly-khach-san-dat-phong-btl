using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CoreApi.Models;
namespace CoreApi.BLL
{
    public class KhachBLL_Ado
    {
        private readonly string _connectionString;

        public KhachBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Khach> LayTatCa()
        {
            var list = new List<Khach>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Khach", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Khach
                        {
                            MaKhach = Convert.ToInt32(reader["MaKhach"]),
                            HoTen = reader["HoTen"].ToString(),
                            DienThoai = reader["DienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            Email = reader["Email"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Khach? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Khach WHERE MaKhach=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Khach
                        {
                            MaKhach = Convert.ToInt32(reader["MaKhach"]),
                            HoTen = reader["HoTen"].ToString(),
                            DienThoai = reader["DienThoai"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Them(Khach khach)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Khach (HoTen, DienThoai, DiaChi, Email) VALUES (@HoTen, @DienThoai, @DiaChi, @Email)", conn);
                cmd.Parameters.AddWithValue("@HoTen", khach.HoTen);
                cmd.Parameters.AddWithValue("@DienThoai", khach.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", khach.DiaChi);
                cmd.Parameters.AddWithValue("@Email", khach.Email);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(Khach khach)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Khach SET HoTen=@HoTen, DienThoai=@DienThoai, DiaChi=@DiaChi, Email=@Email WHERE MaKhach=@MaKhach", conn);
                cmd.Parameters.AddWithValue("@MaKhach", khach.MaKhach);
                cmd.Parameters.AddWithValue("@HoTen", khach.HoTen);
                cmd.Parameters.AddWithValue("@DienThoai", khach.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", khach.DiaChi);
                cmd.Parameters.AddWithValue("@Email", khach.Email);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Khach WHERE MaKhach=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
