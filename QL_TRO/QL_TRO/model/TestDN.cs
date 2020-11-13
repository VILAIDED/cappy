using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_TRO.model
{
    public  class Node
        
    {
        public Node next;
        public int MaDienNuoc;
        public int MaPhong;

        public int SoDien;
        public int SoNuoc;
        public string thangDoc;
        public Node()
        {

        }
        public Node(int MaDienNuoc, int MaPhong, int SoDien, int SoNuoc, string thangDoc)
        {
            this.MaDienNuoc = MaDienNuoc;
            this.MaPhong = MaPhong;
            this.SoDien = SoDien;
            this.SoNuoc = SoNuoc;
            this.thangDoc = thangDoc;
            next = null;
        }
    }
    public class TestDN
    {
        public Node Head;

        public TestDN()
        {
            Head = null;
        }
        public void printList()
        {
            Node show = Head;
            do
            {
                Console.WriteLine(show.MaPhong);
                Console.WriteLine(show.SoDien);
                show = show.next;
            } while (show != null);
        }
        public void addList(int MaDienNuoc,int MaPhong, int SoDien, int SoNuoc, string thangDoc)
        {
            Node add = new Node(MaDienNuoc,MaPhong,SoDien,SoNuoc,thangDoc);
            
            Node cur = Head;
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
