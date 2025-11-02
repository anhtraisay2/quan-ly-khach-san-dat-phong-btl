
using System;
using System.Collections.Generic;
using System.Data;
using CoreApi.Models;
using Microsoft.Data.SqlClient;

namespace CoreApi.BLL
{
    public class DatPhongBLL_Ado
    {
        private readonly string _connectionString;

        public DatPhongBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<DatPhong> LayDanhSach()
        {
            var list = new List<DatPhong>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM DatPhong", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DatPhong
                        {
                            MaDatPhong = Convert.ToInt32(reader["MaDatPhong"]),
                            MaDat = reader["MaDat"] == DBNull.Value ? string.Empty : reader["MaDat"].ToString(),
                            MaPhong = reader["MaPhong"] == DBNull.Value ? null : Convert.ToInt32(reader["MaPhong"]),
                            MaKhach = Convert.ToInt32(reader["MaKhach"]),
                            MaLoaiPhong = Convert.ToInt32(reader["MaLoaiPhong"]),
                            NgayNhan = Convert.ToDateTime(reader["NgayNhan"]),
                            NgayTra = Convert.ToDateTime(reader["NgayTra"]),
                            SoKhach = Convert.ToInt32(reader["SoKhach"]),
                            TrangThai = reader["TrangThai"].ToString(),
                            NguoiTao = reader["NguoiTao"] == DBNull.Value ? null : Convert.ToInt32(reader["NguoiTao"]),
                            NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                            GhiChu = reader["GhiChu"] == DBNull.Value ? null : reader["GhiChu"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public DatPhong? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM DatPhong WHERE MaDatPhong=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DatPhong
                        {
                            MaDatPhong = Convert.ToInt32(reader["MaDatPhong"]),
                            MaPhong = Convert.ToInt32(reader["MaPhong"]),
                            MaKhach = Convert.ToInt32(reader["MaKhach"]),
                            NgayNhan = Convert.ToDateTime(reader["NgayNhan"]),
                            NgayTra = Convert.ToDateTime(reader["NgayTra"]),
                            TrangThai = reader["TrangThai"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Them(DatPhong datPhong)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO DatPhong (MaPhong, MaKhach, NgayDat, NgayTra, TrangThai) VALUES (@MaPhong, @MaKhach, @NgayDat, @NgayTra, @TrangThai)", conn);
                cmd.Parameters.AddWithValue("@MaPhong", datPhong.MaPhong);
                cmd.Parameters.AddWithValue("@MaKhach", datPhong.MaKhach);
                cmd.Parameters.AddWithValue("@NgayNhan", datPhong.NgayNhan);
                cmd.Parameters.AddWithValue("@NgayTra", datPhong.NgayTra);
                cmd.Parameters.AddWithValue("@TrangThai", datPhong.TrangThai);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(DatPhong datPhong)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE DatPhong SET MaPhong=@MaPhong, MaKhach=@MaKhach, NgayDat=@NgayDat, NgayTra=@NgayTra, TrangThai=@TrangThai WHERE MaDatPhong=@MaDatPhong", conn);
                cmd.Parameters.AddWithValue("@MaDatPhong", datPhong.MaDatPhong);
                cmd.Parameters.AddWithValue("@MaPhong", datPhong.MaPhong);
                cmd.Parameters.AddWithValue("@MaKhach", datPhong.MaKhach);
                cmd.Parameters.AddWithValue("@NgayNhan", datPhong.NgayNhan);
                cmd.Parameters.AddWithValue("@NgayTra", datPhong.NgayTra);
                cmd.Parameters.AddWithValue("@TrangThai", datPhong.TrangThai);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM DatPhong WHERE MaDatPhong=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
