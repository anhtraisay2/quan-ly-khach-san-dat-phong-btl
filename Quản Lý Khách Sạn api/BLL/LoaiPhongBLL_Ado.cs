using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CoreApi.Models;

namespace CoreApi.BLL
{
    public class LoaiPhongBLL_Ado
    {
        private readonly string _connectionString;

        public LoaiPhongBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<LoaiPhong> LayTatCa()
        {
            var list = new List<LoaiPhong>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MaLoaiPhong, Ma, Ten, MoTa, SoKhachToiDa FROM LoaiPhong", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LoaiPhong
                        {
                            MaLoaiPhong = Convert.ToInt32(reader["MaLoaiPhong"]),
                            Ma = reader["Ma"].ToString(),
                            Ten = reader["Ten"].ToString(),
                            MoTa = reader["MoTa"] == DBNull.Value ? null : reader["MoTa"].ToString(),
                            SoKhachToiDa = reader["SoKhachToiDa"] == DBNull.Value ? 2 : Convert.ToInt32(reader["SoKhachToiDa"])
                        });
                    }
                }
            }
            return list;
        }

        public LoaiPhong? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM LoaiPhong WHERE MaLoaiPhong=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LoaiPhong
                        {
                            MaLoaiPhong = Convert.ToInt32(reader["MaLoaiPhong"]),
                            Ten = reader["Ten"].ToString(),
                            MoTa = reader["MoTa"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Them(LoaiPhong loaiPhong)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO LoaiPhong (Ten, MoTa) VALUES (@Ten, @MoTa)", conn);
                cmd.Parameters.AddWithValue("@Ten", loaiPhong.Ten);
                cmd.Parameters.AddWithValue("@MoTa", loaiPhong.MoTa);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(LoaiPhong loaiPhong)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE LoaiPhong SET Ten=@Ten, MoTa=@MoTa WHERE MaLoaiPhong=@MaLoaiPhong", conn);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", loaiPhong.MaLoaiPhong);
                cmd.Parameters.AddWithValue("@Ten", loaiPhong.Ten);
                cmd.Parameters.AddWithValue("@MoTa", loaiPhong.MoTa);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM LoaiPhong WHERE MaLoaiPhong=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
