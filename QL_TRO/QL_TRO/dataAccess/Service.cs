using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using QL_TRO.model;
using System.Data.SqlClient;
using System.Data;

namespace QL_TRO.dataAccess
{
    public class Service
    {
        // chắc bỏ cái này
        /*/ string findPhongTrong = "select MA_PHONG,TRANG_THAI from (SELECT p.Ma_PHONG MA_PHONG,  Case WHEN HOP_DONG_THUE_PHONG.TRANG_THAI = 'DANG THUE' or HOP_DONG_THUE_PHONG.TRANG_THAI = 'SAP TRA'" +
                                 "THEN HOP_DONG_THUE_PHONG.TRANG_THAI ELSE 'available'  END as TRANG_THAI"
                                 + "FROM PHONG p FULL OUTER JOIN HOP_DONG_THUE_PHONG ON p.MA_PHONG = HOP_DONG_THUE_PHONG.MA_PHONG) as PhongTrong where PhongTrong.TRANG_THAI = 'DANG THUE'";/*/


        // show phòng nào trống phòng nào đang thuê
        string statusRoom = "select  MA_PHONG, case when Trang_thai > 0 then 'dang thue' else 'available' end as Trang_thai from (SELECT distinct p.Ma_PHONG MA_PHONG,(select count(MA_PHONG) from KHACH_THUE where KHACH_THUE.MA_PHONG = p.MA_PHONG ) as Trang_thai"
                            + "FROM PHONG p ) as Test";


        // hiện lên có bao nhiêu người ở trong  mỗi phòng
        string songuoitrongRoom = "select  MA_PHONG,Trang_thai from(SELECT distinct p.Ma_PHONG MA_PHONG, (select count(MA_PHONG) from KHACH_THUE where KHACH_THUE.MA_PHONG = p.MA_PHONG) as Trang_thai"
                                  +"FROM PHONG p) as Test";

        // show số điện nước dùng trong tháng 
        string dienNuoc = "SELECT PHONG_ID ,SO_DIEN_CU,SO_DIEN_MOI,SO_DIEN_MOI - SO_DIEN_CU as SO_DIEN_DUNG,SO_NUOC_CU,SO_NUOC_MOI,SO_NUOC_MOI - SO_NUOC_CU as  SO_NUOC_MOI" +
                          "FROM(SELECT p.MA_PHONG PHONG_ID, dn.SO_DIEN SO_DIEN_CU, dn.SO_NUOC SO_NUOC_CU " +
                          "FROM PHONG p, DIEN_NUOC dn WHERE p.MA_PHONG = dn.MA_PHONG AND dn.THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) as DN_CU FULL OUTER JOIN" +
                           "(SELECT DIEN_NUOC.MA_PHONG as MA_PHONG, DIEN_NUOC.SO_DIEN as SO_DIEN_MOI , DIEN_NUOC.SO_NUOC as SO_NUOC_MOI FROM DIEN_NUOC" +
                          " WHERE THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))" +
                          "as DN_MOI ON DN_CU.PHONG_ID = DN_MOI.MA_PHONG;";


