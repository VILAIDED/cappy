using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TRO.dataAccess
{
    public class Service
    {
        string findPhongTrong = "select MA_PHONG,TRANG_THAI from (SELECT p.Ma_PHONG MA_PHONG,  Case WHEN HOP_DONG_THUE_PHONG.TRANG_THAI = 'DANG THUE' or HOP_DONG_THUE_PHONG.TRANG_THAI = 'SAP TRA'" +
                                "THEN HOP_DONG_THUE_PHONG.TRANG_THAI ELSE 'available'  END as TRANG_THAI"
                                + "FROM PHONG p FULL OUTER JOIN HOP_DONG_THUE_PHONG ON p.MA_PHONG = HOP_DONG_THUE_PHONG.MA_PHONG) as cap where cap.TRANG_THAI = 'DANG THUE'";
        string 
    }
}
