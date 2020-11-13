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
        public string ten;
        public string ngaySinh;
        public string soCMND;
        public string sdt;
        public string queQuan;
        public string ngheNghiep;
        public string ngayVao;
        public KhachThue next = null;

        public KhachThue(int maKhach,string ten,string ngaySinh,string soCMND,string queQuan,string ngheNghiep,string ngayVao)
        {
            this.maKhach = maKhach;
            this.ten = ten;
            this.ngaySinh = ngaySinh;
            this.soCMND = soCMND;
            this.queQuan = queQuan;
            this.ngheNghiep = ngheNghiep;
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

        public void add(int maKhach, string ten, string ngaySinh, string soCMND, string queQuan, string ngheNghiep, string ngayVao)
        {
            KhachThue add = new KhachThue(maKhach, ten, ngaySinh, soCMND, queQuan, ngheNghiep, ngayVao);
            KhachThue cur = Head;
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