        // số điện số nước dùng , tiền điện tiền nước, tổng tiền
        string tienDN = "SELECT PHONG_ID ,SO_DIEN_CU,SO_DIEN_MOI,SO_DIEN_MOI - SO_DIEN_CU as SO_DIEN_DUNG,(SO_DIEN_MOI-SO_DIEN_CU) * 2000 as TIEN_DIEN,SO_NUOC_CU,SO_NUOC_MOI,SO_NUOC_MOI - SO_NUOC_CU as  SO_NUOC_DUNG,"
                         + "(SO_NUOC_MOI - SO_NUOC_CU) * 5000 as TIEN_NUOC,((SO_NUOC_MOI - SO_NUOC_CU) * 5000) +((SO_DIEN_MOI-SO_DIEN_CU) * 2000) as TONG_TIEN" 
                         + "FROM(SELECT p.MA_PHONG PHONG_ID, dn.SO_DIEN SO_DIEN_CU, dn.SO_NUOC SO_NUOC_CU" 
                         +  "FROM PHONG p, DIEN_NUOC dn WHERE p.MA_PHONG = dn.MA_PHONG AND dn.THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) as DN_CU FULL OUTER JOIN" 
                         + "(SELECT DIEN_NUOC.MA_PHONG as MA_PHONG, DIEN_NUOC.SO_DIEN as SO_DIEN_MOI , DIEN_NUOC.SO_NUOC as SO_NUOC_MOI FROM DIEN_NUOC"
                         + " WHERE THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) as DN_MOI ON DN_CU.PHONG_ID = DN_MOI.MA_PHONG";
        // số điện số nước,tổng tiền
        string tongTien = "SELECT PHONG_ID, SO_DIEN_CU, SO_DIEN_MOI, SO_DIEN_MOI - SO_DIEN_CU as SO_DIEN_DUNG,SO_NUOC_CU,SO_NUOC_MOI,SO_NUOC_MOI - SO_NUOC_CU as  SO_NUOC_DUNG,"
                         + "((SO_NUOC_MOI - SO_NUOC_CU) * 5000) +((SO_DIEN_MOI-SO_DIEN_CU) * 2000) as TONG_TIEN" 
                         + "FROM(SELECT p.MA_PHONG PHONG_ID, dn.SO_DIEN SO_DIEN_CU, dn.SO_NUOC SO_NUOC_CU" 
                         +  "FROM PHONG p, DIEN_NUOC dn WHERE p.MA_PHONG = dn.MA_PHONG AND dn.THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) as DN_CU FULL OUTER JOIN" 
                         + "(SELECT DIEN_NUOC.MA_PHONG as MA_PHONG, DIEN_NUOC.SO_DIEN as SO_DIEN_MOI , DIEN_NUOC.SO_NUOC as SO_NUOC_MOI FROM DIEN_NUOC"
                         + " WHERE THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)) as DN_MOI ON DN_CU.PHONG_ID = DN_MOI.MA_PHONG";

        static string testDN = "select * from DIEN_NUOC";

        static string phongTrong = "select Ma_Phong, loai_phong,vi_tri,So_Ng_Dk,SL_Ng_TD,Gia_Thue from (select p.Ma_Phong Ma_Phong,l.ten_loai loai_phong,p.vi_tri vi_tri,(select count(Ma_Khach)" +
                  "from KHACH_THUE k where k.MA_PHONG = p.Ma_Phong) as So_Ng_Dk,l.SL_NGUOI_TOI_DA SL_NG_TD, l.GIA_THUE Gia_Thue from PHONG p,LOAI_PHONG l where p.MA_LOAI = l.MA_LOAI)"
                  +  "as phongNew where So_Ng_Dk<SL_Ng_TD";
       
       

     
        public static Phong getRoom(string maPhong)
        {
            string phongQuery = "select Ma_Phong, loai_phong,vi_tri,So_Ng_Dk,SL_Ng_TD,Gia_Thue from (select p.Ma_Phong Ma_Phong,l.ten_loai loai_phong,p.vi_tri vi_tri,(select count(Ma_Khach)" +
                  $"from KHACH_THUE k where k.MA_PHONG = p.Ma_Phong) as So_Ng_Dk,l.SL_NGUOI_TOI_DA SL_NG_TD, l.GIA_THUE Gia_Thue from PHONG p,LOAI_PHONG l where p.MA_LOAI = l.MA_LOAI AND P.MA_PHONG = {maPhong} )"
                  + "as phongNew where So_Ng_Dk<SL_Ng_TD";
            using (SqlConnection con = new SqlConnection(helper.ConnectString())) // connect CSDL
            {
                if (con.State == ConnectionState.Closed) con.Open(); // nếu connnection đang đóng thì bật lại
                SqlCommand cmd = new SqlCommand(phongQuery, con); // lưu connection và query vào để Execute
                SqlDataReader rd = cmd.ExecuteReader(); // Execute 
                Phong phong = new Phong();
                if (rd.HasRows) // nếu có hạng thì sẽ thực hiện gọi dữ liệu vào list
                {
                    while (rd.Read()) // cho đọc từng hàng hết hàng thì dừng
                    {
                        phong.maPhong = rd.GetInt32(rd.GetOrdinal("MA_PHONG")); // gọi dữ theo tên cột vào mỗi thành viên của class model
                        phong.loaiPhong = rd.GetString(rd.GetOrdinal("Loai_Phong"));
                        phong.viTri = rd.GetString(rd.GetOrdinal("Vi_Tri"));
                        phong.soNgDk = rd.GetInt32(rd.GetOrdinal("So_Ng_Dk"));
                        phong.slNgTD = rd.GetInt32(rd.GetOrdinal("Sl_Ng_TD"));
                        phong.giaThue = rd.GetInt32(rd.GetOrdinal("Gia_Thue"));
                    }
                }
                return phong;
            }
        }

