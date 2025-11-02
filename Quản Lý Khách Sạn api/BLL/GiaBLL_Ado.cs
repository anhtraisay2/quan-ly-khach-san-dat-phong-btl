using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CoreApi.Models;

namespace CoreApi.BLL
{
    public class GiaBLL_Ado
    {
        private readonly string _connectionString;

        public GiaBLL_Ado(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Gia> LayTatCa()
        {
            var list = new List<Gia>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT g.*, lp.Ma, lp.Ten, lp.MoTa, lp.SoKhachToiDa FROM Gia g LEFT JOIN LoaiPhong lp ON g.MaLoaiPhong = lp.MaLoaiPhong", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var gia = new Gia
                        {
                            MaGia = Convert.ToInt32(reader["MaGia"]),
                            MaLoaiPhong = Convert.ToInt32(reader["MaLoaiPhong"]),
                            GiaMoiDem = Convert.ToDecimal(reader["GiaMoiDem"]),
                            GiaMoiGio = reader["GiaMoiGio"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["GiaMoiGio"]),
                            TuNgay = Convert.ToDateTime(reader["TuNgay"]),
                            DenNgay = Convert.ToDateTime(reader["DenNgay"]),
                            GhiChu = reader["GhiChu"] == DBNull.Value ? null : reader["GhiChu"].ToString()
                        };
                        // Nếu có thông tin loại phòng thì gán vào
                        if (reader["Ma"] != DBNull.Value)
                        {
                            gia.LoaiPhong = new LoaiPhong
                            {
                                MaLoaiPhong = gia.MaLoaiPhong,
                                Ma = reader["Ma"].ToString(),
                                Ten = reader["Ten"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                SoKhachToiDa = reader["SoKhachToiDa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoKhachToiDa"])
                            };
                        }
                        list.Add(gia);
                    }
                }
            }
            return list;
        }

        public Gia? LayTheoId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT g.*, lp.Ma, lp.Ten, lp.MoTa, lp.SoKhachToiDa FROM Gia g LEFT JOIN LoaiPhong lp ON g.MaLoaiPhong = lp.MaLoaiPhong WHERE MaGia=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var gia = new Gia
                        {
                            MaGia = Convert.ToInt32(reader["MaGia"]),
                            MaLoaiPhong = Convert.ToInt32(reader["MaLoaiPhong"]),
                            GiaMoiDem = Convert.ToDecimal(reader["GiaMoiDem"]),
                            GiaMoiGio = reader["GiaMoiGio"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["GiaMoiGio"]),
                            TuNgay = Convert.ToDateTime(reader["TuNgay"]),
                            DenNgay = Convert.ToDateTime(reader["DenNgay"]),
                            GhiChu = reader["GhiChu"] == DBNull.Value ? null : reader["GhiChu"].ToString()
                        };
                        if (reader["Ma"] != DBNull.Value)
                        {
                            gia.LoaiPhong = new LoaiPhong
                            {
                                MaLoaiPhong = gia.MaLoaiPhong,
                                Ma = reader["Ma"].ToString(),
                                Ten = reader["Ten"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                SoKhachToiDa = reader["SoKhachToiDa"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SoKhachToiDa"])
                            };
                        }
                        return gia;
                    }
                }
            }
            return null;
        }

        public void Them(Gia gia)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Gia (MaLoaiPhong, GiaMoiDem, GiaMoiGio, TuNgay, DenNgay, GhiChu) VALUES (@MaLoaiPhong, @GiaMoiDem, @GiaMoiGio, @TuNgay, @DenNgay, @GhiChu)", conn);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", gia.MaLoaiPhong);
                cmd.Parameters.AddWithValue("@GiaMoiDem", gia.GiaMoiDem);
                cmd.Parameters.AddWithValue("@GiaMoiGio", (object)gia.GiaMoiGio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TuNgay", gia.TuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", gia.DenNgay);
                cmd.Parameters.AddWithValue("@GhiChu", (object)gia.GhiChu ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void CapNhat(Gia gia)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Gia SET MaLoaiPhong=@MaLoaiPhong, GiaMoiDem=@GiaMoiDem, GiaMoiGio=@GiaMoiGio, TuNgay=@TuNgay, DenNgay=@DenNgay, GhiChu=@GhiChu WHERE MaGia=@MaGia", conn);
                cmd.Parameters.AddWithValue("@MaGia", gia.MaGia);
                cmd.Parameters.AddWithValue("@MaLoaiPhong", gia.MaLoaiPhong);
                cmd.Parameters.AddWithValue("@GiaMoiDem", gia.GiaMoiDem);
                cmd.Parameters.AddWithValue("@GiaMoiGio", (object)gia.GiaMoiGio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TuNgay", gia.TuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", gia.DenNgay);
                cmd.Parameters.AddWithValue("@GhiChu", (object)gia.GhiChu ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Xoa(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Gia WHERE MaGia=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
