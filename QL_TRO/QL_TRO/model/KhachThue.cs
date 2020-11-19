using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TRO.model
{
    public class KhachThue
    {
        public int maKhach;
        public int maPhong;
        public string ten;
        public string gioiTinh;
        public string ngaySinh;
        public string soCMND;
        public string sdt;
        public string queQuan;
        
        public string ngayVao;
        public KhachThue next = null;

        public KhachThue()
        {

        }
        public KhachThue(int maKhach,int maPhong,string ten,string gioiTinh,string ngaySinh,string soCMND,string queQuan,string ngayVao)
        {
            this.maKhach = maKhach;
            this.maPhong = maPhong;
            this.ten = ten;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.soCMND = soCMND;
            this.queQuan = queQuan;
   
            this.ngayVao = ngayVao;

        }
        public KhachThue(int maKhach,string ten, string gioiTinh, string ngaySinh, string soCMND, string queQuan, string ngayVao)
        {
            this.maKhach = maKhach;
       
            this.ten = ten;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.soCMND = soCMND;
            this.queQuan = queQuan;

            this.ngayVao = ngayVao;

        }
    }
    public class KhachThueList
    {
        public KhachThue Head;

        public KhachThueList()
        {
            Head = null;
        }

        public void add(int maKhach, string ten, string gioiTinh, string ngaySinh, string soCMND, string queQuan, string ngayVao)
        {
            KhachThue add = new KhachThue(maKhach, ten,gioiTinh,ngaySinh, soCMND, queQuan, ngayVao);
            KhachThue cur = Head;
            if(cur == null)
            {
                Head = add;
            }
            else
            {
                while(cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = add;
            }
        }
        

        
    }
}