        // fetch list những phòng trống
        public static PhongList getRoomAvailable()
        {
            using (SqlConnection con = new SqlConnection(helper.ConnectString()))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand(phongTrong, con);
                SqlDataReader rd = cmd.ExecuteReader();
                PhongList phongList = new PhongList();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int MaPhong = rd.GetInt32(rd.GetOrdinal("MA_PHONG"));
                        string loaiPhong = rd.GetString(rd.GetOrdinal("Loai_Phong"));
                        string viTri = rd.GetString(rd.GetOrdinal("Vi_Tri"));
                        int soNgDk = rd.GetInt32(rd.GetOrdinal("So_Ng_Dk"));
                        int slNgTD = rd.GetInt32(rd.GetOrdinal("Sl_Ng_TD"));
                        int giaThue = rd.GetInt32(rd.GetOrdinal("Gia_Thue"));
                        phongList.add(MaPhong, loaiPhong, viTri, soNgDk, slNgTD, giaThue); // đưa vào list từng hàng
                    }
                }
                return phongList;
            }
        }
        
        // fetch dữ liệu của khách trong phòng nào đó # có nhập maPhong vào
        public static KhachThueList getCustomerRoom(string maPhong)
        {
            using (SqlConnection con = new SqlConnection(helper.ConnectString()))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string khachPhong = "SELECT Ma_Khach,Ho_Ten,Ngay_Sinh,So_CMND,Gioi_Tinh,Sdt,Que_Quan,Nghe_Nghiep,Ngay_Vao FROM" +
                     "(SELECT kh.MA_KHACH Ma_Khach,kh.HO_TEN Ho_Ten, kh.NGAY_SINH Ngay_Sinh, kh.CMND So_CMND, kh.GIOI_TINH Gioi_Tinh, kh.SDT Sdt, kh.QUE_QUAN Que_Quan," +
                     "kh.NGHE_NGHIEP Nghe_Nghiep,th.NGAY_VAO_O Ngay_Vao FROM KHACH_THUE kh, THUE_TRA_PHONG th where kh.MA_PHONG = @maPhong AND  kh.MA_KHACH = th.MA_KHACH) as KhachPhong";
                     // @maPhong là nhận giá trị từ bên ngoài #nhận từ cmd.parameter(đc gọi ở dưới đây)
                SqlCommand cmd = new SqlCommand(khachPhong, con);
                cmd.Parameters.AddWithValue("@maPhong", maPhong); // nhập giá trị vào @maPhong rồi mới Execute
                // nhập giá trị vào kiểu này cách basic để cho CSDL của mình an toàn hơn # cách mà ko an toàn thì mình để comment ở dưới hàm này
                // 
                SqlDataReader rd = cmd.ExecuteReader();
                KhachThueList khachList = new KhachThueList();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int maKhach = rd.GetInt32(rd.GetOrdinal("Ma_Khach"));
                        string hoTen = rd.GetString(rd.GetOrdinal("Ho_Ten"));
                        string ngaySinh = rd.GetValue(rd.GetOrdinal("Ngay_Sinh")).ToString();
                        string soCMND = rd.GetString(rd.GetOrdinal("So_CMND"));
                        string gioiTinh = rd.GetString(rd.GetOrdinal("Gioi_Tinh"));
                        string sdt = rd.GetString(rd.GetOrdinal("Sdt"));
                        string ngheNghiep = rd.GetString(rd.GetOrdinal("Nghe_Nghiep"));
                        string quenQuan = rd.GetString(rd.GetOrdinal("Que_Quan"));
                        string ngayVao = rd.GetValue(rd.GetOrdinal("Ngay_Vao")).ToString();
                        khachList.add(maKhach, hoTen, gioiTinh, ngaySinh, soCMND,sdt, quenQuan,ngheNghiep, ngayVao);
                        
                    }
                }
                return khachList;
                     
                     }
        }

        /*/
        public static KhachThueList getCustomerRoom1(string maPhong)
        {
            using (SqlConnection con = new SqlConnection(helper.ConnectString()))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string khachPhong = "SELECT Ma_Khach,Ho_Ten,Ngay_Sinh,So_CMND,Gioi_Tinh,Sdt,Que_Quan,Ngay_Vao FROM" +
                     "(SELECT kh.MA_KHACH Ma_Khach,kh.HO_TEN Ho_Ten, kh.NGAY_SINH Ngay_Sinh, kh.CMND So_CMND, kh.GIOI_TINH Gioi_Tinh, kh.SDT Sdt, kh.QUE_QUAN Que_Quan," +
                     $"th.NGAY_VAO_O Ngay_Vao FROM KHACH_THUE kh, THUE_TRA_PHONG th where kh.MA_PHONG = {maPhong} AND  kh.MA_KHACH = th.MA_KHACH) as KhachPhong";
                SqlCommand cmd = new SqlCommand(khachPhong, con);
            
                SqlDataReader rd = cmd.ExecuteReader();
                KhachThueList khachList = new KhachThueList();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int maKhach = rd.GetInt32(rd.GetOrdinal("Ma_Khach"));
                        string hoTen = rd.GetString(rd.GetOrdinal("Ho_Ten"));
                        string ngaySinh = rd.GetValue(rd.GetOrdinal("Ngay_Sinh")).ToString();
                        string soCMND = rd.GetString(rd.GetOrdinal("So_CMND"));
                        string gioiTinh = rd.GetString(rd.GetOrdinal("Gioi_Tinh"));
                        string sdt = rd.GetString(rd.GetOrdinal("Sdt"));
                        string quenQuan = rd.GetString(rd.GetOrdinal("Que_Quan"));
                        string ngayVao = rd.GetValue(rd.GetOrdinal("Ngay_Vao")).ToString();
                        khachList.add(maKhach, hoTen, gioiTinh, ngaySinh, soCMND, quenQuan, ngayVao);

                    }
                }
                return khachList;

            }
        }
        */

        // ĐK dữ liệu khách vào phòng # return true nếu ĐK thành công
        public static bool insertCustomer(KhachThue khach)
        {
            bool check = false;
           
            using(SqlConnection con = new SqlConnection(helper.ConnectString()))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string query = "INSERT INTO KHACH_THUE VALUES(@maPhong,@hoten,@CMND,@ngaySinh,@gioiTinh,@queQuan,@sdt,@ngheNghiep)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue ("@hoten", khach.ten);
                cmd.Parameters.AddWithValue("@maPhong", khach.maPhong);
                cmd.Parameters.AddWithValue("@CMND", khach.soCMND);
                cmd.Parameters.AddWithValue("@ngaySinh", khach.ngaySinh);
                cmd.Parameters.AddWithValue("@gioiTinh", khach.gioiTinh);
                cmd.Parameters.AddWithValue("@queQuan", khach.queQuan);
                cmd.Parameters.AddWithValue("@ngheNghiep", khach.ngheNghiep);
                cmd.Parameters.AddWithValue("@sdt", khach.sdt);
                SqlDataReader rd = cmd.ExecuteReader();
                int maKhach = 0;
                if (rd.HasRows)
                {
                    while(rd.Read())
                    {
                        maKhach = rd.GetInt32(rd.GetOrdinal("Ma_Khach"));
                    }
                    string queryThue = "INSERT INTO THUE_TRA_PHONG (MA_PHONG,MA_KHACH,NGAY_VAO_O) VALUES(@maPhong,@maKhach,@ngayVao)";
                    using (SqlCommand cmdThue = new SqlCommand(queryThue, con))
                    {
                        rd.Close();
                        cmdThue.Parameters.AddWithValue("@maPhong", khach.maPhong);
                        cmdThue.Parameters.AddWithValue("@maKhach", maKhach);
                        cmdThue.Parameters.AddWithValue("@ngayVao", khach.ngayVao);
                        int result = cmdThue.ExecuteNonQuery();
                        if (result > 0) check = true;
                    }
                }
                
               
                   
                   
                
                
                return check;
            }
        }
        
    

    }
}
