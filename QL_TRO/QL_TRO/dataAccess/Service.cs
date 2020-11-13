using System;
using System.Collections.Generic;
using System.Linq;
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



        // gọi dữ liệu từ CSDL vào linkedlist
        public static TestDN fetchDN()
        {
            using(SqlConnection con = new SqlConnection(helper.ConnectString()))
            {

                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand(testDN, con);
                SqlDataReader rd = cmd.ExecuteReader();
                TestDN dnList = new TestDN();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        int MaDienNuoc = rd.GetInt32(rd.GetOrdinal("MA_DIEN_NUOC"));
                        int MaPhong = rd.GetInt32(rd.GetOrdinal("MA_PHONG"));
                  
                        int SoNuoc = rd.GetInt32(rd.GetOrdinal("SO_NUOC"));
                        int Sodien = rd.GetInt32(rd.GetOrdinal("SO_DIEN"));
                        string thangDoc = rd.GetValue(rd.GetOrdinal("THANG_DOC")).ToString();
                        dnList.addList(MaDienNuoc, MaPhong, Sodien, SoNuoc, thangDoc);
                    }
                }
                return dnList;
            }
        }
       
        
    

    }
}
