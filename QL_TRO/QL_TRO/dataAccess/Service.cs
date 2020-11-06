using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TRO.dataAccess
{
    public class Service
    {
        // chắc bỏ cái này
       /*/ string findPhongTrong = "select MA_PHONG,TRANG_THAI from (SELECT p.Ma_PHONG MA_PHONG,  Case WHEN HOP_DONG_THUE_PHONG.TRANG_THAI = 'DANG THUE' or HOP_DONG_THUE_PHONG.TRANG_THAI = 'SAP TRA'" +
                                "THEN HOP_DONG_THUE_PHONG.TRANG_THAI ELSE 'available'  END as TRANG_THAI"
                                + "FROM PHONG p FULL OUTER JOIN HOP_DONG_THUE_PHONG ON p.MA_PHONG = HOP_DONG_THUE_PHONG.MA_PHONG) as cap where cap.TRANG_THAI = 'DANG THUE'";/*/
        string dienNuoc = "SELECT PHONG_ID ,SO_DIEN_CU,SO_DIEN_MOI,SO_DIEN_MOI - SO_DIEN_CU as SO_DIEN_DUNG,SO_NUOC_CU,SO_NUOC_MOI,SO_NUOC_MOI - SO_NUOC_CU as  SO_NUOC_MOI" +
                          "FROM(SELECT p.MA_PHONG PHONG_ID, dn.SO_DIEN SO_DIEN_CU, dn.SO_NUOC SO_NUOC_CU " +
                          "FROM PHONG p, DIEN_NUOC dn WHERE p.MA_PHONG = dn.MA_PHONG AND dn.THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)) as DN_CU FULL OUTER JOIN" +
                           "(SELECT DIEN_NUOC.MA_PHONG as MA_PHONG, DIEN_NUOC.SO_DIEN as SO_DIEN_MOI , DIEN_NUOC.SO_NUOC as SO_NUOC_MOI FROM DIEN_NUOC" +
                          " WHERE THANG_DOC = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0))" +
                          "as DN_MOI ON DN_CU.PHONG_ID = DN_MOI.MA_PHONG;";
    }
}
