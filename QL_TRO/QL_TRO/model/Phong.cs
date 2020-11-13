using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TRO.model
{
    public class Phong
    {
        public int maPhong;
        public string loaiPhong;
        public string viTri;
        public int soNgDk;
        public int slNgTD;
        public int giaThue;
        public Phong next;

        public Phong()
        {

        }
        public Phong(int maPhong,string loaiPhong,string viTri,int soNgDk,int slNgTD,int giaThue)
        {
            this.maPhong = maPhong;
            this.loaiPhong = loaiPhong;
            this.viTri = viTri;
            this.soNgDk = soNgDk;
            this.slNgTD = slNgTD;
            this.giaThue = giaThue;
            next = null;
        }
    }

    public class PhongList
    {
        public Phong Head;
        public PhongList()
        {
            Head = null;
        }

        public void add(int maPhong, string loaiPhong, string viTri, int soNgDk, int slNgTD, int giaThue)
        {
            Phong add = new Phong(maPhong, loaiPhong, viTri, soNgDk, slNgTD, giaThue);
            Phong cur = Head;

            if(cur == null)
            {
                Head = add;
            }
            else
            {
                while(cur != null)
                {
                    cur = cur.next;
                }
                cur.next = add;
            }
        }
    }
}
