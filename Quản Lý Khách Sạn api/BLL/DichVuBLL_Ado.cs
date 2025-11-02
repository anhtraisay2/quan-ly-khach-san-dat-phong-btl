using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CoreApi.Models;

namespace CoreApi.BLL
{
    public class DichVuBLL_Ado
    {
        private readonly string _connectionString;

        public DichVuBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<DichVu> LayDanhSach()
        {
            var list = new List<DichVu>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM DichVu", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DichVu
                        {
                            MaDV = Convert.ToInt32(reader["MaDV"]),
                            Ma = reader["Ma"] == DBNull.Value ? null : reader["Ma"].ToString(),
                            Ten = reader["Ten"].ToString(),
                            DonGia = Convert.ToDecimal(reader["DonGia"]),
                            Thue = Convert.ToDecimal(reader["Thue"])
                        });
                    }
                }
            }
            return list;
        }

        public DichVu? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM DichVu WHERE MaDV=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DichVu
                        {
                            MaDV = Convert.ToInt32(reader["MaDV"]),
                            Ten = reader["Ten"].ToString(),
                            DonGia = Convert.ToDecimal(reader["DonGia"]),
                            Thue = Convert.ToDecimal(reader["Thue"])
                        };
                    }
                }
            }
            return null;
        }

        public void Them(DichVu dichVu)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO DichVu (Ma, Ten, DonGia, Thue) VALUES (@Ma, @Ten, @DonGia, @Thue)", conn);
                cmd.Parameters.AddWithValue("@Ma", dichVu.Ma ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ten", dichVu.Ten);
                cmd.Parameters.AddWithValue("@DonGia", dichVu.DonGia);
                cmd.Parameters.AddWithValue("@Thue", dichVu.Thue);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(DichVu dichVu)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE DichVu SET Ma=@Ma, Ten=@Ten, DonGia=@DonGia, Thue=@Thue WHERE MaDV=@MaDV", conn);
                cmd.Parameters.AddWithValue("@MaDV", dichVu.MaDV);
                cmd.Parameters.AddWithValue("@Ma", dichVu.Ma ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ten", dichVu.Ten);
                cmd.Parameters.AddWithValue("@DonGia", dichVu.DonGia);
                cmd.Parameters.AddWithValue("@Thue", dichVu.Thue);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM DichVu WHERE MaDV=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
