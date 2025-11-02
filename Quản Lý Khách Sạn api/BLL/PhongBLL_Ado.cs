using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CoreApi.Models;

namespace CoreApi.BLL
{
    public class PhongBLL_Ado
    {
        private readonly string _connectionString;

        public PhongBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Phong> LayDanhSach()
        {
            var list = new List<Phong>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Phong", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Phong
                        {
                            MaPhong = Convert.ToInt32(reader["MaPhong"]),
                            SoPhong = reader["SoPhong"].ToString(),
                            MaLoaiPhong = Convert.ToInt32(reader["MaLoaiPhong"]),
                            TinhTrang = reader["TinhTrang"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Phong? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Phong WHERE MaPhong=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Phong
                        {
                            MaPhong = Convert.ToInt32(reader["MaPhong"]),
                            SoPhong = reader["SoPhong"].ToString(),
                            MaLoaiPhong = Convert.ToInt32(reader["MaLoaiPhong"]),
                            TinhTrang = reader["TinhTrang"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public int ThemVaLayId(Phong phong)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Phong (SoPhong, MaLoaiPhong, TinhTrang) OUTPUT INSERTED.MaPhong VALUES (@SoPhong, @MaLoaiPhong, @TinhTrang)", conn);
                cmd.Parameters.AddWithValue("@SoPhong", phong.SoPhong);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", phong.MaLoaiPhong);
                cmd.Parameters.AddWithValue("@TinhTrang", phong.TinhTrang);
                var id = (int)cmd.ExecuteScalar();
                return id;
            }
        }

        public void CapNhat(Phong phong)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Phong SET SoPhong=@SoPhong, MaLoaiPhong=@MaLoaiPhong, TinhTrang=@TinhTrang WHERE MaPhong=@MaPhong", conn);
                cmd.Parameters.AddWithValue("@MaPhong", phong.MaPhong);
                cmd.Parameters.AddWithValue("@SoPhong", phong.SoPhong);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", phong.MaLoaiPhong);
                cmd.Parameters.AddWithValue("@TinhTrang", phong.TinhTrang);
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new Exception("Không tìm thấy phòng để cập nhật hoặc dữ liệu không hợp lệ!");
                }
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Phong WHERE MaPhong=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
